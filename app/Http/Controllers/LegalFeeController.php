<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use App\Http\Requests\LegalFeeRequest;
use App\Models\{JudicialAction, JudicialProcess, LegalFee, InstallmentLegalFee, NatureAction, Client};
use Illuminate\Http\Request;
use Devrabiul\ToastMagic\Facades\ToastMagic;
use Carbon\Carbon;
use Exception;
use Illuminate\Support\Facades\Auth;

class LegalFeeController extends Controller
{
    public function list()
    {
        $legalFees = LegalFee::all();
        return view('legal-fee.list', compact('legalFees'));

    }

    public function create(Request $request)
    {
        $legalFee = new LegalFee();
        $legalFee->id_public = 0;
        $titleView = "Novo Honorário";
        $clients = [];
        $statusHonorarium = 'EM ANDAMENTO';


        $legalFee->setRelation('clients', collect());
        $legalFee->setRelation('installments', collect());
        $process_number = [];
        return view(
            'legal-fee.form',
            compact('titleView', 'legalFee', 'clients', 'statusHonorarium', 'process_number')
        );
    }

    public function edit($legalFee)
    {
        $legalFee = LegalFee::where('id_public', $legalFee)->firstOrFail();
        $titleView = "Editar Honorário";
        $legalFee->load(['clients', 'installments.client', 'installments.statusPayment']);
        $process_number = [
            JudicialProcess::where('id', $legalFee->judicial_process_id)
            ->select('id_public', 'process_number')
            ->first()
            ?->toArray()
        ];
        // dd($legalFee->toArray());
        $statusHonorarium = 'EM ANDAMENTO';
        $legalFee->amount = number_format($legalFee->amount,2,',','.');
        return view(
            'legal-fee.form',
            compact('titleView', 'legalFee', 'statusHonorarium', 'process_number')
        );
    }


    public function save(LegalFeeRequest $legalFeeRequest)
    {

        $payloadValidated = $legalFeeRequest->validated();
        $startDate = Carbon::parse($payloadValidated['due_date']);
        $processNumberId = JudicialProcess::where('id_public', operator: $payloadValidated['process_number_id'])->first()->id;
        $value_installments = bcdiv($payloadValidated['amount'], $payloadValidated['quantity_installment'], 2);
        // Honorario
        $legalFee = LegalFee::create([
            'amount' => $payloadValidated['amount'],
            'quantity_installment' => $payloadValidated['quantity_installment'],
            'judicial_process_id' => $processNumberId,
            'status_payment_id' => 2, // pendente
            'note' => $payloadValidated['note'] ?? null,
            'user_id' => Auth::id(),
        ]);

        $clientIds = Client::whereIn('id_public', $payloadValidated['client_id'])->pluck('id');

        foreach ($clientIds as $clientId) {
            for ($i = 1; $i <= $payloadValidated['quantity_installment']; $i++) {
                InstallmentLegalFee::create([
                    'legal_fee_id' => $legalFee->id,
                    'client_id' => $clientId,
                    'current_installment' => $i,
                    'value_installment' => $value_installments,
                    'status_payment_id' => 2,
                    'due_date' => $startDate->copy()->addMonths($i - 1),
                    'note' => $payloadValidated['note'] ?? null,
                ]);
            }
        }

        $legalFee->clients()->syncWithoutDetaching($clientIds);

        $message = 'Honorário registrado com sucesso';
        $statusHttp = 201;
        ToastMagic::success('Sucesso!', $message);
        return response()->json(['status' => $statusHttp, 'success' => $message]);
    }

    public function update(LegalFeeRequest $request)
    {

        try {
            $payloadValidated = $request->validated();

            $feeId = $request->get('id_public');
            $legalFee = LegalFee::with('installments')
            ->where('id_public', $feeId)
            ->first();

            if(empty($legalFee)){
                return response()->json( ['status'=> 409,'message'=> 'Honorário não registrado!']);
            }

            $clients = Client::whereIn('id_public', $payloadValidated['client_id'])->pluck('name', 'id');

            $clientWithoutPendingInstallments = [];
            foreach ($clients as $clientId => $clientName) {

                $pending = $legalFee->installments
                    ->where('status_payment_id', 2)
                    ->where('client_id', $clientId);

                $total = $pending->sum('value_installment');

                if ($total == 0) {
                    $clientWithoutPendingInstallments[] = $clientName . ' não possui parcelas pendentes.';
                    continue;
                }

                $newQuantity = $payloadValidated['quantity_installment'];

                if($newQuantity <= $legalFee->quantity_installment){
                    return response()->json([
                        'success' => false,
                        'errors' => ['A nova quantidade de parcelas deve ser maior que a quantidade atual!'],
                        'warnings' => [],
                    ], 422);

                }

                $newValue = bcdiv($total, $newQuantity, 2);

                $legalFee->installments()
                    ->where('status_payment_id', 2)
                    ->where('client_id', $clientId)
                    ->update(['value_installment' => $newValue]);

                $lastInstallment = $legalFee->installments
                ->where('client_id', $clientId)
                ->sortByDesc('current_installment')
                ->first();
                $lastNumber  = $lastInstallment->current_installment;
                $lastDueDate = Carbon::parse($lastInstallment->due_date);

                $existingQty = $legalFee->quantity_installment;
                $toCreate = $newQuantity - $existingQty;
                  for ($i = 1; $i <= $toCreate; $i++) {
                        InstallmentLegalFee::create([
                            'legal_fee_id'        => $legalFee->id,
                            'client_id'           => $clientId,
                            'current_installment' => $lastNumber + $i,
                            'value_installment'   => $newValue,
                            'status_payment_id'   => 2,
                            'due_date'            => $lastDueDate->copy()->addMonths($i),
                            'note'                => $payloadValidated['note'] ?? null,
                        ]);
                    }

                $legalFee->update(['quantity_installment' => $newQuantity]);
            }

            if(!empty($clientWithoutPendingInstallments)){
                    return response()->json([
                    'success' => false,
                    'warnings' => $clientWithoutPendingInstallments,
                ], 207);
            }
            $message = 'Parcelas lançadas com sucesso!';
            $statusHttp = 200;
            ToastMagic::success('Sucesso!', $message);

            return response()->json(['status' => $statusHttp, 'success' => $message]);
        } catch (Exception $e) {
            dd($e);
        }

    }


    public function delete(LegalFee $fee)
    {

        try {


            $fee->load([ 'installments']);
            $installments = $fee->installments;
            $haveInstallmentPending = $installments->contains(function ($item) {
                return in_array($item['status_payment_id'], [2, 3]);
            });
            // dd($haveInstallmentPending);
            if($haveInstallmentPending){
                throw new Exception('Erro ao deletar! Honorário possui parcelas pendentes em aberto.');
            }


            $fee->delete();
            $message = 'Honorário deletado com sucesso!';
            $statusHttp = 204;
            ToastMagic::success('Sucesso!', $message);
            return response()->json(['status' => $statusHttp]);
        } catch (\Throwable $e) {
            return response()->json(['error' => $e->getMessage(), 'status' => 500]);
        }

    }














}

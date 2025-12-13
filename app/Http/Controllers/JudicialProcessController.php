<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use App\Http\Requests\JudicialProcessRequest;
use App\Models\{JudicialAction, JudicialProcess, NatureAction, Entity, Client, EntityIndividual};
use Illuminate\Http\Request;
use Devrabiul\ToastMagic\Facades\ToastMagic;
use Illuminate\Support\Facades\Auth;



class JudicialProcessController extends Controller
{
    public function list()
    {

        $processes = JudicialProcess::all();
        return view('judicial-process.list', compact('processes'));

    }

    public function create()
    {
        $process = new JudicialProcess();
        $process->id_public = 0;
        $titleView = "Novo Processo";
        $clients = [];
        $nature_actions = NatureAction::all();
        $actions = JudicialAction::all();

        return view(
            'judicial-process.form',
            compact('titleView', 'process', 'nature_actions', 'actions', 'clients')
        );
    }

    public function edit(JudicialProcess $process)
    {
        $titleView = "Editar Processo";
        $nature_actions = NatureAction::all();
        $actions = JudicialAction::all();
        $process = $process->with(['entity.entityIndividual'])->first();
        $clients = $process->entity->map(function($entity){
            return [
                'id_public' => $entity->id_public,
                'name'      => $entity->entityIndividual?->name,
            ];
        });

        return view(
            'judicial-process.form',
            compact('titleView', 'process', 'nature_actions', 'actions', 'clients')
        );
    }


    public function save(JudicialProcessRequest $judicialProcessRequest)
    {
        $payloadValidated = $judicialProcessRequest->validated();
        $payloadValidated['user_id'] = Auth::id();
        $entitiesIds = Entity::whereIn('id_public', $payloadValidated['entity_id'])
                   ->pluck('id') // pega apenas a coluna id
                   ->toArray();  // transforma em array simples

        unset($payloadValidated['entity_id']); // Remove entity_id do payload principal

        $process = JudicialProcess::create($payloadValidated);

        $process->entity()->attach($entitiesIds);

        $message = 'Processo judicial registrado com sucesso';
        $statusHttp = 201;
        ToastMagic::success('Sucesso!', $message);
        return response()->json(['success'=>$message,'status' => $statusHttp]);
    }

    public function update(JudicialProcessRequest $request, JudicialProcess $process)
    {

        try {

            $payloadValidated = $request->validated();
            $entitiesIds = Entity::whereIn('id_public', $payloadValidated['entity_id'])
                   ->pluck('id')
                   ->toArray();

            unset($payloadValidated['entity_id']);

            $process->entity()->sync($entitiesIds);

            $process->update($payloadValidated);
            $message = 'Processo judicial atualizado com sucesso!';
            $statusHttp = 200;
            ToastMagic::success('Sucesso!', $message);

            return response()->json(['success' => $message, 'status' => $statusHttp]);
        } catch (\Throwable $e) {
            dd($e);
        }

    }


    public function delete(JudicialProcess $process)
    {

        try {
            $process->delete();
            $message = 'Processo judicial deletado com sucesso!';
            $statusHttp = 200;
            ToastMagic::success('Sucesso!', $message);
            return response()->json(['success' => $message, 'status' => $statusHttp]);
        } catch (\Throwable $e) {
            return response()->json(['error' => $e->getMessage(), 'status' => 500]);
        }

    }

    public function search(Request $request)
    {
        $query = $request->query('q');

        if (!$query) {
            return response()->json([]);
        }

        $process_number = JudicialProcess::where('process_number', 'LIKE', "%{$query}%")
        ->limit(10)
        ->with(['entity.entityIndividual:id,name,entity_id'])
        ->get(['id', 'id_public', 'process_number'])
        ->map(function($process){

            // monta o clients
            $clients = $process->entity->map(function($e){
                return [
                    'id_public' => $e->id_public,
                    'name'      => $e->entityIndividual?->name,
                ];
            });

            // devolve já tratado
            return [
                'id_public'      => $process->id_public,
                'process_number' => $process->process_number,
                'clients'        => $clients,
            ];
        });

        return response()->json($process_number);
    }














}

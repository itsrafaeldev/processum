<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use App\Http\Requests\JudicialProcessRequest;
use App\Models\{JudicialAction, JudicialProcess, NatureAction, Client};
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
        $clients = $process->clients->map(function($client) {
                    return [
                        'id_public' => $client->id_public,
                        'name' => $client->name
                    ];
                })->toArray();

        return view(
            'judicial-process.form',
            compact('titleView', 'process', 'nature_actions', 'actions', 'clients')
        );
    }


    public function save(JudicialProcessRequest $judicialProcessRequest)
    {
        $payloadValidated = $judicialProcessRequest->validated();
        $payloadValidated['user_id'] = Auth::id();

        $clientIds = Client::whereIn('id_public', $payloadValidated['client_id'])
                   ->pluck('id') // pega apenas a coluna id
                   ->toArray();  // transforma em array simples

        unset($payloadValidated['client_id']); // Remove client_id do payload principal

        $process = JudicialProcess::create($payloadValidated);

        $process->clients()->attach($clientIds);

        $message = 'Processo judicial registrado com sucesso';
        $statusHttp = 201;
        ToastMagic::success('Sucesso!', $message);
        return response()->json(['success'=>$message,'status' => $statusHttp]);
    }

    public function update(JudicialProcessRequest $request, JudicialProcess $process)
    {

        try {

            $payloadValidated = $request->validated();

            $clientIds = Client::whereIn('id_public', $payloadValidated['client_id'])
                   ->pluck('id')
                   ->toArray();

            unset($payloadValidated['client_id']);

            $process->clients()->sync($clientIds);

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
        ->with(['clients:id_public,name']) // apenas id e name
        ->get(['id', 'id_public', 'process_number']);
        return response()->json($process_number);
    }














}

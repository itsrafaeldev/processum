<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use App\Http\Requests\ClientRequest;
use App\Models\{Client};
use DateTime;
use Illuminate\Http\Request;
use Devrabiul\ToastMagic\Facades\ToastMagic;
;

class ClientController extends Controller
{
    public function list()
    {
        $clients = Client::all();
        $clients = $clients->makeHidden(['id', 'created_at', 'updated_at', 'lawyer_id']);
        return view('clients.list', compact('clients'));

    }

    //formulario despesas
    public function create()
    {
        $client = new Client();
        $client->id_public = 0;
        $titleView = "Novo Cliente";
        return view('clients.form', compact('titleView', 'client'));

    }


    public function edit(Client $client)
    {
        $titleView = "Editar Cliente";
        $client = $client->makeHidden(['id', 'created_at', 'updated_at', 'lawyer_id']);
        return view('clients.form', compact('titleView', 'client'));

    }


    public function save(ClientRequest $clientRequest)
    {
        $clientValidated = $clientRequest->validated();
        $clientValidated['lawyer_id'] = auth()->user()->id;
        Client::create($clientValidated);

        $message = 'Cliente registrado com sucesso';
        $statusHttp = 201;
        ToastMagic::success('Sucesso!', $message);
        return response()->json(['success' => $message, 'status' => $statusHttp]);
    }

    public function update(ClientRequest $request, Client $client)
    {
        $updateValidated = $request->validated();
        $client->update($updateValidated);
        $message = 'Cliente atualizado com sucesso';
        $statusHttp = 201;
        ToastMagic::success('Sucesso!', $message);
        return response()->json(['success' => $message, 'status' => $statusHttp]);

    }


    public function delete(Client $client)
    {
          try {
            $client->delete();
            $message = 'Cliente deletado com sucesso!';
            $statusHttp = 200;
            ToastMagic::success('Sucesso!', $message);
            return response()->json(['success' => $message, 'status' => $statusHttp]);
        } catch (\Throwable $e) {
            return response()->json(['error' => $e->getMessage(), 'status' => 500]);
        }


    }














}

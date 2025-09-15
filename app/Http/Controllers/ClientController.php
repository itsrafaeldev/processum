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

        return view('clients.list');

    }

    //formulario despesas
    public function create()
    {
        $client = new Client();
        $client->id_public = 0;
        $titleView = "Novo Cliente";

        return view('clients.form', compact('titleView', 'client'));

    }

    //formulario receitas


    public function edit(Client $client)
    {
        $titleView = "Editar Cliente";
        $client = $client->makeHidden(['id', 'created_at', 'updated_at']);
        return view('clients.form', compact('titleView', 'client'));

    }


    public function save(ClientRequest $clientRequest)
    {
        dd("METODO SAVE ACESSADO!");
        $clientValidated = $clientRequest->validated();
        Client::create($clientValidated);

        $message = 'Cliente registrado com sucesso';
        $statusHttp = 201;
        ToastMagic::success('Sucesso!', $message);
        return response()->json(['success' => $message, 'status' => $statusHttp]);
    }

    public function update(ClientRequest $request, Client $client)
    {

        return "metodo update UserController";

    }


    public function delete(ClientRequest $client)
    {
        return "metodo delete UserController";

    }














}

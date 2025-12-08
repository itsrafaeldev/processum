<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use App\Http\Requests\{ClientIndividualRequest, ClientCompanyRequest};
use App\Models\{Client, Entity, EntityIndividual, EntityCompany};
use DateTime;
use Illuminate\Http\Request;
use Devrabiul\ToastMagic\Facades\ToastMagic;
use Illuminate\Support\Facades\DB;


class ClientController extends Controller
{
    public function list()
    {
        $clients = Client::all();
        return view('clients.list', compact('clients'));
    }

     public function search(Request $request)
    {
        $query = $request->query('q');

        if (!$query) {
            return response()->json([]);
        }

        $clients = Client::where(DB::raw('UPPER(name)'), 'like', '%' . strtoupper($query) . '%')
            ->limit(10)
            ->get(['id_public', 'name']);

        return response()->json($clients);
    }

    public function createPF()
    {
        $entity = new Entity();

        $entity->entity_type = 'PF';

        // set relations memory only
        $entity->setRelation('entityIndividual',    new EntityIndividual());
       // $entity->setRelation('client',        new Client());

        // fake public id for front
        $entity->id_public = 0;

        $titleView = "Novo Cliente";
        //dd("entity: ", $entity->toArray(), $entity->entityIndividual->name);
        return view('clients.individual.form', compact('titleView', 'entity'));
    }

    public function editPF(Client $client)
    {
        $titleView = "Editar Cliente";
        $client = $client->makeHidden(['id', 'created_at', 'updated_at', 'lawyer_id']);
        return view('clients.form', compact('titleView', 'client'));
    }


    public function savePF(ClientIndividualRequest $clientRequest)
    {
        $clientValidated = $clientRequest->validated();
        $entityPayload = [
            'status_id' => 1, //A = Ativo
            'type_entity' => 'PF'
        ];
        $entityIndividualPayload = [
            'name' => $clientValidated['name'],
            'cpf' => $clientValidated['cpf'],
            'email' => $clientValidated['email'],
            'address' => $clientValidated['address'],
            'mobile' => $clientValidated['mobile'],
            'phone' => $clientValidated['phone'],
        ];

        $clientPayload = [
            'lawyer_id' => auth()->user()->id,
        ];

        //dd($clientValidated, $entityPayload, $entityIndividualPayload, $clientPayload);
        Entity::create($entityPayload);
        EntityIndividual::created($entityIndividualPayload);
        Client::create($clientPayload);


        $message = 'Cliente registrado com sucesso';
        $statusHttp = 201;
        ToastMagic::success('Sucesso!', $message);
        return response()->json(['success' => $message, 'status' => $statusHttp]);
    }

    public function updatePF(ClientIndividualRequest $request, Client $client)
    {
        $updateValidated = $request->validated();
        $client->update($updateValidated);
        $message = 'Cliente atualizado com sucesso';
        $statusHttp = 201;
        ToastMagic::success('Sucesso!', $message);
        return response()->json(['success' => $message, 'status' => $statusHttp]);
    }


    public function deletePF(Client $client)
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

    public function createPJ()
    {
        $entity = new Entity();

        $entity->type = 'PF';

        // set relations memory only
        $entity->setRelation('entityCompany',    new EntityCompany());
        //$entity->setRelation('client',        new Client());

        // fake public id for front
        $entity->id_public = 0;

        $titleView = "Novo Cliente";

        return view('clients.company.form', compact('titleView', 'entity'));
    }

    public function editPJ(Client $client)
    {
        $titleView = "Editar Cliente";
        $client = $client->makeHidden(['id', 'created_at', 'updated_at', 'lawyer_id']);
        return view('clients.form', compact('titleView', 'client'));
    }


    public function savePJ(ClientCompanyRequest $clientRequest)
    {
        $clientValidated = $clientRequest->validated();
        $clientValidated['lawyer_id'] = auth()->user()->id;
        Client::create($clientValidated);

        $message = 'Cliente registrado com sucesso';
        $statusHttp = 201;
        ToastMagic::success('Sucesso!', $message);
        return response()->json(['success' => $message, 'status' => $statusHttp]);
    }

    public function updatePJ(ClientCompanyRequest $request, Client $client)
    {
        $updateValidated = $request->validated();
        $client->update($updateValidated);
        $message = 'Cliente atualizado com sucesso';
        $statusHttp = 201;
        ToastMagic::success('Sucesso!', $message);
        return response()->json(['success' => $message, 'status' => $statusHttp]);
    }


    public function deletePJ(Client $client)
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

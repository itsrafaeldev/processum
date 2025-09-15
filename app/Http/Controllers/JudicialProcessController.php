<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use App\Http\Requests\JudicialProcessRequest;
use App\Models\{JudicialAction, JudicialProcess, NatureAction};
use Illuminate\Http\Request;
use Devrabiul\ToastMagic\Facades\ToastMagic;


class JudicialProcessController extends Controller
{
    public function list()
    {

        $processes = JudicialProcess::all();

        return view('judicial-process.list', compact('processes'));

    }

    //formulario despesas
    public function create()
    {
        $process = new JudicialProcess();
        $process->id_public = 0;
        $titleView = "Novo Processo";

        $nature_actions = NatureAction::all();
        $actions = JudicialAction::all();

        return view(
            'judicial-process.form',
            compact('titleView', 'process', 'nature_actions', 'actions')
        );
    }

    //formulario receitas


    public function edit(JudicialProcess $process)
    {
        $titleView = "Editar Processo";
        $nature_actions = NatureAction::all();
        $actions = JudicialAction::all();
        $process = $process->makeHidden(['id', 'created_at', 'updated_at']);


        return view(
            'judicial-process.form',
            compact('titleView', 'process', 'nature_actions', 'actions')
        );
    }


    public function save(JudicialProcessRequest $judicialProcessRequest)
    {
        $payloadValidated = $judicialProcessRequest->validated();
        $payloadValidated['user_id'] = auth()->id();
        JudicialProcess::create($payloadValidated);

        $message = 'Processo judicial registrado com sucesso';
        $statusHttp = 201;
        ToastMagic::success('Sucesso!', $message);
        return response()->json(['success'=>$message,'status' => $statusHttp]);
    }

    public function update(JudicialProcessRequest $request, JudicialProcess $process)
    {

        try {

            $payloadValidated = $request->validated();
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














}

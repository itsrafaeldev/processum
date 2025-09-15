<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use App\Http\Requests\JudicialProcessRequest;
use App\Models\JudicialAction;
use App\Models\User;
use App\Models\NatureAction;
use DateTime;
use Illuminate\Http\Request;
use Devrabiul\ToastMagic\Facades\ToastMagic;
use Illuminate\Contracts\Support\Responsable;
use Maatwebsite\Excel\Concerns\FromCollection;
use Maatwebsite\Excel\Concerns\Exportable;
use App\Exports\ExcelExport;
use Maatwebsite\Excel\Facades\Excel;

class UserController extends Controller
{
    public function list()
    {

        return "metodo list UserController";

    }

    //formulario despesas
    public function create(Request $request)
    {
        return "metodo create UserController";

    }

    //formulario receitas


    public function edit(JudicialProcess $process)
    {
        return "metodo edit UserController";

    }


    public function save(JudicialProcessRequest $judicialProcessRequest)
    {
        return "metodo save UserController";

    }

    public function update(Request $request, JudicialProcess $process)
    {

        return "metodo update UserController";

    }


    public function delete(JudicialProcess $process)
    {
        return "metodo delete UserController";

    }














}

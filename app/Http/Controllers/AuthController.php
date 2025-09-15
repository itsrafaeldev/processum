<?php

namespace App\Http\Controllers;
use App\Http\Requests\LoginRequest;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;
use Devrabiul\ToastMagic\Facades\ToastMagic;


class AuthController extends Controller
{
    public function formLogin(){
        return view('login.login');
    }

    public function login(LoginRequest $loginRequest){


        $credentials = $loginRequest->validated();


        if (!Auth::attempt($credentials)) {
            // Se a autenticação falhar, exibe mensagem
            ToastMagic::error('Login inválido!');
            return back()->withInput();
        }

        // Login bem-sucedido
        $loginRequest->session()->regenerate();
        ToastMagic::success('Sucesso!', 'Login realizado com sucesso!');
        return redirect()->route('judicial-process.list');

    }



}

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <meta name="csrf-token" content="{{ csrf_token() }}">

    <link rel="shortcut icon" href="{{ asset('balanca.svg') }}" type="image/x-icon">
    <title>Processum - Login</title>
    {!! ToastMagic::styles() !!}

    <style>
        .error-message {
            color: red;
        }
    </style>
</head>

<body>
    <div class="container-fluid">
        <h1>Login</h1>
    </div>

    <div class="container-fluid">
        <form action="{{ route('login.auth') }}" class="d-flex flex-column w-50 ml-2 mb-5" id="formLogin" method="POST">
            @csrf

            <div>
                Email: <input class="form-control mb-2 w-50" type="email" name="email" id="email"
                     value="{{ old('email') }}">
            </div>

            <div>
                Senha: <input class="form-control mb-2 w-50" type="password" name="password" id="password"
                        value="{{ old('password') }}">
            </div>

            <div class="d-flex w-25 justify-content-around">
                <button type="submit" class="btn btn-outline-success mt-2" id="buttonLogin">Entrar</button>
                {{-- <a href="" data-id_public="{{ $process->id_public }}" class="btn btn-outline-danger mt-2"
                    id="deleteButton">Deletar</a> --}}

            </div>
        </form>


    </div>





    @vite(['resources/js/app.js', 'resources/css/app.css'])

    {!! ToastMagic::scripts() !!}
    <script src="{{ asset('js/login/login.js') }}"></script>

</body>

</html>

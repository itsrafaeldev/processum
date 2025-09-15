<!DOCTYPE html>
<html lang="pt-BR">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="csrf-token" content="{{ csrf_token() }}">
    <link rel="shortcut icon" href="{{ asset('balanca.svg') }}" type="image/x-icon">

    {!! ToastMagic::styles() !!}
    <link rel="stylesheet" href="{{ asset('css/global.css') }}">
    @stack('style')

    <title>Processum - @yield('title')</title>
</head>

<body>
    <form id="logout-form" action="{{ route('logout') }}" method="POST" class="d-none">
        @csrf
    </form>
    <div class="container-sidebar">
        <ul>
            <a href="{{ route('judicial-process.list') }}" class="text-decoration-none">
                <li>Processos Judiciais</li>
            </a>
            <a href="{{ route('client.list') }}">
                <li>Clientes</li>
            </a>
            <a href="{{ route('legal-fee.list') }}">
                <li>Honorários</li>
            </a>
            <a href="#">
                <li>Acordos Judiciais</li>
            </a>
            <a href="#" onclick="event.preventDefault(); document.getElementById('logout-form').submit();">
                <li>Logout</li>
            </a>


        </ul>
    </div>

    <div class="container-content">
        @yield('content')
    </div>





    @vite(['resources/js/app.js', 'resources/css/app.css'])

    {!! ToastMagic::scripts() !!}


    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.10.1/jszip.min.js"></script>

    <!-- DevExtreme JS -->
    <script src="https://cdn3.devexpress.com/jslib/23.2.5/js/dx.all.js"></script>

    <!-- CSS do DevExtreme -->
    <link rel="stylesheet" href="https://cdn3.devexpress.com/jslib/23.2.5/css/dx.light.css">


    @stack('script')

</body>

</html>

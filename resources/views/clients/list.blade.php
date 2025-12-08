@extends('layouts.main')
@section('title', 'Processos Judiciais')


@section('content')
    <div class="container-fluid">
        <h1>CLIENTES</h1>
    </div>

    <div class="container-fluid">
        @foreach ($clients as $key => $value)
            <p>#{{ $key+1 }} | Nome: <a class="link_process_number"
                    href="{{ route('client.edit', $value->id_public) }}">{{ $value->name }}</a> | <a
                    href="#">Detalhes</a></p>
        @endforeach
        <a href="{{ route('client.createPF') }}" class="btn btn-outline-dark">+ Pessoa Física</a>
        <a href="{{ route('client.createPJ') }}" class="btn btn-outline-dark">+ Pessoa Jurídica</a>

    </div>



     @push('script')
        @vite(['resources/js/pages/client/list.js'])
    @endpush


@endsection

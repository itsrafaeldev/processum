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
        <a href="{{ route('client.create') }}" class="btn btn-outline-dark">Cadastrar Cliente</a>
    </div>



    @push('script')
        <script src="{{ asset('js/client/list.js') }}"></script>
    @endpush


@endsection

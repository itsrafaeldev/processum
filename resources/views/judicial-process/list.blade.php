@extends('layouts.main')
@section('title', 'Processos Judiciais')


@section('content')
    <div class="container-fluid">
        <h1>PROCESSOS JUDICIAIS</h1>
    </div>

    <div class="container-fluid">

        @foreach ($processes as $key => $value)
            <p>ID: {{ $value->id_public }} | N° Processo: <a class="link_process_number"
                    href="{{ route('judicial-process.edit', $value->id_public) }}">{{ $value->process_number }}</a> | <a
                    href="#">Detalhes</a></p>
        @endforeach
        <a href="{{ route('judicial-process.create') }}" class="btn btn-outline-dark">Registrar Processo</a>
    </div>



    @push('script')
        <script src="{{ asset('js/judicial_process/list.js') }}"></script>
    @endpush


@endsection

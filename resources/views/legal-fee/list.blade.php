@extends('layouts.main')
@section('title', 'Processos Judiciais')


@section('content')
    <div class="container-fluid">
        <h1>HONORÁRIOS</h1>
    </div>

    <div class="container-fluid">
        @foreach ($legalFees as $key => $value)
            <p>ID: {{ $value->id_public }} | N° Processo: {{ $value->judicialProcess->process_number }} </a> |
                quantia: {{$value->amount}} | <a href="{{ route('legal-fee.edit', $value->id_public) }}">Detalhes</a></p>
        @endforeach
        <a href="{{ route('legal-fee.create') }}" class="btn btn-outline-dark">Registrar Honorário</a>
    </div>



      @push('script')
        @vite(['resources/js/pages/honorarium/list.js'])
    @endpush


@endsection

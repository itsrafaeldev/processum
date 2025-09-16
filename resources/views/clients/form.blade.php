@extends('layouts.main')
@section('title', 'clientos Judiciais')

@push('style')
<style>

</style>
@endpush

@section('content')

    <div class="container-fluid">
        <h1>{{ $titleView }}</h1>
    </div>


    <div class="container-fluid">
        <form action="" class="d-flex flex-column w-50 ml-2 mb-5" id="clientForm" novalidate>
            @csrf
            @method('POST')
            @if ($errors->any())
                <pre>{{ print_r($errors->all(), true) }}</pre>
            @endif
            <div>
                <input type="hidden" name="client" id="client" data-client="{{ $client }}">
            </div>

             <div>
                Nome Completo: <input class="form-control mb-2 w-50" type="text" name="name" id="name"
                    max="255" value="{{ $client->name }}" >
                <div class="error-message" id="error-name"></div>
            </div>

            <div>
                CPF: <input class="mb-2 w-50 maskCPF form-control" type="text" name="cpf"
                    id="cpf"  max="11"
                    value="{{ $client->cpf }}"

                    >
                <div class="error-message" id="error-cpf"></div>

            </div>
            <div>
                Email: <input class="form-control mb-2 mr-2 w-25" type="email" name="email"
                    id="email" value="{{ $client->email }}" >
                <div class="error-message" id="error-email"></div>

            </div>

             <div>
                Endereço: <input class="form-control mb-2 w-50" type="text" name="address" id="address"
                    value="{{ $client->address }}" >
                <div class="error-message" id="error-address"></div>
            </div>

             <div>
                Celular: <input class="form-control maskMobile mb-2 w-50" type="text" name="mobile" id="mobile"
                    max="11" value="{{ $client->mobile }}" >
                <div class="error-message" id="error-mobile"></div>
            </div>

            <div>
                Telefone: <input class="form-control maskFixedPhone mb-2 w-50" type="text" name="phone" id="phone"
                    max="10" value="{{ $client->phone }}" >
                <div class="error-message" id="error-phone"></div>
            </div>


            <div class="d-flex w-25 justify-content-around">
                <a href="#" class="btn btn-outline-success mt-2" id="saveButton">Salvar</a>
                <a href="" data-id_public="{{ $client->id_public }}" class="btn btn-outline-danger mt-2"
                    id="deleteButton">Deletar</a>

            </div>
        </form>

        <div class="w-25">
            <a href="{{ route('client.list') }}" class="btn btn-secondary ">Voltar</a>
        </div>

    </div>


    @push('script')
        <script src="{{ asset('js/client/form.js') }}"></script>
    @endpush




@endsection

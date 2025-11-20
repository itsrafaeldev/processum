@extends('layouts.main')
@section('title', 'Processos Judiciais')

@push('style')
<style>

</style>
@endpush

@section('content')

    <div class="container-fluid">
        <h1>{{ $titleView }}</h1>
    </div>

    <div class="container-fluid">
        <form action="" class="d-flex flex-column w-50 ml-2 mb-5" id="processForm" novalidate>
            @csrf
            @method('POST')
            @if ($errors->any())
                <pre>{{ print_r($errors->all(), true) }}</pre>
            @endif
            <div>
                <input type="hidden" name="process" id="process" data-process="{{ $process }}">
            </div>

            <div>
                N° do Processo: <input class="mb-2 w-50 maskProcessNumber form-control" type="text" name="process_number"
                    id="process_number" placeholder="0000000-00.0000.0.00.0000"
                    value="{{ $process->process_number }}"

                    >
                <div class="error-message" id="error-process-number"></div>

            </div>
            <div>
                Data de abertura: <input class="form-control mb-2 mr-2 w-25" type="date" name="initial_date"
                    id="initial_date" value="{{ $process->initial_date }}" >
                <div class="error-message" id="error-initial-date"></div>

            </div>

            <div>
                {{-- Reclamante: <input class="form-control mb-2 w-50" type="text" name="claimant" id="claimant"
                    max="255" value="{{ $process->claimant }}" > --}}
            </div>

            <div>
                Reclamante: <select class="form-control select2 w-50" name="client_id[]" id="client_id"   data-selected-clients='@json($clients)'>

                </select>
                <div class="error-message" id="error-client_id"></div>

            </div>

            <div>
                Reclamada: <input class="form-control mb-2 w-50" type="text" name="respondent" id="respondent"
                    max="255" value="{{ $process->respondent }}" >
                <div class="error-message" id="error-respondent"></div>
            </div>

            <div>
                Natureza da ação: <select class="form-control mb-2 w-25" name="select_nature_action"
                    id="select_nature_action">
                    <option value="">Selecione uma natureza...</option>

                    @foreach ($nature_actions as $key => $value)
                        <option value="{{ $value->id }}">{{ $value->nature }}</option>
                    @endforeach
                </select>
                <div class="error-message" id="error-nature"></div>

            </div>

            <div>
                Ação judicial: <select class="form-control mb-2 w-25" name="select_judicial_action"
                    id="select_judicial_action" data-actions="{{ $actions }}">
                    <option value="">Selecione uma ação...</option>
                </select>
                <div class="error-message" id="error-judicial"></div>

            </div>

            <div>
                Arquivado? <input class=" mb-2" type="checkbox" name="is_archived" id="is_archived"
                    value="{{ $process->is_archived }}">
            </div>

            <div>Observações:
                <textarea class="form-control" name="description" id="description" style="width: 400px;">{{ $process->description }}</textarea>
                <div><span id="charCount">Caracteres: 0/500</span></div>
            </div>
            <div class="d-flex w-25 justify-content-around">
                <a href="#" class="btn btn-outline-success mt-2" id="saveButton">Salvar</a>
                <a href="" data-id_public="{{ $process->id_public }}" class="btn btn-outline-danger mt-2"
                    id="deleteButton">Deletar</a>

            </div>
        </form>

        <div class="w-25">
            <a href="{{ route('judicial-process.list') }}" class="btn btn-secondary ">Voltar</a>
        </div>

    </div>


    @push('script')
        <script src="{{ asset('js/judicial_process/form.js') }}"></script>
    @endpush




@endsection

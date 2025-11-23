@extends('layouts.main')
@section('title', 'Processos Judiciais')

@push('style')
<style>
    .choices{
        width: 50%;
    }
</style>
@endpush

@section('content')

    <div class="container-fluid">
        <h1>{{ $titleView }}</h1>
    </div>


    <div class="container-fluid">
        <form action="" class="d-flex flex-column w-50 ml-2 mb-5" id="legalFeeForm" novalidate>
            @csrf
            @method('POST')
            @if ($errors->any())
                <pre>{{ print_r($errors->all(), true) }}</pre>
            @endif
            <div>
                <input type="hidden" name="legalFee" id="legalFee" data-legal-fee='@json($legalFee->toArray())'>
            </div>

            <div class="form-control mb-2 w-50">
                Status do Honorário: {{ $statusHonorarium }}
            </div>

            <div>

                N° do Processo:
                <select class="form-control w-50" name="process_number_id" id="process_number_id" data-process='@json($process_number)'>

                </select>
                <div class="error-message" id="error-process-number"></div>

            </div>

            <div>Cliente(s):
                <select class="form-control w-50" name="client_id[]" id="client_id" data-selected-clients='@json($legalFee->clients)'>

                </select>
                <div class="error-message" id="error-client_id"></div>

            </div>

            <div>
                Honorário: <input class="mb-2 w-50 form-control " type="text" name="amount"
                    id="amount" placeholder="R$ 0,00"
                    value="{{ $legalFee->amount }}" >
                <div class="error-message" id="error-legalFee-amount"></div>
            </div>

            <div>
               Quantidade de Parcelas: <input class="mb-2 w-25 form-control" type="number" name="quantity_installment"
                    id="quantity_installment"
                    value="{{ $legalFee->quantity_installment ?? 1 }}" >
                <div class="error-message" id="error-quantity-installment"></div>
            </div>

            <div id="due_date_container">
                Data de vencimento: <input class="form-control mb-2 mr-2 w-25" type="date" name="due_date"
                    id="due_date" value="{{ date('Y-m-d') }}" >
                <div class="error-message" id="error-due-date"></div>
            </div>

            <div>Parcelas:
                <div id="tblInstallmentsLegalFee" data-installments='@json($legalFee->installments)'></div>
            </div>
            <div>Observações:
                <textarea class="form-control" name="note" id="note" style="width: 400px;">{{ $legalFee->note }}</textarea>
                <div><span id="charCount">Caracteres: 0/500</span></div>
            </div>

            <div class="d-flex w-25 justify-content-around">
                <a href="#" class="btn btn-outline-success mt-2" id="saveButton">Salvar</a>
                <a href="" data-id_public="{{ $legalFee->id_public }}" class="btn btn-outline-danger mt-2" id="deleteButton">Deletar</a>
                <button class="btn btn-outline-info mt-2" id="enterInstallments">Lançar Parcelas</a>


            </div>
        </form>

        <div class="w-25">
            <a href="{{ route('legal-fee.list') }}" class="btn btn-secondary">Voltar</a>
        </div>

    </div>


    @push('script')
        @vite(['resources/js/pages/honorarium/form.js'])
    @endpush

@endsection

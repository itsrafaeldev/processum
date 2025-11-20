<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;
use Illuminate\Contracts\Validation\Validator;
use Illuminate\Http\Exceptions\HttpResponseException;
use Illuminate\Validation\Rule;

class LegalFeeRequest extends FormRequest
{
    /**
     * Determine if the user is authorized to make this request.
     */
    public function authorize(): bool
    {
        return true;
    }

    /**
     * Get the validation rules that apply to the request.
     *
     * @return array<string, \Illuminate\Contracts\Validation\ValidationRule|array<mixed>|string>
     */
    public function rules(): array
    {
        return [

            'note' => ['max:500'],
            'quantity_installment' => ['required'],
            'amount' => ['required'],
            'client_id' => ['required'],
            'due_date' => ['required', Rule::date()->afterOrEqual(today())],
            'process_number_id' => ['required'],
        ];
    }

    public function messages(){
        return [
            'process_number_id.required' => 'Informe o N° do Processo!',

            'due_date.required' => 'Informe a data de vencimento!',
            'due_date.after_or_equal' => 'Não é permitido datas de vencimento anteriores à data de hoje!',
            'due_date.date' => 'Informe uma data válida.',

            'amount.required' => 'Informe o valor do Honorário!',

            'client_id.required' => 'Informe o Reclamante!',

            'quantity_installment.required' => 'Informe a quantidade de parcelas!',


            'note.max' => 'Capacidade máxima de caracteres do campo de observação atingida! Máximo: :max caracteres.'

        ];
    }
    protected function failedValidation(Validator $validator)
    {

        throw new HttpResponseException(
            response()->json([
                'success' => false,
                'errors' => $validator->errors()->all(),
            ], 422)
        );
    }
}

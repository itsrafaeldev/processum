<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;
use Illuminate\Contracts\Validation\Validator;
use Illuminate\Http\Exceptions\HttpResponseException;
use Illuminate\Validation\Rule;

class ClientIndividualRequest extends FormRequest
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
            'phone' => ['max:10'],
            'mobile' => ['required', 'max:11'],
            'address' => ['required'],
            'email' => ['required', 'email'],
            'cpf' => ['required', 'max:11'],
            'name' => ['required'],

        ];
    }

    public function messages()
    {
        return [
            'name.required' => 'Informe um Nome!',

            'cpf.required'=> 'Informe um CPF!',
            'cpf.max'=> 'O CPF informado ultrapassa o limite de :max caracteres!',

            'email.required' => 'Informe um Email!',
            'email.email' => 'Informe um Email válido!',

            'address.required' => 'Informe um Endereço!',

            'mobile.required' => 'Informe um Número de Celular!',
            'mobile.max' => 'O Número de Celular informado ultrapassa o limite de :max caracteres!',

            'phone.max' => 'O Telefone informado ultrapassa o limite de :max caracteres!',




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

<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;
use Illuminate\Contracts\Validation\Validator;
use Illuminate\Http\Exceptions\HttpResponseException;
use Illuminate\Validation\Rule;

class JudicialProcessRequest extends FormRequest
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

            'description' => ['max:500'],
            'judicial_action_id' => ['required', 'not_in:0', 'exists:judicials_actions,id'],
            'nature_action_id' => ['required', 'not_in:0', 'exists:nature_actions,id'],
            'respondent' => ['required', 'string'],
            'claimant' => ['required', 'string'],
            'initial_date' => ['required', Rule::date()->beforeOrEqual(today())],
            'process_number' => ['required', 'max:20', 'min:20'],
        ];
    }

    public function messages(){
        return [
            'process_number.required' => 'Informe o N° do Processo!',
            'process_number.max' => 'O campo N° do Processo ultrapassou o tamanho máximo de :max! dígitos',
            'process_number.min' => 'O campo N° do Processo requer :min dígitos!',

            'initial_date.required' => 'Informe a data de inicio do processo!',
            'initial_date.before_or_equal' => 'Não é permitido datas posteriores à data de hoje!',
            'initial_date.date' => 'Informe uma data válida.',

            'claimant.required' => 'Informe o nome do Reclamante!',

            'respondent.required' => 'Informe o nome do Reclamado!',

            'nature_action_id.required' => 'Selecione uma natureza da ação!',
            'nature_action_id.not_in' => 'Selecione uma natureza da ação!',
            'nature_action_id.exists' => 'A natureza selecionada é inválida!',

            'judicial_action_id.required' => 'Selecione uma ação judicial!',
            'judicial_action_id.not_in' => 'Selecione uma ação judicial!',
            'judicial_action_id.exists' => 'A ação judicial selecionada é inválida!',

            'description.max' => 'Capacidade máxima de caracteres do campo de observação atingida! Máximo: :max caracteres.'

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

<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Support\Str;


class entityIndividual extends Model
{

     /** @use HasFactory<\Database\Factories\EntityIndividualFactory> */
    use HasFactory;
    protected $table = 'entitiesIndividual';
    protected $fillable = [
        'name',
        'cpf',
        'rg',
        'email',
        'mobile',
        'phone',
        'address'
    ];

    /* public function processes()
    {
        return $this->belongsToMany(JudicialProcess::class, 'judicial_process_client', 'client_id', 'judicial_process_id');
    }

    public function legalFees()
    {
        return $this->belongsToMany(LegalFee::class, 'legal_fee_client', 'client_id', 'legal_fee_id');
    } */
}

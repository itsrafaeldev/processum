<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use App\Models\{User, Settlement, LegalFee, NatureAction};
class JudicialProcess extends Model
{
    /** @use HasFactory<\Database\Factories\JudicialProcessFactory> */
    use HasFactory;
    // Adicionar coluna competencia
    protected $fillable = [
        'process_number',
        'initial_date',
        'claimant',
        'respondent',
        'description',
        'nature_action_id',
        'judicial_action_id',
        'is_archived',
    ];

    public $timestamps = true;


    
    public function settlement()
    {
        return $this->hasMany(Settlement::class, 'judicial_process_id', 'id');
    }
    public function legalFee()
    {
        return $this->hasMany(LegalFee::class,  'judicial_process_id','id');
    }


}

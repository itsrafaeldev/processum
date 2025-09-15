<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use App\Models\{User, Settlement, LegalFee, NatureAction};
use Illuminate\Support\Str;
use App\Models\Scopes\UserScope;


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
        'user_id'
    ];

    public $timestamps = true;

    protected static function booted()
    {
        static::creating(function ($model) {
            if (!$model->id_public) {
                $model->id_public = (string) Str::uuid();
            }
        });
        static::addGlobalScope(new UserScope);

    }

    // Usa o UUID na rota em vez do ID
    public function getRouteKeyName()
    {
        return 'id_public';
    }

    public function settlement()
    {
        return $this->hasMany(Settlement::class, 'judicial_process_id', 'id');
    }
    public function legalFee()
    {
        return $this->hasMany(LegalFee::class,  'judicial_process_id','id');
    }

    public function user()
    {
        return $this->belongsToMany(User::class, 'judicial_process_user')
            ->withPivot('access_level');
    }

    public function clients()
    {
        return $this->belongsToMany(Client::class, 'judicial_process_client', 'judicial_process_id', 'client_id');
    }


}

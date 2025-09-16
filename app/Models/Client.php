<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use App\Models\{JudicialProcess};
use Illuminate\Support\Str;
use App\Models\Scopes\UserScope;


class Client extends Model
{
    /** @use HasFactory<\Database\Factories\ClientFactory> */
    use HasFactory;
    // Adicionar coluna competencia
    protected $table = 'clients';

    protected $fillable = [
        'name',
        'cpf',
        'email',
        'mobile',
        'phone',
        'address'
    ];

    public $timestamps = true;

    protected static function booted()
    {
        static::creating(function ($model) {
            if (!$model->id_public) {
                $model->id_public = (string) Str::uuid();
            }
        });
        // static::addGlobalScope(new UserScope);

    }

    public function getRouteKeyName()
    {
        return 'id_public';
    }

    public function processes()
    {
        return $this->belongsToMany(JudicialProcess::class, 'judicial_process_client', 'client_id', 'judicial_process_id');
    }




}

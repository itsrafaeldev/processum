<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use App\Models\{JudicialProcess};
use Illuminate\Support\Str;
use App\Models\Scopes\LawyerScope;


class Client extends Model
{
    /** @use HasFactory<\Database\Factories\ClientFactory> */
    use HasFactory;
    protected $table = 'clients';

    protected $fillable = [
        'entity_id',
        'lawyer_id'
    ];

    public $timestamps = true;

    protected static function booted()
    {
        static::addGlobalScope('withRelations', function ($query) {
            $query->with([
                'entity',
                'entity.entityIndividual',
               // 'entity.entityCompany',
            ]);
        });
        static::addGlobalScope(new LawyerScope);
    }

    public function entity()
    {
        return $this->belongsTo(Entity::class);
    }


    /* public function processes()
    {
        return $this->belongsToMany(JudicialProcess::class, 'judicial_process_client', 'client_id', 'judicial_process_id');
    }

    public function legalFees()
    {
        return $this->belongsToMany(LegalFee::class, 'legal_fee_client', 'client_id', 'legal_fee_id');
    } */





}

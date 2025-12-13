<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use App\Models\Scopes\UserScope;
use Illuminate\Support\Str;



class LegalFee extends Model
{

    /** @use HasFactory<\Database\Factories\LegalFeeFactory> */
    use HasFactory;
    protected $fillable = [
        'amount',
        'quantity_installment',
        'judicial_process_id',
        'status_payment_id',
        'note',
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

     public function getRouteKeyName()
    {
        return 'id_public';
    }



    public function judicialProcess()
    {
        return $this->belongsTo(JudicialProcess::class, 'judicial_process_id', 'id');
    }
    // public function user()
    // {
    //     return $this->belongsToMany(User::class, 'judicial_process_user')
    //         ->withPivot('access_level');
    // }

    public function entity()
    {
        return $this->belongsToMany(Entity::class, 'legal_fee_entity', 'legal_fee_id', 'entity_id');
    }

    public function installments()
    {
        return $this->hasMany(InstallmentLegalFee::class, 'legal_fee_id', 'id');
    }

    public function statusPayment(){
        return $this->belongsTo(StatusPayment::class, 'status_payment_id', 'id');
    }


}

<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use App\Models\Scopes\UserScope;
use Illuminate\Support\Str;



class InstallmentLegalFee extends Model
{

    /** @use HasFactory<\Database\Factories\LegalFeeFactory> */
    use HasFactory;

    protected $table = 'installments_legal_fees';

    protected $fillable = [
        'current_installment',
        'status_payment_id',
        'payment_date',
        'due_date',
        'note',
        'legal_fee_id',
        'value_installment',
        'client_id'
    ];
    public $timestamps = true;

    protected static function booted()
    {
        static::creating(function ($model) {
            if (!$model->id_public) {
                $model->id_public = (string) Str::uuid();
            }
        });

    }

    public function client()
    {
        return $this->belongsTo(Client::class);
    }

    public function statusPayment(){
        return $this->belongsTo(StatusPayment::class);
    }



}

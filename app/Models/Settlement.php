<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Factories\HasFactory;


class Settlement extends Model
{

    /** @use HasFactory<\Database\Factories\LegalFeeFactory> */
    use HasFactory;
    protected $fillable = [
        'amount',
        'quantity_installment',
        'current_installment',
        'judicial_process_id',
        'status_payment_id',
        'payment_date',
        'due_date',
        'competence',
        'note',
        'user_id'
    ];
    public $timestamps = true;

    public function judicialProcess()
    {
        return $this->belongsTo(JudicialProcess::class, 'judicial_process_id', 'id');
    }


}

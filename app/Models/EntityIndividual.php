<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Support\Str;


class EntityIndividual extends Model
{

     /** @use HasFactory<\Database\Factories\EntityIndividualFactory> */
    use HasFactory;
    protected $table = 'entities_individual';
    protected $fillable = [
        'name',
        'cpf',
        'rg',
        'email',
        'mobile',
        'phone',
        'address'
    ];

    public $timestamps = true;

}

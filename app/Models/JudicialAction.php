<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Factories\HasFactory;


class JudicialAction extends Model
{

    /** @use HasFactory<\Database\Factories\NatureActionFactory> */
    use HasFactory;

    protected $table = 'judicials_actions';

    public $timestamps = true;



}

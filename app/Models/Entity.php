<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Support\Str;

class Entity extends Model
{

     protected $fillable = [
        'id_public',
        'entity_type',
        'status_id'
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

      public function getRouteKeyName()
    {
        return 'id_public';
    }

     public function entityIndividual()
    {
        return $this->hasOne(EntityIndividual::class);
    }

    public function entityCompany()
    {
        return $this->hasOne(EntityCompany::class);
    }

    public function client()
    {
        return $this->hasOne(Client::class);
    }

  /*   public function supplier()
    {
        return $this->hasOne(Supplier::class);
    }

    public function enterprise()
    {
        return $this->hasOne(Enterprise::class);
    }

    public function roles()
    {
        return $this->belongsToMany(Role::class, 'entities_roles');
    } */
}

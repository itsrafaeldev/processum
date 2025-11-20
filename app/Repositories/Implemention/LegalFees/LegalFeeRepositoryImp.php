<?php

namespace App\Repositories\Implemention\LegalFees;

use App\Models\LegalFee;

use App\Repositories\Interfaces\LegalFees\LegalFeeRepositoryInterface;

class LegalFeeRepositoryImp implements LegalFeeRepositoryInterface
{
    public function all(array $with = [])
    {
        return LegalFee::with($with)->get();
    }

    public function paginate(int $perPage = 15, array $with = [])
    {
        return LegalFee::with($with)->paginate($perPage);
    }

    public function find(string $id, array $with = [])
    {
        return LegalFee::with($with)->where('id_public', $id)->first();
    }

    public function findOrFail(string $id, array $with = [])
    {
        return LegalFee::with($with)->where('id_public', $id)->firstOrFail();
    }

    public function findBy(string $field, $value, array $with = [])
    {
        return LegalFee::with($with)->where($field, $value)->get();
    }

    public function create(array $data)
    {
        return LegalFee::create($data);
    }

    public function update(string $id, array $data)
    {
        $legalFee = $this->findOrFail($id);
        $legalFee->update($data);

        return $legalFee;
    }

    public function delete(string $id)
    {
        $legalFee = $this->findOrFail($id);
        return $legalFee->delete();
    }

    public function firstOrCreate(array $attributes, array $values = [])
    {
        return LegalFee::firstOrCreate($attributes, $values);
    }
}

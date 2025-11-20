<?php

namespace App\Repositories\Implemention\Clients;

use App\Models\Client;

use App\Repositories\Interfaces\Clients\ClientRepositoryInterface;

class ClientRepositoryImp implements ClientRepositoryInterface
{

    public function all(array $with = [])
    {
        return Client::all($with);
    }


    public function paginate(int $perPage = 15, array $with = [])
    {
    }

    public function find(string $id)
    {
    }

    public function findOrFail(string $id)
    {
    }

    public function findBy(string $field, $value)
    {
    }

    public function create(array $data)
    {
    }

    public function update(string $id, array $data)
    {

    }

    public function delete(string $id)
    {

    }

    public function firstOrCreate(array $attributes, array $values = [])
    {
    }
}

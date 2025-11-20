<?php
namespace App\Services;


class BaseService
{
    public function __construct()
    {
    }

    public function all(array $with = [])
    {
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

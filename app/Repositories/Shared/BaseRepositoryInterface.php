<?php

namespace App\Repositories\Shared;


interface BaseRepositoryInterface
{
    public function all(array $with = []);

    public function paginate(int $perPage = 15, array $with = []);

    public function find(string $id);

    public function findOrFail(string $id);
}

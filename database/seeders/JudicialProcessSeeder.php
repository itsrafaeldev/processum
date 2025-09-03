<?php

namespace Database\Seeders;

use App\Models\JudicialProcess;
use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;

class JudicialProcessSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        JudicialProcess::factory(5)->create();
    }
}

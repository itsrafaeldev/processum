<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Run the migrations.
     */
    public function up(): void
    {
        DB::statement("
        ALTER TABLE IF EXISTS clients
        DROP CONSTRAINT IF EXISTS clients_id_public_key;
    ");
        DB::statement('ALTER TABLE clients DROP COLUMN id_public;');

    }


};

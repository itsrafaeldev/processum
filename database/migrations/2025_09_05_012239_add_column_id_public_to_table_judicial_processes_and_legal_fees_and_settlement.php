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
        DB::statement('ALTER TABLE judicial_processes ADD COLUMN id_public UUID UNIQUE NOT NULL');
        DB::statement('ALTER TABLE legal_fees ADD COLUMN id_public UUID UNIQUE NOT NULL');
        DB::statement('ALTER TABLE settlement ADD COLUMN id_public UUID UNIQUE NOT NULL');

    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        DB::statement(query: 'ALTER TABLE settlement DROP id_public;');
        DB::statement(query: 'ALTER TABLE legal_fees DROP id_public;');
        DB::statement(query: 'ALTER TABLE judicial_processes DROP id_public;');

    }
};

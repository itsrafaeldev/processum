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

        DB::statement("INSERT INTO status_entities (description) VALUES ('A');");
        DB::statement("INSERT INTO status_entities (description) VALUES ('D');");
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
    }
};

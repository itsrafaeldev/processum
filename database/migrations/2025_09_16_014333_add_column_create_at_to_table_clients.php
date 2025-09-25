<?php

use Illuminate\Database\Migrations\Migration;


return new class extends Migration
{
    /**
     * Run the migrations.
     */
    public function up(): void
    {
        DB::statement('ALTER TABLE clients ADD COLUMN CREATED_AT TIMESTAMP WITHOUT TIME ZONE DEFAULT now() NOT NULL');
        DB::statement('ALTER TABLE clients ADD COLUMN UPDATED_AT TIMESTAMP WITHOUT TIME ZONE DEFAULT now() NOT NULL');

    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        DB::statement(query: 'ALTER TABLE clients DROP UPDATED_AT;');
        DB::statement(query: 'ALTER TABLE clients DROP CREATED_AT;');

    }
};

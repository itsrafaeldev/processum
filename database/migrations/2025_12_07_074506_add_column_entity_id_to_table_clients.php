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
         DB::statement(
            'ALTER TABLE clients
                        ADD COLUMN entity_id BIGSERIAL not null;'
        );
         DB::statement("
            ALTER TABLE clients
            ADD CONSTRAINT fk_client_entity
            FOREIGN KEY(entity_id)
            REFERENCES entities(id)
            ON UPDATE CASCADE
            ON DELETE CASCADE;
        ");
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        DB::statement("
            ALTER TABLE clients
            DROP CONSTRAINT IF EXISTS fk_client_entity;
        ");
    }
};

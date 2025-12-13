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
        DB::statement("ALTER TABLE legal_fee_client RENAME TO legal_fee_entity;");
        DB::statement("ALTER TABLE legal_fee_entity DROP CONSTRAINT fk_client;");
        DB::statement("ALTER TABLE legal_fee_entity RENAME COLUMN client_id TO entity_id;");
        DB::statement("
            ALTER TABLE legal_fee_entity
            ADD CONSTRAINT fk_entity_legal_fee
            FOREIGN KEY (entity_id)
            REFERENCES entities(id)
            ON DELETE CASCADE;
        ");

        DB::statement("ALTER TABLE judicial_process_client RENAME TO judicial_process_entity;");
        DB::statement("ALTER TABLE judicial_process_entity DROP CONSTRAINT fk_client;");
        DB::statement("ALTER TABLE judicial_process_entity RENAME COLUMN client_id TO entity_id;");
        DB::statement("
            ALTER TABLE judicial_process_entity
            ADD CONSTRAINT fk_judicial_process_entity
            FOREIGN KEY (entity_id)
            REFERENCES entities(id)
            ON DELETE CASCADE;
        ");




    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        //
    }
};

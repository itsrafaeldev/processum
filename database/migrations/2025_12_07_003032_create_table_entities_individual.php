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
            CREATE TABLE entities_individual (
                id BIGSERIAL PRIMARY KEY,
                entity_id BIGSERIAL NOT NULL,
                cpf VARCHAR(14),
                rg VARCHAR(20),
                email VARCHAR(255),
                mobile VARCHAR(50),
                phone VARCHAR(50),
                birth_date DATE,
                CREATED_AT TIMESTAMP WITHOUT TIME ZONE DEFAULT now() NOT NULL,
                UPDATED_AT TIMESTAMP WITHOUT TIME ZONE DEFAULT now() NOT NULL,
                CONSTRAINT fk_entity_individual
                    FOREIGN KEY(entity_id)
                    REFERENCES entities(id)
                    ON UPDATE CASCADE
                    ON DELETE CASCADE
            );
        ");

    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
{
    DB::statement("
        ALTER TABLE IF EXISTS entities_individual
        DROP CONSTRAINT IF EXISTS fk_entity_individual;
    ");

    DB::statement('DROP TABLE IF EXISTS entities_individual CASCADE;');
}
};

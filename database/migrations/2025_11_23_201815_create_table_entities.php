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
        CREATE TABLE entities (
            id BIGSERIAL PRIMARY KEY,
            entity_type_id INTEGER NOT NULL,
            status_id INTEGER NOT NULL,
            email VARCHAR(255),
            mobile VARCHAR(50),
            phone VARCHAR(50),
            created_at TIMESTAMP WITHOUT TIME ZONE DEFAULT now() NOT NULL,
            updated_at TIMESTAMP WITHOUT TIME ZONE DEFAULT now() NOT NULL,

            CONSTRAINT fk_entities_entity_type
                FOREIGN KEY (entity_type_id)
                REFERENCES entity_types(id)
                ON UPDATE CASCADE
                ON DELETE RESTRICT,

            CONSTRAINT fk_entities_status
                FOREIGN KEY (status_id)
                REFERENCES status_entities(id)
                ON UPDATE CASCADE
                ON DELETE RESTRICT
        );
    ");
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('entities');
    }
};

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
        // 2) tabela pivot (map) entre entities e entity_roles
        DB::statement("
            CREATE TABLE entities_roles_map (
                id BIGSERIAL PRIMARY KEY,
                entity_id BIGINT NOT NULL,
                role_id INTEGER NOT NULL,
                assigned_at TIMESTAMP WITHOUT TIME ZONE DEFAULT now() NOT NULL,
                assigned_by BIGINT, -- opcional: quem fez a atribuição (user_id)
                notes TEXT,
                created_at TIMESTAMP WITHOUT TIME ZONE DEFAULT now() NOT NULL,
                updated_at TIMESTAMP WITHOUT TIME ZONE DEFAULT now() NOT NULL,

                CONSTRAINT fk_entities_roles_map_entity
                    FOREIGN KEY (entity_id)
                    REFERENCES entities(id)
                    ON UPDATE CASCADE
                    ON DELETE CASCADE,

                CONSTRAINT fk_entities_roles_map
                    FOREIGN KEY (role_id)
                    REFERENCES entities_roles(id)
                    ON UPDATE CASCADE
                    ON DELETE RESTRICT,

                CONSTRAINT unique_entity_role UNIQUE (entity_id, role_id)
            );
        ");

    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('entities_roles_map');
    }
};

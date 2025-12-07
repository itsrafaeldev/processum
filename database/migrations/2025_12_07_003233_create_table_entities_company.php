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
                CREATE TABLE entities_company (
                    id BIGSERIAL PRIMARY KEY,
                    entity_id BIGINT NOT NULL,
                    cnpj VARCHAR(20),
                    ie VARCHAR(30),
                    corporate_name VARCHAR(200),
                    trade_name VARCHAR(200),
                    email VARCHAR(255),
                    mobile VARCHAR(50),
                    phone VARCHAR(50),
                    CREATED_AT TIMESTAMP WITHOUT TIME ZONE DEFAULT now() NOT NULL,
                    UPDATED_AT TIMESTAMP WITHOUT TIME ZONE DEFAULT now() NOT NULL,
                    CONSTRAINT fk_entity_company
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
        Schema::dropIfExists('entities_company');
    }
};

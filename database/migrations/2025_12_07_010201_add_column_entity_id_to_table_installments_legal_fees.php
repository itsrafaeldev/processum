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
            'ALTER TABLE legal_fees_installments
                        ADD COLUMN entity_id BIGSERIAL not null;'
        );
         DB::statement("
            ALTER TABLE legal_fees_installments
            ADD CONSTRAINT fk_legal_fee_entity
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
            ALTER TABLE legal_fees_installments
            DROP CONSTRAINT IF EXISTS fk_legal_fee_entity;
        ");
    }
};

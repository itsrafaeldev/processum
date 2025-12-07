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
            'CREATE TABLE legal_fees(
            ID INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
            AMOUNT NUMERIC(10, 2) NOT NULL,
            QUANTITY_INSTALLMENT INTEGER NOT NULL,
            CURRENT_INSTALLMENT INTEGER NOT NULL,
            JUDICIAL_PROCESS_ID INTEGER NOT NULL,
            VALUE_INSTALLMENT NUMERIC(10, 2) GENERATED ALWAYS AS (AMOUNT / NULLIF(QUANTITY_INSTALLMENT, 0)) STORED,
            status_payment_id INTEGER NOT NULL,
            payment_date DATE,
            due_date DATE,
            competence VARCHAR(7) NOT NULL,
            note varchar(255),
            CREATED_AT TIMESTAMP WITHOUT TIME ZONE DEFAULT now() NOT NULL,
            UPDATED_AT TIMESTAMP WITHOUT TIME ZONE DEFAULT now() NOT NULL
            );'
        );

        DB::statement('ALTER TABLE legal_fees
            ADD CONSTRAINT fk_judicial_process
            FOREIGN KEY (JUDICIAL_PROCESS_ID) REFERENCES JUDICIAL_PROCESSES(id)
            ON DELETE CASCADE;');

        DB::statement('ALTER TABLE legal_fees
            ADD CONSTRAINT fk_status_payment
            FOREIGN KEY (status_payment_id) REFERENCES status_payment(id)
            ON DELETE CASCADE;');
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
{
    // Remover FK na tabela pivot que referencia legal_fees
    DB::statement('ALTER TABLE legal_fee_entity DROP CONSTRAINT fk_legal_fee_id;');

    // dropar pivot
    DB::statement('DROP TABLE IF EXISTS legal_fee_entity CASCADE;');

    // Remover FK locais
    DB::statement('ALTER TABLE legal_fees DROP CONSTRAINT fk_status_payment;');
    DB::statement('ALTER TABLE legal_fees DROP CONSTRAINT fk_judicial_process;');

    // Agora sim pode dropar
    DB::statement('DROP TABLE IF EXISTS legal_fees CASCADE;');
}
};

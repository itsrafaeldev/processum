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
            'CREATE TABLE INSTALLMENTS_SETTLEMENT (
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
            CREATED_AT TIMESTAMP WITHOUT TIME ZONE DEFAULT now() NOT NULL,
            UPDATED_AT TIMESTAMP WITHOUT TIME ZONE DEFAULT now() NOT NULL
            );'
        );

        DB::statement('ALTER TABLE INSTALLMENTS_SETTLEMENT
            ADD CONSTRAINT fk_judicial_process
            FOREIGN KEY (JUDICIAL_PROCESS_ID) REFERENCES JUDICIAL_PROCESSES(id)
            ON DELETE CASCADE;');

        DB::statement('ALTER TABLE INSTALLMENTS_SETTLEMENT
            ADD CONSTRAINT fk_status_payment
            FOREIGN KEY (status_payment_id) REFERENCES status_payment(id)
            ON DELETE CASCADE;');



    }
    public function down(): void
    {
        

    }
};

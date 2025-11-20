<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
   public function up(): void
    {
        DB::statement(
            'CREATE TABLE installments_legal_fees(
            ID INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
            ID_PUBLIC UUID UNIQUE NOT NULL,
            QUANTITY_INSTALLMENT INTEGER NOT NULL,
            CURRENT_INSTALLMENT INTEGER NOT NULL,
            LEGAL_FEE_ID INTEGER NOT NULL,
            VALUE_INSTALLMENT NUMERIC NOT NULL,
            status_payment_id INTEGER NOT NULL,
            payment_date DATE,
            due_date DATE,
            note varchar(255),
            CREATED_AT TIMESTAMP WITHOUT TIME ZONE DEFAULT now() NOT NULL,
            UPDATED_AT TIMESTAMP WITHOUT TIME ZONE DEFAULT now() NOT NULL
            );'
        );

        DB::statement('ALTER TABLE installments_legal_fees
            ADD CONSTRAINT fk_status_payment
            FOREIGN KEY (status_payment_id) REFERENCES status_payment(id)
            ON DELETE CASCADE;');
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        DB::statement('ALTER TABLE installments_legal_fees DROP CONSTRAINT fk_status_payment;');
        Schema::dropIfExists('installments_legal_fees');
    }
};

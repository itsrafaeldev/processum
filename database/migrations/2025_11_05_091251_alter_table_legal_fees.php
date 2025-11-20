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
            ALTER TABLE legal_fees
            DROP COLUMN CURRENT_INSTALLMENT,
            DROP COLUMN VALUE_INSTALLMENT,
            DROP COLUMN payment_date,
            DROP COLUMN due_date;
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

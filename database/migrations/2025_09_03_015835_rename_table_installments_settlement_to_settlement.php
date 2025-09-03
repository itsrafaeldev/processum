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
        DB::statement("ALTER TABLE INSTALLMENTS_SETTLEMENT RENAME TO SETTLEMENT;");
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        DB::statement('ALTER TABLE SETTLEMENT DROP CONSTRAINT fk_status_payment;');
        DB::statement('ALTER TABLE SETTLEMENT DROP CONSTRAINT fk_judicial_process;');
        DB::statement('DROP TABLE IF EXISTS SETTLEMENT;');
    }
};

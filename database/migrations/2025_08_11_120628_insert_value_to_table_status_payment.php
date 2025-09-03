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
        DB::statement("INSERT INTO status_payment (description) VALUES ('Pago');");
        DB::statement("INSERT INTO status_payment (description) VALUES ('Pendente');");
        DB::statement("INSERT INTO status_payment (description) VALUES ('Atrasado');");
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {

    }
};

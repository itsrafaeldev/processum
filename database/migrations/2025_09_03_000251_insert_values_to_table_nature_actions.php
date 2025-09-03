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
        DB::statement("INSERT INTO nature_actions (nature) VALUES ('Direito Cível');");

        DB::statement("INSERT INTO nature_actions (nature) VALUES ('Direito Trabalhista');");

        DB::statement("INSERT INTO nature_actions (nature) VALUES ('Direito Penal');");

        DB::statement("INSERT INTO nature_actions (nature) VALUES ('Direito Tributário');");

        DB::statement("INSERT INTO nature_actions (nature) VALUES ('Direito Administrativo');");

        DB::statement("INSERT INTO nature_actions (nature) VALUES ('Família e Sucessões');");


    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {

    }
};

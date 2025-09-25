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
            'CREATE TABLE roles(
            ID INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
            ROLE VARCHAR (30) NOT NULL,
            CREATED_AT TIMESTAMP WITHOUT TIME ZONE DEFAULT now() NOT NULL,
            UPDATED_AT TIMESTAMP WITHOUT TIME ZONE DEFAULT now() NOT NULL
            );'
        );

        DB::statement("INSERT INTO roles (ROLE) VALUES ('ADVOGADO(A)');");
        DB::statement("INSERT INTO roles (ROLE) VALUES ('CLIENTE');");
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('roles');
    }
};

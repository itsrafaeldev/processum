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
        DB::statement("CREATE TABLE clients (
                                id BIGSERIAL PRIMARY KEY,
                                id_public UUID UNIQUE NOT NULL,
                                name VARCHAR(255) NOT NULL,
                                cpf VARCHAR(11) UNIQUE NOT NULL,
                                email VARCHAR(255) UNIQUE,
                                mobile VARCHAR(11),
                                phone VARCHAR(10),
                                address TEXT
                            );
                        ");
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        DB::statement("DROP TABLE IF EXISTS clients CASCADE;");
    }
};

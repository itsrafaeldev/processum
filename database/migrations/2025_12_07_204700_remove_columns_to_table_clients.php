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
        DB::statement('ALTER TABLE clients DROP COLUMN name;');
        DB::statement('ALTER TABLE clients DROP COLUMN cpf;');
        DB::statement('ALTER TABLE clients DROP COLUMN email;');
        DB::statement('ALTER TABLE clients DROP COLUMN mobile;');
        DB::statement('ALTER TABLE clients DROP COLUMN phone;');
        DB::statement('ALTER TABLE clients DROP COLUMN address;');


    }

    /**
     * Reverse the migrations.
     */
    public function down(): void {}
};

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
        DB::statement("INSERT INTO entities_roles (name, description) VALUES ('Cliente', 'Pessoa física ou jurídica que solicita serviços jurídicos');");
        DB::statement("INSERT INTO entities_roles (name, description) VALUES ('Fornecedor', 'Pessoa física ou jurídica responsável pelo fornecimento de produtos e/ou serviços');");
        DB::statement("INSERT INTO entities_roles (name, description) VALUES ('Empresa', 'Entidade jurídica cadastrada no sistema');");
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {

    }
};

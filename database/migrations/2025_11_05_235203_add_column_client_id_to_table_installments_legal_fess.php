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
            'ALTER TABLE installments_legal_fees
                        ADD COLUMN client_id INTEGER not null;'
        );
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {

    }
};

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
        DB::statement("CREATE TABLE legal_fee_client (
                                client_id INT NOT NULL,
                                legal_fee_id INT NOT NULL,
                                PRIMARY KEY (client_id, legal_fee_id),
                                CONSTRAINT fk_client
                                FOREIGN KEY (client_id) REFERENCES clients(id)
                                ON DELETE CASCADE,
                                CONSTRAINT fk_legal_fee_id
                                FOREIGN KEY (legal_fee_id) REFERENCES legal_fees(id)
                                ON DELETE CASCADE
            );
        ");
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        DB::statement("DROP TABLE IF EXISTS legal_fee_client CASCADE;");
    }
};

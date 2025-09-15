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
        DB::statement("CREATE TABLE judicial_process_client (
                                client_id INT NOT NULL,
                                judicial_process_id INT NOT NULL,
                                PRIMARY KEY (client_id, judicial_process_id),
                                CONSTRAINT fk_client
                                FOREIGN KEY (client_id) REFERENCES clients(id)
                                ON DELETE CASCADE,
                                CONSTRAINT fk_judicial_processes
                                FOREIGN KEY (judicial_process_id) REFERENCES judicial_processes(id)
                                ON DELETE CASCADE
            );
        ");
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        DB::statement("DROP TABLE IF EXISTS judicial_process_client CASCADE;");
    }
};

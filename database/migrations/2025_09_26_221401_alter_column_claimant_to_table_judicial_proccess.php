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
    //    DB::statement('ALTER TABLE judicial_processes ADD COLUMN client_id BIGINT NOT NULL');

    //    DB::statement(
    //         'ALTER TABLE judicial_processes
    //                 ADD CONSTRAINT fk_client_id
    //                 FOREIGN KEY (client_id) REFERENCES clients(id)
    //                 ON DELETE CASCADE;
    //                 '
    //     );



    //     DB::statement(query: 'ALTER TABLE judicial_processes DROP claimant;');


    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        // DB::statement('ALTER TABLE judicial_processes DROP CONSTRAINT fk_client_id;');
        // DB::statement(query: 'ALTER TABLE judicial_processes DROP client_id;');

    }
};

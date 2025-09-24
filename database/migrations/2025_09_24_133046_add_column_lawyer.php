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
            'ALTER TABLE clients
                        ADD COLUMN lawyer_id INTEGER not null;'
        );

        DB::statement(
            'ALTER TABLE clients
            ADD CONSTRAINT fk_client_lawyer
            FOREIGN KEY (lawyer_id) REFERENCES users(id)
            ON DELETE CASCADE;
            '
        );



    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        DB::statement('ALTER TABLE clients DROP CONSTRAINT fk_client_lawyer;');

        DB::statement(
            'ALTER TABLE clients
                        DROP COLUMN lawyer;'
        );
    }
};

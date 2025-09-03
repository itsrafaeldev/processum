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
            'ALTER TABLE judicial_processes
            ADD CONSTRAINT fk_judicial_action
            FOREIGN KEY (judicial_action_id) REFERENCES judicials_actions(id)
            ON DELETE CASCADE;
            '
        );
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {

    }
};

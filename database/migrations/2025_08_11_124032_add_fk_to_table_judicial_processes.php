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
            ADD CONSTRAINT fk_nature_action
            FOREIGN KEY (nature_action_id) REFERENCES nature_actions(id)
            ON DELETE CASCADE;
            ');


    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        DB::statement('ALTER TABLE judicial_processes DROP CONSTRAINT fk_nature_action;');

    }
};

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
            'CREATE TABLE judicial_processes (
            ID INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
            process_number VARCHAR(255) NOT NULL,
            initial_date DATE not null,
            claimant VARCHAR(255) NOT NULL,
            respondent VARCHAR(255) NOT NULL,
            description VARCHAR(255) NOT NULL,
            nature_action_id integer not null,
            judicial_action_id integer not null,
            is_archived boolean not null default false,
            CREATED_AT TIMESTAMP WITHOUT TIME ZONE DEFAULT now() NOT NULL,
            UPDATED_AT TIMESTAMP WITHOUT TIME ZONE DEFAULT now() NOT NULL
            );
        ');

    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        DB::statement('DROP TABLE IF EXISTS judicial_processes;');
    }
};

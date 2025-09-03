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
            "CREATE TABLE judicials_actions (
            ID INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
            judicial_action VARCHAR(150) NOT NULL,
            nature_action_id INTEGER NOT NULL,
            CREATED_AT TIMESTAMP WITHOUT TIME ZONE DEFAULT now() NOT NULL,
            UPDATED_AT TIMESTAMP WITHOUT TIME ZONE DEFAULT now() NOT NULL
            );"
        );

        DB::statement(
            'ALTER TABLE judicials_actions
            ADD CONSTRAINT fk_nature_action
            FOREIGN KEY (nature_action_id) REFERENCES nature_actions(id)
            ON DELETE CASCADE;
            '
        );
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('judicials_actions');
    }
};

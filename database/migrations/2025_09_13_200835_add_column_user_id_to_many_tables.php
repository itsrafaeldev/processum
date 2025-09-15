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
        DB::statement('ALTER TABLE judicial_processes ADD COLUMN user_id BIGINT  NOT NULL');
        DB::statement('ALTER TABLE legal_fees ADD COLUMN user_id BIGINT NOT NULL');
        DB::statement('ALTER TABLE settlement ADD COLUMN user_id BIGINT NOT NULL');

        DB::statement(
            'ALTER TABLE judicial_processes
                    ADD CONSTRAINT fk_user_id
                    FOREIGN KEY (user_id) REFERENCES users(id)
                    ON DELETE CASCADE;
                    '
        );

        DB::statement(
            'ALTER TABLE legal_fees
                    ADD CONSTRAINT fk_user_id
                    FOREIGN KEY (user_id) REFERENCES users(id)
                    ON DELETE CASCADE;
                    '
        );
        DB::statement(
            'ALTER TABLE settlement
                    ADD CONSTRAINT fk_user_id
                    FOREIGN KEY (user_id) REFERENCES users(id)
                    ON DELETE CASCADE;
                    '
        );

    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        DB::statement('ALTER TABLE settlement DROP CONSTRAINT fk_user_id;');
        DB::statement('ALTER TABLE legal_fees DROP CONSTRAINT fk_user_id;');
        DB::statement('ALTER TABLE judicial_processes DROP CONSTRAINT fk_user_id;');


        DB::statement(query: 'ALTER TABLE settlement DROP user_id;');
        DB::statement(query: 'ALTER TABLE legal_fees DROP user_id;');
        DB::statement(query: 'ALTER TABLE judicial_processes DROP user_id;');

    }
};

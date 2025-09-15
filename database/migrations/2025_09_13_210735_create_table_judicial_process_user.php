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
                "CREATE TABLE judicial_process_user (
                        id BIGSERIAL PRIMARY KEY,
                        judicial_process_id BIGINT NOT NULL,
                        user_id BIGINT NOT NULL,
                        access_level VARCHAR(50) DEFAULT 'private',
                        created_at TIMESTAMP DEFAULT now(),
                        updated_at TIMESTAMP DEFAULT now(),

                        CONSTRAINT fk_judicial_process
                            FOREIGN KEY (judicial_process_id)
                            REFERENCES judicial_processes(id)
                            ON DELETE CASCADE,

                        CONSTRAINT fk_user
                            FOREIGN KEY (user_id)
                            REFERENCES users(id)
                            ON DELETE CASCADE,

                        CONSTRAINT unique_process_user
                            UNIQUE (judicial_process_id, user_id)
                    );"
            );
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('judicial_process_user');
    }
};

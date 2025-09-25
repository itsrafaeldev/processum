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
         DB::statement("CREATE TABLE user_roles (
                                user_id INT NOT NULL,
                                role_id INT NOT NULL,
                                PRIMARY KEY (user_id, role_id),
                                CONSTRAINT fk_user
                                FOREIGN KEY (user_id) REFERENCES users(id)
                                ON DELETE CASCADE,
                                CONSTRAINT fk_role
                                FOREIGN KEY (role_id) REFERENCES roles(id)
                                ON DELETE CASCADE
            );
        ");
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        DB::statement("DROP TABLE IF EXISTS user_roles CASCADE;");
    }
};

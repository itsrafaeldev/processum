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
        DB::statement("INSERT INTO judicials_actions (judicial_action, nature_action_id) VALUES
                    -- 1. Direito Cível
                    ('Ação de indenização / Ação de reparação de danos', 1),
                    ('Ação de cobrança / Cobrança judicial', 1),
                    ('Ação de despejo', 1),
                    ('Ação de alimentos', 1),
                    ('Ação de usucapião', 1),
                    ('Ação declaratória', 1),
                    ('Ação de obrigação de fazer / não fazer', 1),
                    ('Inventário / Partilha', 1),

                    -- 2. Direito Trabalhista
                    ('Reclamação trabalhista', 2),
                    ('Ação de horas extras', 2),
                    ('Ação de adicional de insalubridade / periculosidade', 2),
                    ('Ação de equiparação salarial', 2),
                    ('Ação de rescisão contratual', 2),
                    ('Ação de indenização por acidente de trabalho', 2),

                    -- 3. Direito Penal
                    ('Ação penal pública', 3),
                    ('Ação penal privada', 3),
                    ('Queixa-crime', 3),
                    ('Medidas protetivas em casos de violência', 3),

                    -- 4. Direito Tributário
                    ('Ação de execução fiscal', 4),
                    ('Mandado de segurança contra lançamento tributário', 4),
                    ('Ação anulatória de débito fiscal', 4),

                    -- 5. Direito Administrativo
                    ('Ação de improbidade administrativa', 5),
                    ('Mandado de segurança contra ato administrativo', 5),

                    -- 6. Família e Sucessões
                    ('Divórcio / Separação judicial', 6),
                    ('Guarda e tutela', 6),
                    ('Adoção', 6),
                    ('Alimentos', 6);
                    ");

    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {

    }
};

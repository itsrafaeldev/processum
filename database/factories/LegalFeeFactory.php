<?php

namespace Database\Factories;
use Illuminate\Support\Carbon;
use Illuminate\Database\Eloquent\Factories\Factory;

/**
 * @extends \Illuminate\Database\Eloquent\Factories\Factory<\App\Models\JudicialProcess>
 */
class LegalFeeFactory extends Factory
{
    /**
     * Define the model's default state.
     *
     * @return array<string, mixed>
     */
    public function definition(): array
    {
        $amount = $this->faker->randomFloat(2, 1000, 10000);
        $quantityInstallment = $this->faker->numberBetween(1, 12);
        $currentInstallment = $this->faker->numberBetween(1, $quantityInstallment);
        $dueDate = $this->faker->dateTimeBetween('now', '+1 year');
        $paymentDate = $this->faker->boolean(70) ? $this->faker->dateTimeBetween('-6 months', 'now') : null;

        return [
            'amount' => $amount,
            'quantity_installment' => $quantityInstallment,
            'current_installment' => $currentInstallment,
            'judicial_process_id' => 8,
            // O campo VALUE_INSTALLMENT é calculado automaticamente no banco
            'status_payment_id' => $this->faker->numberBetween(1, 5),
            'payment_date' => $paymentDate,
            'due_date' => $dueDate,
            'competence' => $this->faker->date('Y-m'), // formato "YYYY-MM"
            'note' => $this->faker->optional()->sentence(),
            'created_at' => Carbon::now(),
            'updated_at' => Carbon::now(),
            'user_id' => 1,
        ];
    }
}

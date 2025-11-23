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

        return [
            'amount' => $amount,
            'quantity_installment' => $quantityInstallment,
            'judicial_process_id' => 1,
            'status_payment_id' => 2,
            'note' => $this->faker->optional()->sentence(),
            'created_at' => Carbon::now(),
            'updated_at' => Carbon::now(),
            'user_id' => 1,
        ];
    }
}

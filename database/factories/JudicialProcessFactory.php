<?php

namespace Database\Factories;

use Illuminate\Database\Eloquent\Factories\Factory;

/**
 * @extends \Illuminate\Database\Eloquent\Factories\Factory<\App\Models\JudicialProcess>
 */
class JudicialProcessFactory extends Factory
{
    /**
     * Define the model's default state.
     *
     * @return array<string, mixed>
     */
    public function definition(): array
    {
        return [
            'process_number' => $this->faker->unique()->bothify('####################'),
            'initial_date' => $this->faker->date(),
            'claimant' => $this->faker->name(),
            'respondent' => $this->faker->company(),
            'description' => $this->faker->sentence(),
            'nature_action_id' => 1,   // 1 a 6
            'judicial_action_id' => 1, // 1 a 27
            'is_archived' => false, // sempre false
            'id_public' => $this->faker->uuid(),
            'user_id' => 2,

        ];
    }
}

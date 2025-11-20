<?php

namespace App\Providers;

use Illuminate\Support\ServiceProvider;

class LegalFeeProvider extends ServiceProvider
{
    /**
     * Register services.
     */
    public function register(): void
    {
        //
    }

    /**
     * Bootstrap services.
     */
    public function boot(): void
    {
        $this->app->bind(
            \App\Repositories\Interfaces\LegalFees\LegalFeeRepositoryInterface::class,
            \App\Repositories\Implemention\LegalFees\LegalFeeRepositoryImp::class
        );
    }
}

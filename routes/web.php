<?php

use App\Http\Controllers\AuthController;
use Illuminate\Support\Facades\Route;

Route::get('/', function () {
    return redirect('login');
});


Route::middleware([
    'auth:sanctum',
    config('jetstream.auth_session'),
    'verified',
])->group(function () {
    Route::get('/dashboard', function () {
        return view('dashboard');
    })->name('dashboard');

    include __DIR__ . '/group-routes/judicial-process.php';
    include __DIR__ . '/group-routes/legal-fee.php';
    include __DIR__ . '/group-routes/client.php';


});

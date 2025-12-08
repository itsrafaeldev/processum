<?php


use App\Http\Controllers\ClientController;
use Illuminate\Support\Facades\Route;

Route::prefix('client')->group( function () {

    Route::get('/', [ClientController::class, 'list'])->name('client.list');
    Route::get('/search-clients', [ClientController::class, 'search']);


    Route::prefix('pf')->group( function () {
        Route::get('create', [ClientController::class, 'createPF'])->name('client.createPF');

        Route::get('edit/{client}', [ClientController::class, 'editPF'])->name('client.editPF');

        Route::post('save', [ClientController::class, 'savePF'])->name('client.savePF');

        Route::put('update/{client}', [ClientController::class, 'updatePF'])->name('client.updatePF');

        Route::delete('delete/{client}', [ClientController::class, 'deletePF'])->name('client.deletePF');
    });


     Route::prefix('pj')->group( function () {
        Route::get('create', [ClientController::class, 'createPJ'])->name('client.createPJ');

        Route::get('edit/{client}', [ClientController::class, 'editPJ'])->name('client.editPJ');

        Route::post('save', [ClientController::class, 'savePJ'])->name('client.savePJ');

        Route::put('update/{client}', [ClientController::class, 'updatePJ'])->name('client.updatePJ');

        Route::delete('delete/{client}', [ClientController::class, 'deletePJ'])->name('client.deletePJ');
    });




});

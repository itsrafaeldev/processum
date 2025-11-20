<?php


use App\Http\Controllers\ClientController;
use Illuminate\Support\Facades\Route;

Route::prefix('client')->group(callback: function () {

    Route::get('/', [ClientController::class, 'list'])->name('client.list');

    Route::get('create', [ClientController::class, 'create'])->name('client.create');

    Route::get('edit/{client}', [ClientController::class, 'edit'])->name('client.edit');

    Route::post('save', [ClientController::class, 'save'])->name('client.save');

    Route::put('update/{client}', [ClientController::class, 'update'])->name('client.update');

    Route::delete('delete/{client}', [ClientController::class, 'delete'])->name('client.delete');

    Route::get('/search-clients', [ClientController::class, 'search']);

});

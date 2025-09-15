<?php


use App\Http\Controllers\JudicialProcessController;
use Illuminate\Support\Facades\Route;

Route::prefix('judicial-process')->group(callback: function () {

    Route::get('/', [JudicialProcessController::class, 'list'])->name('judicial-process.list');

    Route::get('create', [JudicialProcessController::class, 'create'])->name('judicial-process.create');

    Route::get('edit/{process}', [JudicialProcessController::class, 'edit'])->name('judicial-process.edit');

    Route::post('save', [JudicialProcessController::class, 'save'])->name('judicial-process.save');

    Route::put('update/{process}', [JudicialProcessController::class, 'update'])->name('judicial-process.update');

    Route::delete('delete/{process}', [JudicialProcessController::class, 'delete'])->name('judicial-process.delete');

});



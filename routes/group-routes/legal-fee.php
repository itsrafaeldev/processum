<?php


use App\Http\Controllers\LegalFeeController;
use Illuminate\Support\Facades\Route;

Route::prefix('legal-fee')->group(callback: function () {

    Route::get('/', [LegalFeeController::class, 'list'])->name('legal-fee.list');

    Route::get('create', [LegalFeeController::class, 'create'])->name('legal-fee.create');

    Route::get('edit/{fee}', [LegalFeeController::class, 'edit'])->name('legal-fee.edit');

    Route::post('save', [LegalFeeController::class, 'save'])->name('legal-fee.save');

    Route::put('update/{fee}', [LegalFeeController::class, 'update'])->name('legal-fee.update');

    Route::delete('delete/{fee}', [LegalFeeController::class, 'delete'])->name('legal-fee.delete');

});



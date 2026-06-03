<?php

use Illuminate\Support\Facades\Route;

Route::get('/', function () {
    return view('welcome');
});

Route::get('/libros', [App\Http\Controllers\LibroController::class, 'index'])->name('libros.index');

Route::get('/libros/create', [App\Http\Controllers\LibroController::class, 'create'])->name('libros.create');

Route::post('/libros', [App\Http\Controllers\LibroController::class, 'store'])->name('libros.store');

Route::get('/libros/{libro}/edit', [App\Http\Controllers\LibroController::class, 'edit'])->name('libros.edit');

Route::put('/libros/{libro}', [App\Http\Controllers\LibroController::class, 'update'])->name('libros.update');

Route::delete('/libros/{libro}', [App\Http\Controllers\LibroController::class, 'destroy'])->name('libros.destroy');

// Rutas para Autores
Route::get('/autores', [App\Http\Controllers\AutorController::class, 'index'])->name('autores.index');

Route::get('/autores/create', [App\Http\Controllers\AutorController::class, 'create'])->name('autores.create');

Route::post('/autores', [App\Http\Controllers\AutorController::class, 'store'])->name('autores.store');

Route::get('/autores/{autor}/edit', [App\Http\Controllers\AutorController::class, 'edit'])->name('autores.edit');

Route::put('/autores/{autor}', [App\Http\Controllers\AutorController::class, 'update'])->name('autores.update');

Route::delete('/autores/{autor}', [App\Http\Controllers\AutorController::class, 'destroy'])->name('autores.destroy');
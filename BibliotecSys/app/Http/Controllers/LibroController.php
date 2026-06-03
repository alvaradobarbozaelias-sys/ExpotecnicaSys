<?php

namespace App\Http\Controllers;

use App\Models\Autor;
use App\Models\Libro;
use Illuminate\Http\Request;

class LibroController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {   
        $libros = Libro::with('autor')->get();
        return view('libro.index', compact('libros'));
    }

    /**
     * Show the form for creating a new resource.
     */
    public function create()
    {
        $autores = Autor::all();
        return view('libro.create', compact('autores'));
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        $request->validate([
            'titulo' => 'required|string|max:255',
            'genero' => 'required|string|max:255',
            'anio_publicacion' => 'required|integer|min:1000|max:' . date('Y'),
            'autor_id' => 'required|exists:autores,id',
        ]);

        Libro::create([
            'titulo' => $request->titulo,
            'genero' => $request->genero,
            'anio_publicacion' => $request->anio_publicacion,
            'autores_id' => $request->autor_id,
        ]);

        return redirect()->route('libros.index')->with('success', 'Libro creado exitosamente.');
    }

    /**
     * Display the specified resource.
     */
    public function show(Libro $libro)
    {
        //
    }

    /**
     * Show the form for editing the specified resource.
     */
    public function edit(Libro $libro)
    {
        return view('libro.edit', compact('libro'));
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, Libro $libro)
    {
        $request->validate([
            'titulo' => 'required|string|max:255',
            'genero' => 'required|string|max:255',
            'anio_publicacion' => 'required|integer|min:1000|max:' . date('Y'),
        ]);

        $libro->update($request->only(['titulo', 'genero', 'anio_publicacion']));

        return redirect()->route('libros.index')->with('success', 'Libro actualizado exitosamente.');
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(Libro $libro)
    {
        $libro->delete();
        return redirect()->route('libros.index')->with('success', 'Libro eliminado exitosamente.');
    }
}

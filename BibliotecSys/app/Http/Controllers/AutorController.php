<?php

namespace App\Http\Controllers;

use App\Models\Autor;
use Illuminate\Http\Request;

class AutorController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        $autores = Autor::all();
        return view('autor.index', compact('autores'));
    }

    /**
     * Show the form for creating a new resource.
     */
    public function create()
    {
        return view('autor.create');
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        $request->validate([
            'nombre' => 'required|string|max:255',
            'nacionalidad' => 'required|string|max:255',
            'correo' => 'required|email|unique:autores,correo',
        ]);

        Autor::create($request->only(['nombre', 'nacionalidad', 'correo']));

        return redirect()->route('autores.index')->with('success', 'Autor creado exitosamente.');
    }

    /**
     * Display the specified resource.
     */
    public function show(Autor $autor)
    {
        //
    }

    /**
     * Show the form for editing the specified resource.
     */
    public function edit(Autor $autor)
    {
        return view('autor.edit', compact('autor'));
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, Autor $autor)
    {
        $request->validate([
            'nombre' => 'required|string|max:255',
            'nacionalidad' => 'required|string|max:255',
            'correo' => 'required|email|unique:autores,correo,' . $autor->id,
        ]);

        $autor->update($request->only(['nombre', 'nacionalidad', 'correo']));

        return redirect()->route('autores.index')->with('success', 'Autor actualizado exitosamente.');
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(Autor $autor)
    {
        $autor->delete();
        return redirect()->route('autores.index')->with('success', 'Autor eliminado exitosamente.');
    }
}

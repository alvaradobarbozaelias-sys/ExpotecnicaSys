<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Libro extends Model
{
    protected $fillable = [
        'titulo', 
        'genero', 
        'anio_publicacion', 
        'autores_id'
    ];

    public function autor()
    {
        return $this->belongsTo(Autor::class, 'autores_id');
    }
}

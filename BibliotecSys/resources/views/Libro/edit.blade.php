<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Editar Libro</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
</head>
<body class="bg-light">

    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card shadow">
                    <div class="card-header bg-warning text-dark">
                        <h4 class="mb-0">Editar Información del Libro</h4>
                    </div>
                    <div class="card-body">
                        
                        <!-- Errores de Validación -->
                        @if ($errors->any())
                            <div class="alert alert-danger">
                                <ul class="mb-0">
                                    @foreach ($errors->all() as $error)
                                        <li>{{ $error }}</li>
                                    @endforeach
                                </ul>
                            </div>
                        @endif

                        <!-- Nota el action: enviamos el ID del libro -->
                        <form action="{{ route('libros.update', $libro) }}" method="POST">
                            @csrf
                            <!-- IMPORTANTE: Laravel necesita esto para saber que es una actualización -->
                            @method('PUT')

                            <div class="mb-3">
                                <label for="titulo" class="form-label">Título</label>
                                <input type="text" name="titulo" class="form-control" id="titulo" 
                                    value="{{ old('titulo', $libro->titulo) }}" required>
                            </div>

                            <div class="mb-3">
                                <label for="genero" class="form-label">Género</label>
                                <input type="text" name="genero" class="form-control" id="genero" 
                                    value="{{ old('genero', $libro->genero) }}" required>
                            </div>

                            <div class="mb-3">
                                <label for="anio_publicacion" class="form-label">Año de Publicación</label>
                                <input type="number" name="anio_publicacion" class="form-control" id="anio_publicacion" 
                                    value="{{ old('anio_publicacion', $libro->anio_publicacion) }}" required min="1000" max="{{ date('Y') }}">
                            </div>  

                            <div class="d-flex justify-content-between">
                                <a href="{{ route('libros.index') }}" class="btn btn-secondary">Volver</a>
                                <button type="submit" class="btn btn-warning text-dark">Actualizar Libro</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>

<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
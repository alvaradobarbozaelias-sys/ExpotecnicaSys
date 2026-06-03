<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Registrar Libro</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
</head>
<body class="bg-light">

    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card shadow">
                    <div class="card-header bg-success text-white">
                        <h4 class="mb-0">Nuevo Registro de Libro</h4>
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

                        <form action="{{ route('libros.store') }}" method="POST">
                            @csrf

                            <div class="mb-3">
                                <label for="titulo" class="form-label">Título</label>
                                <input type="text" name="titulo" class="form-control" id="titulo" value="{{ old('titulo') }}" required>
                            </div>

                            <div class="mb-3">
                                <label for="genero" class="form-label">Género</label>
                                <input type="text" name="genero" class="form-control" id="genero" value="{{ old('genero') }}" required>
                            </div>

                            <div class="mb-3">
                                <label for="anio_publicacion" class="form-label">Año de Publicación</label>
                                <input type="number" name="anio_publicacion" class="form-control" id="anio_publicacion" value="{{ old('anio_publicacion') }}" required min="1000" max="{{ date('Y') }}">
                            </div>

                            <div class="mb-3">
                                <label for="autor_id" class="form-label">Autor</label>
                                <select name="autor_id" class="form-control" id="autor_id" required>
                                    <option value="">Seleccione un autor</option>
                                    @foreach($autores as $autor)
                                        <option value="{{ $autor->id }}" {{ old('autor_id') == $autor->id ? 'selected' : '' }}>
                                            {{ $autor->id }}
                                        </option>
                                    @endforeach
                                </select>
                            </div>
                            </div>

                            <div class="d-flex justify-content-between">
                                <a href="{{ route('libros.index') }}" class="btn btn-secondary">Cancelar</a>
                                <button type="submit" class="btn btn-success">Guardar Libro</button>
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

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Registrar Autor</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
</head>
<body class="bg-light">

    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card shadow">
                    <div class="card-header bg-success text-white">
                        <h4 class="mb-0">Nuevo Registro de Autor</h4>
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

                        <form action="{{ route('autores.store') }}" method="POST">
                            @csrf

                            <div class="mb-3">
                                <label for="nombre" class="form-label">Nombre</label>
                                <input type="text" name="nombre" class="form-control" id="nombre" value="{{ old('nombre') }}" required>
                            </div>

                            <div class="mb-3">
                                <label for="nacionalidad" class="form-label">Nacionalidad</label>
                                <input type="text" name="nacionalidad" class="form-control" id="nacionalidad" value="{{ old('nacionalidad') }}" required>
                            </div>

                            <div class="mb-3">
                                <label for="correo" class="form-label">Correo</label>
                                <input type="email" name="correo" class="form-control" id="correo" value="{{ old('correo') }}" required>
                            </div>

                            <div class="d-flex justify-content-between">
                                <a href="{{ route('autores.index') }}" class="btn btn-secondary">Cancelar</a>
                                <button type="submit" class="btn btn-success">Guardar Autor</button>
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

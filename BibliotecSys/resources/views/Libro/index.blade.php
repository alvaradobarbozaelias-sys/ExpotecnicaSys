<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Lista de Libros</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
</head>
<body class="bg-light">

    <div class="container mt-5">
        <div class="card shadow">
            <div class="card-header bg-primary text-white d-flex justify-content-between align-items-center">
                <h3 class="mb-0">Control de Libros</h3>
                <a href="{{ route('libros.create') }}" class="btn btn-light btn-sm">
                    <i class="bi bi-plus-circle"></i> Nuevo Libro
                </a>
            </div>
            
            <div class="card-body">
                @if(session('success'))
                    <div class="alert alert-success alert-dismissible fade show" role="alert">
                        {{ session('success') }}
                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>
                @endif

                <div class="table-responsive">
                    <table class="table table-hover align-middle">
                        <thead class="table-dark">
                            <tr>
                                <th>ID</th>
                                <th>Título</th>
                                <th>Género</th>
                                <th>Año de Publicación</th>
                                <th>Autor</th>
                                <th class="text-center">Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
                            @forelse($libros as $libro)
                                <tr>
                                    <td>{{ $libro->id }}</td>
                                    <td>{{ $libro->titulo }}</td>
                                    <td>{{ $libro->genero }}</td>
                                    <td>{{ $libro->anio_publicacion }}</td>
                                    <td>{{ $libro->autor->nombre }}</td>
                                    <td class="text-center">
                                        <div class="btn-group" role="group">
                                            <!-- Botón Editar -->
                                            <a href="{{ route('libros.edit', $libro->id) }}" class="btn btn-warning btn-sm">
                                                <i class="bi bi-pencil-square"></i>
                                            </a>

                                            <!-- Botón Eliminar con Formulario -->
                                            <form action="{{ route('libros.destroy', $libro->id) }}" method="POST" onsubmit="return confirm('¿Seguro que desea eliminar este libro?')">
                                                @csrf
                                                @method('DELETE')
                                                <button type="submit" class="btn btn-danger btn-sm">
                                                    <i class="bi bi-trash"></i>
                                                </button>
                                            </form>
                                        </div>
                                    </td>
                                </tr>
                            @empty
                                <tr>
                                    <td colspan="6" class="text-center text-muted">No hay libros registrados.</td>
                                </tr>
                            @endforelse
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>

<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>

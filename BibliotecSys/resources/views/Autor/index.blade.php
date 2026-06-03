<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Lista de Autores</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
</head>
<body class="bg-light">

    <div class="container mt-5">
        <div class="card shadow">
            <div class="card-header bg-primary text-white d-flex justify-content-between align-items-center">
                <h3 class="mb-0">Control de Autores</h3>
                <a href="{{ route('autores.create') }}" class="btn btn-light btn-sm">
                    <i class="bi bi-plus-circle"></i> Nuevo Autor
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
                                <th>Nombre</th>
                                <th>País</th>
                                <th>Correo</th>
                                <th class="text-center">Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
                            @forelse($autores as $autor)
                                <tr>
                                    <td>{{ $autor->id }}</td>
                                    <td>{{ $autor->nombre }}</td>
                                    <td>{{ $autor->nacionalidad }}</td>
                                    <td>{{ $autor->correo }}</td>
                                    <td class="text-center">
                                        <div class="btn-group" role="group">
                                            <!-- Botón Editar -->
                                            <a href="{{ route('autores.edit', $autor->id) }}" class="btn btn-warning btn-sm">
                                                <i class="bi bi-pencil-square"></i>
                                            </a>

                                            <!-- Botón Eliminar con Formulario -->
                                            <form action="{{ route('autores.destroy', $autor->id) }}" method="POST" onsubmit="return confirm('¿Seguro que desea eliminar este autor?')">
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
                                    <td colspan="6" class="text-center text-muted">No hay autores registrados.</td>
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

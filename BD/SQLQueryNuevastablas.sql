use DbCrudNet8
go

create table persona
(
cedula varchar (15) primary key not null,
nombre1 varchar (35) not null,
nombre2 varchar (35) not null,
ap1 varchar (35) not null,
ap2 varchar (30) not null,
sexo varchar (1) not null,
fechaNacimiento date not null
);

create table rol
(
idRol int primary key identity (0, 1),
nombreRol varchar (35) not null,
descripcionRol varchar (35) null,
estadoRol bit default 1 not null
);

create table Usuarios
(
idUsuario int primary key identity (0, 1),
username varchar (35) not null unique,
passwordHash varchar (max) not null,   -- crear hashing en el código
estadoUsuario bit default 1 not null,
idRol int not null,
cedula varchar (15) not null,
foreign key (idRol) references rol (idRol),
foreign key (cedula) references	persona (cedula)
);

insert into persona (cedula, nombre1, nombre2, ap1, ap2, sexo, fechaNacimiento)
values ('305160425', 'Walter', 'Elias', 'Alvarado', 'Barboza', 'M', '1999-02-24'),
	   ('305200565', 'Ana', 'Isabel', 'Barboza', 'Rivera', 'F', '1974-04-11');

insert into rol (nombreRol, descripcionRol, estadoRol)
values ('Juez', null, 1),
	   ('Administrador', null, 1);

insert into usuarios (username, passwordHash, estadoUsuario, idRol, cedula)
values ('enano', '1234', 1, 1, '305160425'),
	   ('enana', '1234', 1, 0, '305200565');

												-- v2

create table categoria
(
idCategoria int primary key identity (0, 1),
nombreCategoria varchar (35) not null,
descripcionCategoria text null,
estadoCategoria bit default 1 not null
);

insert into categoria (nombreCategoria, descripcionCategoria, estadoCategoria)
values ('Steam', null, 1);

select * from Usuarios

USE DbCrudNet8;
SELECT * FROM categoria;


												-- v3


-- Crear tabla
CREATE TABLE Evaluaciones (
    IdEvaluacion INT PRIMARY KEY IDENTITY(1,1),
    Categoria VARCHAR(50) NOT NULL,       -- STEAM | Emprendimiento e innovación
    Proyecto VARCHAR(100) NOT NULL,
    Evaluador VARCHAR(100) NOT NULL,
    Fecha DATE NOT NULL,
    PuntajeObtenido DECIMAL(5,2) NOT NULL,
    Observaciones VARCHAR(255)
);

-- Insertar 6 datos de categoría STEAM
INSERT INTO Evaluaciones (Categoria, Proyecto, Evaluador, Fecha, PuntajeObtenido, Observaciones) VALUES
('STEAM', 'Sistema de Riego Automatizado', 'Ing. Laura Gómez', '2025-08-20', 92.50, 'Proyecto innovador con aplicación en agricultura'),
('STEAM', 'App de Reconocimiento de Plantas', 'Dr. Carlos Pérez', '2025-08-20', 87.00, 'Muy buen uso de inteligencia artificial'),
('STEAM', 'Robot Recolector de Basura', 'MSc. Fernanda Ruiz', '2025-08-21', 95.00, 'Excelente prototipo, faltan pruebas en campo'),
('STEAM', 'Detector de Incendios Inteligente', 'Ing. Marco Herrera', '2025-08-21', 89.75, 'Gran aporte a la seguridad'),
('STEAM', 'Juego Educativo de Matemáticas', 'Lic. Andrea Vargas', '2025-08-22', 85.00, 'Muy creativo, pero puede mejorar en usabilidad'),
('STEAM', 'Dron para Monitoreo Ambiental', 'Dr. José Ramírez', '2025-08-22', 91.25, 'Buena integración de sensores');

-- Insertar 6 datos de categoría Emprendimiento e innovación
INSERT INTO Evaluaciones (Categoria, Proyecto, Evaluador, Fecha, PuntajeObtenido, Observaciones) VALUES
('Emprendimiento e innovación', 'Plataforma de Comercio Local', 'Lic. Sofía Méndez', '2025-08-20', 90.00, 'Gran potencial de impacto en la comunidad'),
('Emprendimiento e innovación', 'App de Finanzas Personales', 'Ing. Ricardo Soto', '2025-08-20', 88.50, 'Buena idea, necesita mejorar el modelo de negocio'),
('Emprendimiento e innovación', 'Servicio de Delivery Ecológico', 'MSc. Gabriela Morales', '2025-08-21', 94.00, 'Muy innovador y sostenible'),
('Emprendimiento e innovación', 'Plataforma de Clases Online', 'Dr. Manuel Rojas', '2025-08-21', 86.75, 'Alta demanda en el mercado, buena ejecución'),
('Emprendimiento e innovación', 'Tienda Virtual de Artesanías', 'Lic. Daniela Chaves', '2025-08-22', 89.00, 'Excelente promoción de cultura local'),
('Emprendimiento e innovación', 'App de Reciclaje Gamificada', 'Ing. Esteban López', '2025-08-22', 92.00, 'Muy atractiva para usuarios jóvenes');

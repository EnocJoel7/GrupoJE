create database BDGrupoJE
use BDGrupoJE
----1. primera tabla acrear
create table Usuario(
IDUsuario int identity (1,1) primary key,
NombreUsuario varchar(100) unique not null,
Password varchar(100) not null,
PrimerNombre varchar(100),
PrimerApellido varchar(100),
Email varchar(100) null
)
-----------------------------------------------------------------------------------
insert into Usuario values ('admin', 'admin', 'John', 'Escalante', null)
----------------------------------------------------------------------------------
select * from Usuario

select * from Usuario where NombreUsuario= 'admin' and Password = 'admin'
--distintas formas ambos arriba y abajo.
declare @user varchar(100) = 'admin'
declare @pass varchar(100) = 'admin'
select * from Usuario where NombreUsuario=@user and Password=@pass


---------------------------------------------------------------------------------2. Segunda tabla
create table Cliente(
CodCli char(7) not null primary key, 
CliDNI char(8),
CliNom varchar(100),
CliApe varchar(100),
CliTelef char(9),
CliDirec varchar(100)
)
select * from cliente

select CodCli as 'CODIGO', CliNom as 'NOMBRE', CliApe as 'APELLIDO', CliTelef as 'TELÉFONO', CliDirec as 'DIRECCIÓN' from Cliente 

insert into Cliente values ('CLI-001', '67548792', 'Alberto Alonso', 'Solorzano Cabrera', '945867789', 'Lima 8043')
---------------------------------------------------------------------------------3. Tercera tabla
create table Proveedor(
CodigoProveedor char(7) not null primary key,
ProveedorRUC char(11) not null,
ProveedorNombre varchar(50),
ProveedorApellido varchar(50),
ProveedorDireccion varchar(50),
ProveedorTelefono char(9),
ProveedorEmail varchar(50),
)

select CodigoProveedor as 'CODIGO PROVEEDOR', ProveedorRUC as 'RUC', ProveedorNombre as 'NOMBRE', 
ProveedorApellido as 'APELLIDO', ProveedorDireccion as 'DIRECCIÓN', ProveedorTelefono as 'TELÉFONO',
ProveedorEmail as 'E-MAIL' from Proveedor
---------------------------------------------------------------------------------------------4. Cuarta tabla
Create table Material(
CodigoMaterial char(7) not null primary key,
MaterialNombre varchar(100),
MaterialCantidad int,
MaterialPrecio decimal(10,2),
CodigoProveedor char(7) not null foreign key references Proveedor
)

Select Material.CodigoMaterial AS 'CODIGO MATERIAL', Proveedor.ProveedorNombre AS 'CONTACTO', Material.MaterialNombre AS 'NOMBRE',
Material.MaterialPrecio AS 'PRECIO', Material.MaterialCantidad AS 'CANTIDAD', 
TOTAL = MaterialPrecio * MaterialCantidad FROM Material INNER JOIN Proveedor ON 
Material.CodigoProveedor = Proveedor.CodigoProveedor

--------------------------------------------------------------------------------5. Quinta Tabla
Create table Empleado(
CodigoEmpleado char(7) not null primary key,
EmpleadoDNI char(8),
EmpleadoNombre varchar(50),
EmpleadoApellido varchar(50),
EmpleadoCargo varchar(50)
)
Select CodigoEmpleado as 'CODIGO', EmpleadoDNI as 'DNI', EmpleadoNombre as 'NOMBRE', EmpleadoApellido as 'APELLIDO', 
EmpleadoCargo as 'CARGO' from Empleado

--------------------------------------------------------------------------------------6. Sexta tabla
create table Estado(
EstadoNombre varchar(100) not null primary key,
)
insert into Estado values ('Pendiente')
insert into Estado values ('En Progreso')
insert into Estado values ('Finalizado')

SELECT * FROM Estado ORDER BY CASE WHEN EstadoNombre = 'Pendiente' THEN 1 WHEN EstadoNombre = 'En Progreso' THEN 2 WHEN EstadoNombre = 'Finalizado' THEN 3 ELSE 4 END;
------------------------------------------------------------------------------------7. Septima tabla
create table Categoria(
CategoriaNombre varchar(50) not null primary key,
)
select * from Categoria
Insert into Categoria values ('Electrónica Industrial')
Insert into Categoria values ('Aire Acondicionado y equipos de Refrigeración')
Insert into Categoria values ('Jardinería')
Insert into Categoria values ('Metálica y Cerrajería')
Insert into Categoria values ('Carpintería')
Insert into Categoria values ('Adecuación de mobiliario')
Insert into Categoria values ('Sillonería')
Insert into Categoria values ('Pintura y Albañilería')
Insert into Categoria values ('Gasfitería')
Insert into Categoria values ('Trabajos en Drywall')


---------------------------------------------------------------------------------8. Octava tabla
create table Rango(
RangoNombre varchar(50) not null primary key
)
select * from rango order by RangoNombre desc
insert into Rango values ('Menor Rango')
insert into Rango values ('Medio Rango')
insert into Rango values ('Alto Rango')


-----------------------------------------------------------------------------------9. Novena tabla
Create table Servicio(
NombreServicio varchar(200) not null primary key,
CategoriaNombre varchar(50) not null foreign key references Categoria
)
select * from Servicio
insert into Servicio values ('Suministro, instalación, reparación, independización y cableado de interruptores.', 'Electrónica Industrial')
insert into Servicio values ('Suministro, instalación, reparación y cableado de luminarias, fluorescentes y dicroicos tipo LED o pantalla.', 'Electrónica Industrial')
insert into Servicio values ('Instalación de luces de emergencia.', 'Electrónica Industrial')
insert into Servicio values ('Suministro, instalación, reparación y cableado de tomacorrientes comerciales y estabilizados con línea a tierra.', 'Electrónica Industrial')
insert into Servicio values ('Canaleteado, entubado y canalización de cables para instalación de equipos.', 'Electrónica Industrial')
insert into Servicio values ('Suministro, instalación de tableros eléctricos e interruptores termomagnéticos y diferenciales con cableados.', 'Electrónica Industrial')
insert into Servicio values ('Validación de circuitos, sobredimensión de interruptores termomagnéticos, ordenamiento de cableado, limpieza, rotulado, aterramiento, señalización de tableros eléctricos.', 'Electrónica Industrial')
insert into Servicio values ('Mantenimientos a pozo a tierra.', 'Electrónica Industrial')

insert into Servicio values ('Reparación y calibración de termostatos y controles.', 'Aire Acondicionado y equipos de Refrigeración')
insert into Servicio values ('Mantenimientos preventivos y correctivos de Equipos condensadores y refrigerantes.', 'Aire Acondicionado y equipos de Refrigeración')
insert into Servicio values ('Limpieza de mangas y ductos de aire.', 'Aire Acondicionado y equipos de Refrigeración')
insert into Servicio values ('Control de goteo de filtraciones de AA.', 'Aire Acondicionado y equipos de Refrigeración')

insert into Servicio values ('Mantenimiento constante de jardines y macetas en los locales requeridos.', 'Jardinería')
insert into Servicio values ('Regado de plantas según lo requerido por cada especie.', 'Jardinería')
insert into Servicio values ('Podado de las especies (árboles, césped, plantas decorativas en macetas o pequeños jardines decorativos) por tiempo requerido.', 'Jardinería')
insert into Servicio values ('Aplicación de insecticidas (fumigación) en plantas requeridas.', 'Jardinería')
insert into Servicio values ('Designación de plantas decorativas cada cierto periodo de tiempo, para decoración de espacios según lo solicitado por el cliente.', 'Jardinería')
insert into Servicio values ('Aplicación de abono constantemente en jardines y macetas.', 'Jardinería')
insert into Servicio values ('Pintado y mantenimiento de macetas de oficinas.', 'Jardinería')

insert into Servicio values ('Suministro, instalación y reparación de chapas simples y especiales.', 'Metálica y Cerrajería')
insert into Servicio values ('Apertura de chapas y puertas.', 'Metálica y Cerrajería')
insert into Servicio values ('Duplicado y confección de todo tipo de llaves.', 'Metálica y Cerrajería')
insert into Servicio values ('Apertura, reparación y suministro de candados.', 'Metálica y Cerrajería')
insert into Servicio values ('Suministro, instalación y reparación de sistemas de apertura, rieles, correderas y pines.', 'Metálica y Cerrajería')
insert into Servicio values ('Suministro, instalación y reparación de chapas eléctricas y pulsadores.', 'Metálica y Cerrajería')
insert into Servicio values ('Reparación y mantenimiento de puertas de metal y contraplacadas, marcos y perfiles, sistemas hidráulicos y centrado.', 'Metálica y Cerrajería')
insert into Servicio values ('Suministro, instalación y mantenimiento de muebles de aluminio o acero.', 'Metálica y Cerrajería')

insert into Servicio values ('Confección y fabricación de muebles de oficina, mesas, repisas, estantes aéreos de madera, melamine, pvc, etc.', 'Carpintería')
insert into Servicio values ('Resane, masillado, lijado, pintado, barnizado, reparación de muebles.', 'Carpintería')
insert into Servicio values ('Reparación y mantenimiento de muebles, garruchas, correderas, tiradores, puertas, cajoneras, etc.', 'Carpintería')
insert into Servicio values ('Suministro, instalación y mantenimiento de puertas, pulido, masillado, pintado, retoque, lijado, resane, etc.', 'Carpintería')
insert into Servicio values ('Suministro, instalación y pulido de pisos de madera. ', 'Carpintería')

insert into Servicio values ('Realización de escaleras o barandilla de madera.', 'Adecuación de mobiliario')
insert into Servicio values ('Empotramiento de muebles, repisas, estantes, cuadros, anaqueles, etc.', 'Adecuación de mobiliario')
insert into Servicio values ('Instalación y mantenimiento de tótems, letreros, carteles y anuncios.', 'Adecuación de mobiliario')
insert into Servicio values ('Instalación de tabiquería, separaciones, módulos de puestos de trabajo en melamine.', 'Adecuación de mobiliario')

insert into Servicio values ('Reparación de sillas de escritorio, garruchas, base, pistones, espaldar, asiento, etc.', 'Sillonería')
insert into Servicio values ('Reparación de butacas, muebles o asientos de oficina.', 'Sillonería')
insert into Servicio values ('Limpieza y mantenimiento de sillas.', 'Sillonería')
insert into Servicio values ('Anclaje de sillas al piso por filas.', 'Sillonería')

insert into Servicio values ('Preparación de superficie par pintado, lijado, masillado, retiro de salitre, resane, etc.', 'Pintura y Albañilería')
insert into Servicio values ('Pintada con acabados de fachadas, interiores y exteriores, techos, estructuras, etc.', 'Pintura y Albañilería')
insert into Servicio values ('Fraguado de piso, instalación de losetas y mayólicas.', 'Pintura y Albañilería')
insert into Servicio values ('Instalación y reparación de baldosas y cielo raso.', 'Pintura y Albañilería')
insert into Servicio values ('Reparación de columnas, bigas, resane y retoques.', 'Pintura y Albañilería')

insert into Servicio values ('Reparación de duchas, caños, inodoros.', 'Gasfitería')
insert into Servicio values ('Limpieza y reparación de tuberías y cañerías.', 'Gasfitería')
insert into Servicio values ('Atención de aniegos y filtraciones.', 'Gasfitería')
insert into Servicio values ('Reparación de bomba de agua.', 'Gasfitería')
insert into Servicio values ('Atenciones de emergencia.', 'Gasfitería')

insert into Servicio values ('Confección e instalación de estructuras de drywall, separaciones, perfiles, tabiques.', 'Trabajos en Drywall')
insert into Servicio values ('Pintura, resane y masillado de estructuras de drywall.', 'Trabajos en Drywall')



-----------------------------------------------------------------------------------------------------------------10. Decima tabla
Create table Proyecto(
CodigoProyecto char(7) not null primary key,
ProyectoNombre varchar(100),
ProyectoDescripcion varchar(500),
EstadoNombre varchar(100) foreign key references Estado,
NombreServicio varchar(200) foreign key references Servicio,
RangoNombre varchar(50) foreign key references Rango,
ProyectoPrecio decimal(10,2),
CodCli char(7) not null foreign key references Cliente,
CodigoEmpleado char(7) not null foreign key references Empleado,
CodigoProveedor char(7) not null foreign key references Proveedor
)
select * from Proyecto

Select CodigoProyecto as 'CÓDIGO PROYECTO', ProyectoNombre as 'NOMBRE', ProyectoDescripcion as 'DESCRIPCIÓN', EstadoNombre as 'ESTADO', NombreServicio as 'SERVICIO', RangoNombre as 'RANGO', ProyectoPrecio as 'PRECIO', CodCli as 'CLIENTE', CodigoEmpleado as 'EMPLEADO', CodigoProveedor as 'PROVEEDOR' from Proyecto

SELECT NombreServicio FROM Servicio WHERE CategoriaNombre = @Categoria

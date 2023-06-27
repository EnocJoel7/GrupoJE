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

select CodCli as 'CODIGO', CliNom as 'NOMBRE', CliApe as 'APELLIDO', CliTelef as 'TEL�FONO', CliDirec as 'DIRECCI�N' from Cliente 

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
ProveedorApellido as 'APELLIDO', ProveedorDireccion as 'DIRECCI�N', ProveedorTelefono as 'TEL�FONO',
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
Insert into Categoria values ('Electr�nica Industrial')
Insert into Categoria values ('Aire Acondicionado y equipos de Refrigeraci�n')
Insert into Categoria values ('Jardiner�a')
Insert into Categoria values ('Met�lica y Cerrajer�a')
Insert into Categoria values ('Carpinter�a')
Insert into Categoria values ('Adecuaci�n de mobiliario')
Insert into Categoria values ('Silloner�a')
Insert into Categoria values ('Pintura y Alba�iler�a')
Insert into Categoria values ('Gasfiter�a')
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
insert into Servicio values ('Suministro, instalaci�n, reparaci�n, independizaci�n y cableado de interruptores.', 'Electr�nica Industrial')
insert into Servicio values ('Suministro, instalaci�n, reparaci�n y cableado de luminarias, fluorescentes y dicroicos tipo LED o pantalla.', 'Electr�nica Industrial')
insert into Servicio values ('Instalaci�n de luces de emergencia.', 'Electr�nica Industrial')
insert into Servicio values ('Suministro, instalaci�n, reparaci�n y cableado de tomacorrientes comerciales y estabilizados con l�nea a tierra.', 'Electr�nica Industrial')
insert into Servicio values ('Canaleteado, entubado y canalizaci�n de cables para instalaci�n de equipos.', 'Electr�nica Industrial')
insert into Servicio values ('Suministro, instalaci�n de tableros el�ctricos e interruptores termomagn�ticos y diferenciales con cableados.', 'Electr�nica Industrial')
insert into Servicio values ('Validaci�n de circuitos, sobredimensi�n de interruptores termomagn�ticos, ordenamiento de cableado, limpieza, rotulado, aterramiento, se�alizaci�n de tableros el�ctricos.', 'Electr�nica Industrial')
insert into Servicio values ('Mantenimientos a pozo a tierra.', 'Electr�nica Industrial')

insert into Servicio values ('Reparaci�n y calibraci�n de termostatos y controles.', 'Aire Acondicionado y equipos de Refrigeraci�n')
insert into Servicio values ('Mantenimientos preventivos y correctivos de Equipos condensadores y refrigerantes.', 'Aire Acondicionado y equipos de Refrigeraci�n')
insert into Servicio values ('Limpieza de mangas y ductos de aire.', 'Aire Acondicionado y equipos de Refrigeraci�n')
insert into Servicio values ('Control de goteo de filtraciones de AA.', 'Aire Acondicionado y equipos de Refrigeraci�n')

insert into Servicio values ('Mantenimiento constante de jardines y macetas en los locales requeridos.', 'Jardiner�a')
insert into Servicio values ('Regado de plantas seg�n lo requerido por cada especie.', 'Jardiner�a')
insert into Servicio values ('Podado de las especies (�rboles, c�sped, plantas decorativas en macetas o peque�os jardines decorativos) por tiempo requerido.', 'Jardiner�a')
insert into Servicio values ('Aplicaci�n de insecticidas (fumigaci�n) en plantas requeridas.', 'Jardiner�a')
insert into Servicio values ('Designaci�n de plantas decorativas cada cierto periodo de tiempo, para decoraci�n de espacios seg�n lo solicitado por el cliente.', 'Jardiner�a')
insert into Servicio values ('Aplicaci�n de abono constantemente en jardines y macetas.', 'Jardiner�a')
insert into Servicio values ('Pintado y mantenimiento de macetas de oficinas.', 'Jardiner�a')

insert into Servicio values ('Suministro, instalaci�n y reparaci�n de chapas simples y especiales.', 'Met�lica y Cerrajer�a')
insert into Servicio values ('Apertura de chapas y puertas.', 'Met�lica y Cerrajer�a')
insert into Servicio values ('Duplicado y confecci�n de todo tipo de llaves.', 'Met�lica y Cerrajer�a')
insert into Servicio values ('Apertura, reparaci�n y suministro de candados.', 'Met�lica y Cerrajer�a')
insert into Servicio values ('Suministro, instalaci�n y reparaci�n de sistemas de apertura, rieles, correderas y pines.', 'Met�lica y Cerrajer�a')
insert into Servicio values ('Suministro, instalaci�n y reparaci�n de chapas el�ctricas y pulsadores.', 'Met�lica y Cerrajer�a')
insert into Servicio values ('Reparaci�n y mantenimiento de puertas de metal y contraplacadas, marcos y perfiles, sistemas hidr�ulicos y centrado.', 'Met�lica y Cerrajer�a')
insert into Servicio values ('Suministro, instalaci�n y mantenimiento de muebles de aluminio o acero.', 'Met�lica y Cerrajer�a')

insert into Servicio values ('Confecci�n y fabricaci�n de muebles de oficina, mesas, repisas, estantes a�reos de madera, melamine, pvc, etc.', 'Carpinter�a')
insert into Servicio values ('Resane, masillado, lijado, pintado, barnizado, reparaci�n de muebles.', 'Carpinter�a')
insert into Servicio values ('Reparaci�n y mantenimiento de muebles, garruchas, correderas, tiradores, puertas, cajoneras, etc.', 'Carpinter�a')
insert into Servicio values ('Suministro, instalaci�n y mantenimiento de puertas, pulido, masillado, pintado, retoque, lijado, resane, etc.', 'Carpinter�a')
insert into Servicio values ('Suministro, instalaci�n y pulido de pisos de madera. ', 'Carpinter�a')

insert into Servicio values ('Realizaci�n de escaleras o barandilla de madera.', 'Adecuaci�n de mobiliario')
insert into Servicio values ('Empotramiento de muebles, repisas, estantes, cuadros, anaqueles, etc.', 'Adecuaci�n de mobiliario')
insert into Servicio values ('Instalaci�n y mantenimiento de t�tems, letreros, carteles y anuncios.', 'Adecuaci�n de mobiliario')
insert into Servicio values ('Instalaci�n de tabiquer�a, separaciones, m�dulos de puestos de trabajo en melamine.', 'Adecuaci�n de mobiliario')

insert into Servicio values ('Reparaci�n de sillas de escritorio, garruchas, base, pistones, espaldar, asiento, etc.', 'Silloner�a')
insert into Servicio values ('Reparaci�n de butacas, muebles o asientos de oficina.', 'Silloner�a')
insert into Servicio values ('Limpieza y mantenimiento de sillas.', 'Silloner�a')
insert into Servicio values ('Anclaje de sillas al piso por filas.', 'Silloner�a')

insert into Servicio values ('Preparaci�n de superficie par pintado, lijado, masillado, retiro de salitre, resane, etc.', 'Pintura y Alba�iler�a')
insert into Servicio values ('Pintada con acabados de fachadas, interiores y exteriores, techos, estructuras, etc.', 'Pintura y Alba�iler�a')
insert into Servicio values ('Fraguado de piso, instalaci�n de losetas y may�licas.', 'Pintura y Alba�iler�a')
insert into Servicio values ('Instalaci�n y reparaci�n de baldosas y cielo raso.', 'Pintura y Alba�iler�a')
insert into Servicio values ('Reparaci�n de columnas, bigas, resane y retoques.', 'Pintura y Alba�iler�a')

insert into Servicio values ('Reparaci�n de duchas, ca�os, inodoros.', 'Gasfiter�a')
insert into Servicio values ('Limpieza y reparaci�n de tuber�as y ca�er�as.', 'Gasfiter�a')
insert into Servicio values ('Atenci�n de aniegos y filtraciones.', 'Gasfiter�a')
insert into Servicio values ('Reparaci�n de bomba de agua.', 'Gasfiter�a')
insert into Servicio values ('Atenciones de emergencia.', 'Gasfiter�a')

insert into Servicio values ('Confecci�n e instalaci�n de estructuras de drywall, separaciones, perfiles, tabiques.', 'Trabajos en Drywall')
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

Select CodigoProyecto as 'C�DIGO PROYECTO', ProyectoNombre as 'NOMBRE', ProyectoDescripcion as 'DESCRIPCI�N', EstadoNombre as 'ESTADO', NombreServicio as 'SERVICIO', RangoNombre as 'RANGO', ProyectoPrecio as 'PRECIO', CodCli as 'CLIENTE', CodigoEmpleado as 'EMPLEADO', CodigoProveedor as 'PROVEEDOR' from Proyecto

SELECT NombreServicio FROM Servicio WHERE CategoriaNombre = @Categoria

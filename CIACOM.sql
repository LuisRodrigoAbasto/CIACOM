create database CIACOM
go
use CIACOM
go

create table cliente(
idCliente int primary key identity(1,1),
nombre varchar(30),
paterno varchar(30),
materno varchar(30),
telefono int,
ci varchar(20)
)
go

create table empleado(
idEmpleado int primary key identity(1,1),
nombre varchar(30),
paterno varchar(30),
materno varchar(30),
telefono int,
ci varchar(20)
)
go

create table tecnico(
idTecnico int primary key identity(1,1),
nombre varchar(30),
paterno varchar(30),
materno varchar(30),
telefono int,
ci varchar(20))
go

create table categoria(
idCategoria int primary key identity(1,1),
nombre varchar(30))
go

create table marca(
idMarca int primary key identity(1,1),
nombre varchar(30))
go


create table producto(
idProducto int primary key identity(1,1),
modelo varchar(50),
descripcion varchar(100),
precio money,
stock int,
idMarca int not null,
idCategoria int not null,
 foreign key(idMarca) references marca(idMarca),
 foreign key(idCategoria) references categoria(idCategoria))
 go

create table notaVenta(
idVenta int primary key identity(1,1),
fecha date,
montoVenta money,
idCliente int,
idEmpleado int,
 foreign key(idCliente) references cliente(idCliente),
 foreign key(idEmpleado) references empleado(idEmpleado))
 go

create table detalleVenta(
cantidad int,
precioVenta money,
idVenta int not null,
idProducto int not null,
primary key(idVenta, idProducto),
foreign key(idVenta) references notaVenta(idVenta),
foreign key(idProducto) references producto(idProducto))
go

create table repuesto(
idRepuesto int primary key identity(1,1),
descripcion varchar(100),
modelo varchar(50),
marca varchar(50),
stock int,
precio money)
go
 
create table trabajo(
idTrabajo int primary key identity(1,1),
nombre varchar(50),
precio money)
go

create table ordenServicio(
idOrden int primary key identity(1,1),
fechaEntrada date,
fechaSalida date,
montoTotal money,
idEmpleado int not null,
idCliente int not null,
idTecnico int not null,
foreign key(idEmpleado) references empleado(idEmpleado),
foreign key(idCliente) references cliente(idCliente),
foreign key(idTecnico) references tecnico(idTecnico))
go

create table equipo(
idEquipo int primary key identity(1,1),
nombre varchar(50),
descripcion varchar(100),
modelo varchar(50),
marca varchar(50),
serie varchar(50))
go

create table detalleEquipo(
idEquipo int not null,
idOrden int not null,
primary key(idEquipo,idOrden),
foreign key(idEquipo)references equipo(idEquipo),
foreign key(idOrden)references ordenServicio(idOrden))
go

create table detalleTrabajo(
idTrabajo int not null,
idOrden int not null,
primary key(idTrabajo,idOrden),
foreign key(idTrabajo) references trabajo(idTrabajo),
foreign key(idOrden) references ordenServicio(idOrden))
go

create table detalleRepuesto(
cantidad int,
precio money,
idOrden int,
idRepuesto int,
primary key(idOrden, idRepuesto),
foreign key(idOrden) references ordenServicio(idOrden),
foreign key(idRepuesto) references repuesto(idRepuesto))
go

select *from empleado
insert into empleado values('Luis Rodrigo','Abasto','Torres',74930776,'11351652 SC')
insert into empleado values('Modesto','Ventura','Mamani',71281829,'13213422 SC')
insert into empleado values('Luis Felipe','Mamani','Fernadez,',73842323,'12223212 SC')
insert into empleado values('Juan Luis','Panozo','Vargas',67712812,'2121231 SC')
insert into empleado values('Alberto','Ventura','Leon',63743745,'7828327 SC')
go

select *from cliente 
insert into cliente values('Ruben','Castellon','Fernadez',71781386,'7870509 CB')
insert into cliente values('Beltran','Montaño','Aguilar',74956143,'7810669 TJ')
insert into cliente values('Jose Luis','Muriel','',71452030,'6526834 LP')
insert into cliente values('Ramon','Pacheco','',76673775,'4614489 OR')
insert into cliente values('Santiago','Montero','',782478234,'9831194 TJ')
insert into cliente values('Wilfredo','Romero','',76370331,'3272956 SC')
insert into cliente values('Willy','Ramirez','',68024448,'4892087 SC')	 
insert into cliente values('Indalicio','LLanos','',67502070,'7907219 SC')	 
insert into cliente values('Wilder','Andrade','Soliz',71436518,'8787523 LP')	 
insert into cliente values('Sergio','Coca','',78078090,'8010242 OR')
insert into cliente values('Jose','Anturiano','',75262105,'7980535 SC')	 
insert into cliente values('Fabian','Aguilar','',71415277,'2445851 SC')
insert into cliente values('Carlos','Eguez','',67363894,'3285893 SC')
insert into cliente values('Faustino','Muñoz','Rocha',68837722,'8169498 SC')
go

select *from tecnico
insert into tecnico values('Marcelino','Arevalo','Machado',73507968,'4253330 SC')
insert into tecnico values('Juvenal','Huarachi','Huaranca',76935099,'5284816 LP')
insert into tecnico values('Ediverto','Peralta','Lopez',71051910,'7129027 SC')
go

select *from categoria
insert into categoria values('Laptops')
insert into categoria values('Parlantes')
insert into categoria values('Impresoras')
insert into categoria values('Teclado')
insert into categoria values('Disco Duro')
insert into categoria values('Monitor')
insert into categoria values('Mouse')
insert into categoria values('Tarjeta Madre')
insert into categoria values('CPU')
insert into categoria values('Memoria')
insert into categoria values('Combo')
go

select *from marca
insert into marca values('Lenovo')
insert into marca values('hp')
insert into marca values('Samsung')
insert into marca values('Asus')
insert into marca values('Toshiba')
insert into marca values('Dell')
insert into marca values('Apple')
insert into marca values('Epson')
insert into marca values('Canon')
insert into marca values('Lg')
insert into marca values('Delux')
insert into marca values('Acer')
go

select *from producto
insert into producto values('Lenovo G470','320Gb de disco duro, 4Gb de Ram, procesador core i3',3000,200,1,1)
insert into producto values('hp Pavillion','1TB de disco duro, 12GB de Ram, procesador core i9',5000,50,2,1)
insert into producto values('Thinkpad','1TB de disco duro, 12 Gb de Ram, procesador core i9',6000,50,1,1)
insert into producto values('Idepad','500GB de disco duro,12 Gb de Ram, procesador Core i7',4000,50,1,1)
insert into producto values('M325','Mouse Inalambrico color negro',100,100,2,5)
insert into producto values('L220','Impresora sin escaner color negro, tinta integrada',1000,100,6,10)
insert into producto values('OM-06','Teclado inalambrico color negro',150,100,8,9)
insert into producto values('MSJD90','Monitor de 16" color plomo',200,100,5,10)
insert into producto values('ASDFQ','Case color negro',90,50,3,8)
insert into producto values('MOP-093','Parlante chico de color negro de con entradad usb',150,50,9,1) 
insert into producto values('902-PO','Teclado con entrada usb color negro',200,50,4,8)
insert into producto values('OLE-90','Mouse color negro con entrada usb',90,50,2,10)
insert into producto values('PPP-190','Combo delux, con teclado, mouse,Case,Parlante',400,20,11,11)
insert into producto values('L230','impresora con escaner con tinta integrada',1000,30,8,3)
insert into producto values('OPRA','Ram 2GB',1000,40,6,10)
go

select *from notaVenta
insert into notaVenta values('2018-04-01',3000,1,1)
insert into notaVenta values('2018-04-01',5000,2,1)
insert into notaVenta values('2018-04-01',6000,3,1)
insert into notaVenta values('2018-04-01',4000,4,2)
insert into notaVenta values('2018-05-01',3000,5,2)
insert into notaVenta values('2018-05-01',2000,3,2)
insert into notaVenta values('2018-05-01',3000,5,3)
insert into notaVenta values('2018-05-01',3000,7,1)
insert into notaVenta values('2018-05-02',3000,11,2)
insert into notaVenta values('2018-05-02',3000,12,2)
insert into notaVenta values('2018-05-02',3000,14,3)
insert into notaVenta values('2018-05-02',3000,13,2)
insert into notaVenta values('2018-05-03',3000,10,1)
insert into notaVenta values('2018-05-03',3000,9,2)
insert into notaVenta values('2018-05-04',3000,8,2)
go

select *from detalleVenta
insert into detalleVenta values(1,3000,1,1)
insert into detalleVenta values(1,5000,2,2)
insert into detalleVenta values(1,6000,3,3)
insert into detalleVenta values(1,4000,4,4)
insert into detalleVenta values(1,3000,5,1)
insert into detalleVenta values(2,800,15,3)
insert into detalleVenta values(1,100,14,4)
insert into detalleVenta values(3,300,12,9)
insert into detalleVenta values(1,900,7,14)
insert into detalleVenta values(2,2000,8,15)
insert into detalleVenta values(1,200,13,12)
insert into detalleVenta values(2,600,4,6)
insert into detalleVenta values(1,1000,1,15)
insert into detalleVenta values(2,2000,3,11)
insert into detalleVenta values(1,200,4,10)
go

select *from repuesto
insert into repuesto values('2GB de Ram Marvision','ADASFAS84A','Samsung',10,50)
insert into repuesto values('1TB disco duro','ADSFASF','hp',23,500)
insert into repuesto values('teclado','IFOADSIFOS','LG',34,100)
insert into repuesto values('pantalla','2ADFASF23','LENOVO',34,600)
go

select *from trabajo
insert into trabajo values('limpieza de software',40)
insert into trabajo values('instalacion windows',100)
insert into trabajo values('eliminacion de virus',40)
insert into trabajo values('Limpieza de Hadware',100)
insert into trabajo values('Reparacion de Disco Duro',100)
insert into trabajo values('Resetear Impresora',100)
insert into trabajo values('Limpieza de Impresora',100)
insert into trabajo values('Reparacion de impresora',100)
insert into trabajo values('Reparacion de Flah',20)
insert into trabajo values('Reparacion de Parlantes',80)
go

select *from equipo 
insert into equipo values('portatil','color negro 17 pulgada','e47g','toshiba','7a055165ww')
insert into equipo values('parlante','color plomo','a120','creative','ww7mf04105')
insert into equipo values('monitor','color negro','c49','samsung','903ndcjdn')
insert into equipo values('cpu','Color negro','102-293','Delux','S/N')
insert into equipo values('Parlante','Color Plomo','OIU-90','SAMSUNG','w192301831394j')
insert into equipo values('Pantalla','14" Color Rojo','29304','LG','2394023jfur')
insert into equipo values('Portatil','16" color Azul','LenovoG70','Lenovo','121391o1j2d')
insert into equipo values('Portatil','20" color plomo','2390','ASUS','23923jhdd9')
go

select *from ordenServicio
insert into ordenServicio values('2018-01-01','2018-01-02',50,1,1,1)
insert into ordenServicio values('2018-01-01','2018-01-02',50,1,2,1)
insert into ordenServicio values('2018-01-04','2018-01-02',50,1,1,2)
insert into ordenServicio values('2018-01-04','2018-01-10',50,2,4,3)
insert into ordenServicio values('2018-01-05','2018-01-20',50,2,7,3)
insert into ordenServicio values('2018-01-05','2018-01-10',50,2,8,3)
insert into ordenServicio values('2018-01-05','2018-01-09',50,3,9,3)
insert into ordenServicio values('2018-01-07','2018-01-10',50,3,10,1)
insert into ordenServicio values('2018-01-07','2018-01-20',50,3,11,1)
insert into ordenServicio values('2018-01-08','2018-01-22',50,3,12,1)
insert into ordenServicio values('2018-01-10','2018-01-22',50,1,12,1)
insert into ordenServicio values('2018-01-11','2018-01-22',50,1,13,1)
insert into ordenServicio values('2018-01-11','2018-01-23',50,1,4,1)
insert into ordenServicio values('2018-01-12','2018-01-13',50,2,5,3)
insert into ordenServicio values('2018-01-12','2018-01-14',50,2,3,3)
insert into ordenServicio values('2018-01-12','2018-01-15',50,2,1,3)
insert into ordenServicio values('2018-01-13','2018-01-16',50,2,2,3)
insert into ordenServicio values('2018-01-13','2018-01-18',50,3,9,3)
insert into ordenServicio values('2018-01-13','2018-01-19',50,3,11,2)
insert into ordenServicio values('2018-01-14','2018-01-15',50,3,11,2)
go

select *from detalleEquipo
insert into detalleEquipo values(1,1,1)
insert into detalleEquipo values(1,2,2)
insert into detalleEquipo values(1,3,3)
insert into detalleEquipo values(1,8,4)
insert into detalleEquipo values(1,7,5)
insert into detalleEquipo values(1,6,20)
insert into detalleEquipo values(1,5,11)
insert into detalleEquipo values(1,3,16)
insert into detalleEquipo values(1,4,18)
insert into detalleEquipo values(1,7,20)
insert into detalleEquipo values(1,8,18)
insert into detalleEquipo values(1,5,10)
insert into detalleEquipo values(1,3,11)
insert into detalleEquipo values(1,2,10)
insert into detalleEquipo values(1,8,10)
insert into detalleEquipo values(1,6,19)
insert into detalleEquipo values(1,2,17)
insert into detalleEquipo values(1,7,17)
go

select *from detalleTrabajo
insert into detalleTrabajo values(1,1)
insert into detalleTrabajo values(2,2)
insert into detalleTrabajo values(3,3)
insert into detalleTrabajo values(1,2)
insert into detalleTrabajo values(10,10)
insert into detalleTrabajo values(9,20)
insert into detalleTrabajo values(8,12)
insert into detalleTrabajo values(7,14)
insert into detalleTrabajo values(6,16)
insert into detalleTrabajo values(2,7)
insert into detalleTrabajo values(5,8)
insert into detalleTrabajo values(4,13)
insert into detalleTrabajo values(6,14)
insert into detalleTrabajo values(4,20)
go


create proc insertarEmpleado
@idEmpleado int output,
@nombre char(30),
@paterno char(30),
@materno char(30),
@telefono int,
@ci char(20)
as
begin
insert into empleado 
values(@nombre,@paterno,@materno,@telefono,@ci)
end
go

create proc modificarEmpleado
@idEmpleado int,
@nombre varchar(30),
@paterno varchar(30),
@materno varchar(30),
@telefono int,
@ci varchar(20)
as 
begin
if exists(select *from empleado where idEmpleado=@idEmpleado)
begin
update empleado set
nombre=@nombre,paterno=@paterno,materno=@materno,telefono=@telefono,ci=@ci
where idEmpleado=@idEmpleado;
end
end
go

create proc eliminarEmpleado
@idEmpleado int
as
begin
delete from empleado where idEmpleado=@idEmpleado
end
go

create proc mostrarEmpleado
as
select *from empleado
order by idEmpleado desc
go

create proc buscarEmpleado
@textoBuscar varchar(50)
as
begin
select *from empleado where nombre like @textoBuscar + '%'
end
go

----- procesar de clientes
create proc insertarCliente
@idCliente int output,
@nombre varchar(30),
@paterno varchar(30),
@materno varchar(30),
@telefono int,
@ci varchar(20)
as
begin
if(not exists(select *from cliente where nombre=@nombre and paterno=@paterno))
begin
insert into cliente 
values(@nombre,@paterno,@materno,@telefono,@ci)
end
end
go

create proc modificarCliente
@idCliente int,
@nombre varchar(30),
@paterno varchar(30),
@materno varchar(30),
@telefono int,
@ci varchar(20)
as
begin
if (exists(select *from cliente where idCliente=@idCliente))
begin
update cliente set
nombre=@nombre, paterno=@paterno, materno=@materno, telefono=@telefono, ci=@ci
where idCliente=@idCliente;
end
else
print 'No se puede modificar, por que no existe el cliente'
end
go

create proc eliminarCliente
@idCliente int
as
if exists(select *from cliente where idCliente=@idCliente) and
not exists(select *from notaVenta,ordenServicio where notaVenta.idCliente=@idCliente and 
ordenServicio.idCliente=@idCliente)
begin
delete from cliente where idCliente=@idCliente
end
go

create proc mostrarCliente
as
select *from cliente
order by idCliente desc
go

create proc buscarCliente
@textoBuscar varchar (30)
as
select *from cliente
where nombre like @textoBuscar + '%'  --Alt + 39
go


-------creacion de categoria
create proc insertarCategoria
@idCategoria int output,
@nombre varchar(30)
as
if(not exists(select *from categoria where nombre=@nombre))
begin
insert into categoria (nombre) values(@nombre)
end
go

create proc modificarCategoria
@idCategoria int,
@nombre varchar(30)
as
begin
if exists(select *from categoria where idCategoria=@idCategoria)
begin
update categoria set nombre=@nombre where idCategoria=@idCategoria;
end
else
print 'No se puede modificar por que no existe la categoria'
end
go

create proc eliminarCategoria
@idCategoria int
as
if( exists(select *from categoria where idCategoria=@idCategoria) and
not exists(select *from producto where producto.idCategoria=@idCategoria))
begin
delete from categoria where idCategoria=@idCategoria
end
go

create proc mostrarCategoria
as
select top 20 *from categoria
order by idCategoria asc
go

create proc buscarCategoria
@textoBuscar varchar (50)
as
select *from categoria
where nombre like @textoBuscar + '%'  --Alt + 39
go


----crear procedure de marca
create proc insertarMarca
@idMarca int output,
@nombre char(30)
as
begin
insert into marca (nombre) values(@nombre)
end
go


create proc modificarMarca
@idMarca int,
@nombre char(30)
as
begin
if(exists(select *from marca where idMarca=@idMarca))
begin
update marca set nombre=@nombre
where idMarca=@idMarca;
end
else
print 'No se puede modificar, por que no existe la marca'
end
go


create proc mostrarMarca
as
select top 200 *from marca
order by idMarca desc
go

create proc eliminarMarca
@idMarca int
as
if(exists(select *from marca where idMarca=@idMarca))
begin
if(not exists(select *from producto where idMarca=@idMarca))
begin
delete from marca where idMarca=@idMarca
end
else
print 'no se puede eliminar la marca por que esta registrado en el producto'
end
else
print 'no se puede eliminar la marca por que no existe'
go



create proc buscarMarca
@textoBuscar varchar(50)
as
select *from marca
where nombre like @textoBuscar + '%' ---Alta +39
go

---- crear procedure de producto
create proc insertarProducto
@idProducto int output,
@modelo char(50),
@descripcion char(100),
@precio int,
@stock int,
@marca varchar(50),
@categoria varchar(50)
as 
begin
declare @idMarca int
declare @idCategoria int
set @idMarca=(select idMarca from marca where nombre=@marca)
set @idCategoria=(select idCategoria from categoria where nombre=@categoria)
if(exists(select *from marca) and exists(select *from categoria))
begin
insert into producto values(@modelo,@descripcion,@precio,@stock,@idMarca,@idCategoria)
end
end
go


create proc modificarProducto
@idProducto int,
@modelo varchar(50),
@descripcion varchar(100),
@precio int,
@stock int,
@marca varchar(50),
@categoria varchar(50)
as
declare @idMarca int
declare @idCategoria int
set @idMarca=(select idMarca from marca where nombre=@marca)
set @idCategoria=(select idCategoria from categoria where nombre=@categoria)
if (exists(select *from producto where idProducto=@idProducto))
begin 
update producto set modelo=@modelo ,descripcion=@descripcion,
precio=@precio, stock=@stock, idMarca=@idMarca, idCategoria=@idCategoria where idProducto=@idProducto;
end
else
begin
print ' No se puede modificar ,por que no existe el producto'
end
go

create proc eliminarProducto
@idProducto int
as
if exists(select *from producto where idProducto=@idProducto) and
not exists(select *from detalleVenta where detalleVenta.idProducto=@idProducto)
begin
delete from producto where idProducto=@idProducto
end 
go

create proc buscarProducto
@textoBuscar varchar(80),
@opcion varchar(50)
as
if(@opcion='Modelo')
  begin
		select idProducto as id,modelo,descripcion,precio,stock,(marca.nombre) as marca,(categoria.nombre)as categoria 
		from producto, marca,categoria
		where producto.idMarca=marca.idMarca and producto.idCategoria=categoria.idCategoria and modelo like @textoBuscar + '%'
	end
else
	begin
		if(@opcion='Marca')
			begin 
			select idProducto as id,modelo,descripcion,precio,stock,(marca.nombre) as marca,(categoria.nombre)as categoria 
			from producto, marca,categoria
			 where producto.idMarca=marca.idMarca and producto.idCategoria=categoria.idCategoria 
			and marca.nombre like @textoBuscar + '%'
			end
		else
			begin
				if (@opcion='Categoria')
					begin
					 select idProducto as id,modelo,descripcion,precio,stock,(marca.nombre) as marca,(categoria.nombre)as categoria 
					 from producto, marca,categoria
					 where producto.idMarca=marca.idMarca and producto.idCategoria=categoria.idCategoria and categoria.nombre like @textoBuscar + '%'
					
			       end
				  else
				  begin
				  if(@opcion='Descripcion')
				  begin
				  select idProducto as id,modelo,descripcion,precio,stock,(marca.nombre) as marca,(categoria.nombre)as categoria 
					 from producto, marca,categoria
					 where producto.idMarca=marca.idMarca and producto.idCategoria=categoria.idCategoria and descripcion like @textoBuscar + '%'
				  end
				  end
				   end
				   end
 go

/*create proc buscarProducto
@textoBuscar varchar(50),
@opcion varchar(30)
as
begin
select idProducto as id,modelo,descripcion,precio,stock,(marca.nombre) as marca,(categoria.nombre)as categoria 
from producto, marca,categoria
where producto.idMarca=marca.idMarca and producto.idCategoria=categoria.idCategoria 
and @opcion= @textoBuscar + '%'
end
go
*/

go
create proc mostrarProducto
as
begin
select idProducto as id,modelo,descripcion,precio,stock,(marca.nombre) as marca,(categoria.nombre)as categoria 
from producto, marca,categoria
where producto.idMarca=marca.idMarca and producto.idCategoria=categoria.idCategoria
end
go



---- ---- create table nota venta----
------ de aqu falta ejecutar proceduree
create proc insertarNotaVenta
@idVenta int output,
@fecha date,
@montoventa money,
@idCliente int,
@idEmpleado int
as
begin
insert into notaVenta values(@fecha, @montoventa, @idCliente, @idEmpleado)
end
go

create proc modificarNotaVenta
@idVenta int,
@fecha date,
@montoventa money,
@idCliente int,
@idEmpleado int
as 
begin
if exists(select *from notaVenta where idVenta=@idVenta)
begin
update notaVenta set fecha=@fecha, montoventa=@montoventa, idCliente=@idCliente, idEmpleado=@idEmpleado
where idVenta=@idVenta;
end
else
print ' No se puede modicar , por que no existe esta venta'
end
go

create proc eliminarNotaVenta
@idVenta int
as
if exists(select *from notaVenta where idVenta=@idVenta) and
not exists(select *from detalleVenta where detalleVenta.idVenta=@idVenta)
begin
delete from notaVenta where idVenta=@idVenta
end
go

create proc mostrarNotaVenta
as
begin
select notaVenta.idVenta as id,fecha,montoVenta as Monto,cliente.nombre as cliente_nombre, cliente.paterno as cliente_paterno
, empleado.nombre as empleado_nombre ,empleado.paterno as empleado_paterno, cliente.idCliente,empleado.idEmpleado
from notaVenta, cliente, empleado 
where notaVenta.idCliente=cliente.idCliente and empleado.idEmpleado=notaVenta.idEmpleado 
order by notaVenta.idVenta desc
end
go



--- creacion de detalle venta
create proc insertarDetalleVenta
@cantidad int,
@precioVenta money,
@idProducto int
as
declare @idVenta int
begin
set @idVenta=(select MAX(idVenta)as id from notaVenta)
insert into detalleVenta values(@cantidad, @precioVenta, @idVenta, @idProducto)
update producto set stock=stock-@cantidad where idProducto=@idProducto
end
go


create proc modificarDetalleVenta
@cantidad int,
@precioVenta money,
@idVenta int,
@idProducto int
as 
begin
insert into detalleVenta values(@cantidad, @precioVenta, @idVenta, @idProducto)
update producto set stock=stock-@cantidad where idProducto=@idProducto
end
go

create proc mostrarDetalleVenta
as
select producto.idProducto as id,modelo as Producto, cantidad as Cantidad, precioVenta as Precio_Unitario,
(cantidad+precioVenta) as Total from detalleVenta,producto, notaVenta
where detalleVenta.idProducto=producto.idProducto and notaVenta.idVenta=detalleVenta.idVenta
go

create proc buscarDetalleVenta
@idVenta int
as
begin
select producto.idProducto as id,modelo as Producto, cantidad as Cantidad, precioVenta as Precio_Unitario,
(cantidad+precioVenta) as Total from detalleVenta,producto, notaVenta
where detalleVenta.idProducto=producto.idProducto and notaVenta.idVenta=detalleVenta.idVenta 
and detalleVenta.idVenta=@idVenta 
end
go


create proc eliminarDetalleVenta
@idVenta int
as
begin
delete detalleVenta where idVenta=@idVenta
end
go


--- creacion de Equipo
create proc insertarEquipo
@idEquipo int output,
@nombre varchar(50),
@descripcion varchar(70),
@modelo varchar(20),
@marca varchar(20),
@serie varchar(20)
as
begin
insert into equipo values(@nombre,@descripcion,@modelo,@marca,@serie)
end
go

create proc modificarEquipo
@idEquipo int,
@nombre varchar(50),
@descripcion varchar(70),
@modelo varchar(20),
@marca varchar(20),
@serie varchar(20)
as 
begin
if (exists( select *from equipo where idEquipo=@idEquipo))
begin
update equipo set nombre=@nombre, descripcion=@descripcion,
modelo=@modelo,marca=@marca,serie=@serie
where idEquipo=@idEquipo;
end
else
print 'No se puede Modificar, por que no existe el equipo'
end
go


create proc eliminarEquipo
@idEquipo int
as
if(exists(select *from equipo where idEquipo=@idEquipo) and
not exists(select *from detalleEquipo where detalleEquipo.idEquipo=@idEquipo))
begin
delete from equipo where idEquipo=@idEquipo
end
go

create proc mostrarEquipo
as
select top 200 *from equipo
order by idEquipo desc
go

create proc buscarEquipo
@textoBuscar varchar(50)
as
select *from equipo
where nombre like @textoBuscar + '%'
go

select *from repuesto
----insertartrabajo
create proc insertarTrabajo
@idTrabajo int output,
@nombre varchar(50),
@precio money
as
begin
insert into trabajo values(@nombre,@precio)
end
go

create proc modificarTrabajo
@idTrabajo int,
@nombre varchar(50),
@precio money
as
begin
if (exists(select *from trabajo where idTrabajo=@idTrabajo))
begin
update trabajo set nombre=@nombre,precio=@precio where idTrabajo=@idTrabajo;
end
else
print 'No se puede modicar, por que no existe el tabajo'
end
go

create proc eliminarTrabajo
@idTrabajo int
as
if (exists(select *from trabajo where idTrabajo=@idTrabajo) and
not exists(select *from detalleTrabajo where idTrabajo=@idTrabajo))
begin
delete from trabajo where idTrabajo=@idTrabajo
end
go

create proc buscarTrabajo
@textoBuscar varchar(50)
as
begin
select *from trabajo where nombre like @textoBuscar + '%' 
end
go

create proc mostrarTrabajo
as
select top 200 *from trabajo
order by idTrabajo desc
go

---

create proc  insertarRepuesto
@idRepuesto int output ,
@descripcion varchar(50),
@modelo varchar(50),
@marca varchar(50),
@stock int,
@precio money
as
begin
insert into repuesto
values(@descripcion,@modelo, @marca, @stock, @precio)
END
go

create proc eliminarRepuesto
@idRepuesto int 
AS
if exists (select *from repuesto where idRepuesto=@idRepuesto) and 
not exists (select *from detalleRepuesto where idRepuesto=@idRepuesto)
BEGIN
 delete from repuesto where idRepuesto=@idRepuesto
 END
 go

create proc modificarRepuesto
@idRepuesto int output ,
@descripcion varchar(50),
@modelo varchar(50),
@marca varchar(50),
@stock int,
@precio money
as
begin
if exists(select *from repuesto where idRepuesto=@idRepuesto)
begin
update repuesto set
descripcion=@descripcion, marca=@marca,stock=@stock, precio=@precio where idRepuesto=@idRepuesto
end 
else
print 'no se puede modificar,porque no existe el repuesto'
end 
go

create proc mostrarRepuesto
as
begin
select *from repuesto
order by idRepuesto desc
end
go

create proc buscarRepuesto
@textoBuscar varchar(50)
as
begin
select *from repuesto where descripcion like @textoBuscar + '%'
end
go


---proceso tecnico
create proc insertarTecnico
@idTecnico int output,
@nombre varchar(30),
@paterno varchar(30),
@materno varchar(30),
@telefono int,
@ci varchar(20)
as
begin
      insert into tecnico
	  values (@nombre,@paterno,@materno,@telefono,@ci)
	  end
	  go


create proc eliminarTecnico
@idTecnico int 
as
if exists (select *from tecnico where idTecnico=@idTecnico)and 
not exists (select *from ordenServicio where ordenServicio.idTecnico=@idTecnico )
begin
    delete from tecnico where idTecnico=@idTecnico
	end
go

create proc modificarTecnico
@idTecnico int output,
@nombre varchar(30),
@paterno varchar(30),
@materno varchar(30),
@telefono int,
@ci varchar(20)
as
begin
if exists(select *from tecnico where idTecnico=@idTecnico)
begin
     update tecnico set 
	 nombre=@nombre, paterno=@paterno, materno=@materno, telefono=@telefono, ci=@ci
	 where idTecnico=@idTecnico
end 
else
print 'no se puede modificar, porque no existe el tecnico'
end
go

create proc mostrarTecnico
as 
select *from tecnico
order by idTecnico desc
go

create proc buscarTecnico
@textoBuscar varchar(30)
as
begin
select *from tecnico where nombre like @textoBuscar + '%'
end
go

----proceso equipo

create proc insertarOrdenServicio
@idOrden int output,
@fecha_entrada date,
@monto_total money,
@idEmpleado int,
@idCliente int,
@idTecnico int
as
begin
insert into ordenServicio
values(@fecha_entrada,NULL,@monto_total,@idEmpleado,@idCliente,@idTecnico)
end
go

create proc eliminar_OrdenServicio
@idOrden int
as
if (exists(select *from ordenServicio where idOrden=@idOrden) and
not exists(select *from detalleEquipo where idOrden=@idOrden))
BEGIN
delete from ordenServicio where idOrden=@idOrden
end
go

create proc modificarOrdenServicio
@idOrden int ,
@fechaSalida date,
@montoTotal money,
@idEmpleado int,
@idCliente int,
@idTecnico int
as
begin
if exists (select *from ordenServicio where idOrden=@idOrden)
begin
update ordenServicio set 
fechaSalida=@fechaSalida,montoTotal=@montoTotal,
idEmpleado=@idEmpleado,idCliente=@idCliente, idTecnico=@idOrden where idOrden=@idOrden;
end 
else
 print 'no se puede modificar,porque no existe ordenservicio '
 end
go

create proc mostrarOrdenServicio
as
begin
select idOrden,fechaEntrada,fechaSalida,montoTotal as Monto,(cliente.nombre) as cliente_nombre,
 cliente.paterno as cliente_paterno,tecnico.nombre as tecnico_nombre
 ,tecnico.paterno as tecnico_paterno, empleado.nombre as empleado_nombre,
 empleado.paterno as empleado_paterno, cliente.idCliente,empleado.idEmpleado,tecnico.idTecnico
from ordenServicio, cliente, empleado ,tecnico
where ordenServicio.idCliente=cliente.idCliente and empleado.idEmpleado=ordenServicio.idEmpleado 
and ordenServicio.idTecnico=tecnico.idTecnico 
order by idOrden desc
end
go

create proc buscarOrdenServico
@idOrden int
as
begin
select *from ordenServicio where idOrden=@idOrden
end
go

create proc insertarDetalleEquipo
@idEquipo int
as
declare @idOrden int
begin
set @idOrden=(select MAX(idOrden)as id from ordenServicio)
insert into detalleEquipo values(@idEquipo,@idOrden)
end
go

create proc modificarDetalleEquipo
@idEquipo int,
@idOrden int
as
begin
insert into detalleEquipo values(@idEquipo,@idOrden)
end
go

create proc buscarDetalleEquipo
@idOrden int
as
begin
select equipo.idEquipo ,nombre as Nombre,descripcion as Descripcion,modelo as Modelo, marca as Marca, serie as Serie
from detalleEquipo, equipo, ordenServicio
where detalleEquipo.idEquipo=equipo.idEquipo and detalleEquipo.idOrden=ordenServicio.idOrden
and ordenServicio.idOrden=@idOrden
end
go

create proc eliminarDetalleEquipo
@idOrden int
as
begin
delete from detalleEquipo where idOrden=@idOrden
end
go



create proc insertarDetalleRepuesto
@idRepuesto int,
@cantidad int,
@precio money
as
declare @idOrden int
begin
set @idOrden=(select max(idOrden) as id from ordenServicio)
insert into detalleRepuesto values(@cantidad, @precio,@idOrden,@idRepuesto)
end
go

create proc modificarDetalleRepuesto
@idOrden int,
@idRepuesto int,
@cantidad int,
@precio money
as
begin
insert into detalleRepuesto values(@cantidad, @precio,@idOrden,@idRepuesto)
end
go

create proc eliminarDetalleRepuesto
@idOrden int
as
begin
delete from detalleRepuesto where idOrden=@idOrden
end
go


create proc buscarDetalleRepuesto
@idOrden int
as
begin
select repuesto.idRepuesto, descripcion as Descripcion, modelo as Modelo,marca as Marca,
cantidad,repuesto.precio as Precio
from detalleRepuesto, repuesto,ordenServicio
where detalleRepuesto.idOrden=ordenServicio.idOrden and detalleRepuesto.idRepuesto=repuesto.idRepuesto
and ordenServicio.idOrden=@idOrden
end
go

create proc insertarDetalleTrabajo
@idTrabajo int
as
declare @idOrden int
begin
set @idOrden=(select max(idOrden) as id from ordenServicio)
insert into detalleTrabajo values(@idTrabajo,@idOrden)
end
go

create proc modificarDetalleTrabajo
@idOrden int,
@idTrabajo int
as
begin
insert into detalleTrabajo values(@idTrabajo,@idOrden)
end
go

create proc eliminarDetalleTrabajo
@idOrden int
as
begin
delete from detalleTrabajo
where idOrden=@idOrden
end
go

create proc buscarDetalleTrabajo
@idOrden int
as
begin
select trabajo.idTrabajo , nombre as Nombre,precio as Precio
from detalleTrabajo, trabajo, ordenServicio
where detalleTrabajo.idTrabajo=trabajo.idTrabajo and ordenServicio.idOrden=detalleTrabajo.idOrden
and ordenServicio.idOrden=@idOrden
end
go






select *from detalleTrabajo
insert into marca values('Lenovo')
insert into marca values('hp')
insert into marca values('Samsung')
insert into marca values('Asus')
insert into marca values('Toshiba')
insert into marca values('Dell')
insert into marca values('Apple')
insert into marca values('Epson')
insert into marca values('Canon')
insert into marca values('Lg')
insert into marca values('Delux')
insert into marca values('Acer')



---actualizar todos los precios de detalle producto y de venta
update detalleVenta set preciov=(producto.precio) from producto, detalleVenta
where detalleVenta.idProducto=producto.idProducto 
and detalleVenta.idProducto in (select idProducto from detalleVenta)

select *from producto
select *from notaVenta
select *from detalleVenta

select idVenta,SUM(preciov*cantidad) as total
from detalleVenta 
group by idVenta

declare @monto money
set @monto

update notaVenta set montoventa=0

update notaVenta set montoventa=(preciov*cantidad)+montoventa from detalleVenta, notaVenta
where detalleVenta.idVenta=notaVenta.idVenta and  exists(select idVenta  from detalleVenta) and cantidad=3


select *from cliente
select *from producto
select *from trabajo
select *from ordenServicio

--Mostrar fecha, cliente,nombre del trabajo de las ordenes de servicio que se realizaron en el mes de enero
--trabajo de eliminacion de virus

declare @nombre varchar(50)
declare @fecha date
set @nombre='eliminacion de virus'
set @fecha='2018-01-01'
begin tran
if(@@ERROR=0)
begin
select ordenServicio.fecha_entrada, cliente.nombre,trabajo.nombre
from cliente,trabajo,ordenServicio,detalleTrabajo
where cliente.idCliente=ordenServicio.idCliente and trabajo.idTrabajo=detalleTrabajo.idTrabajo
and ordenServicio.idOrden=detalleTrabajo.idOrden and year(ordenServicio.fecha_entrada)=year(@fecha)
and trabajo.nombre=@nombre
commit tran
end
else
begin
print('no')
rollback tran
end


---- disminuir stock de acuerdo a ala cantidad
create trigger disminuir_Cantidad
on detalleVenta
for insert
as
declare @num int
declare @idPro int
set @idPro=(select detalleVenta.idProducto from inserted,detalleVenta)
set @num=(select stock from producto where idProducto=@idPro)
begin
if((select detalleVenta.cantidad from inserted,detalleVenta)>@num)
begin
 rollback tran
 print 'no se puede realizar la venta por que es mayor a 10'
end

end
select *from detalleVenta
select *from producto
insert into  detalleVenta values (50,3000,15,4)








alter trigger disminuirStock
on detalleVenta
for insert
as
begin
update producto set stock=stock-(i.cantidad) from inserted i
where producto.idProducto=i.idProducto 
update notaVenta set montoVenta=inserted.precioVenta*inserted.cantidad from inserted, producto
where notaVenta.idVenta=inserted.idVenta  and inserted.idProducto=producto.idProducto
end
exec insertarDetalleVenta 20,2000,1

select *from notaVenta
select *from producto


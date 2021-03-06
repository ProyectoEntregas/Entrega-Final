USE [master]
GO
/****** Object:  Database [SITIOWEB]    Script Date: 13/12/2020 1:52:05 ******/
CREATE DATABASE [SITIOWEB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SITIOWEB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\SITIOWEB.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SITIOWEB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\SITIOWEB_log.ldf' , SIZE = 1088KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SITIOWEB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SITIOWEB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SITIOWEB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SITIOWEB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SITIOWEB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SITIOWEB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SITIOWEB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SITIOWEB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SITIOWEB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SITIOWEB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SITIOWEB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SITIOWEB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SITIOWEB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SITIOWEB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SITIOWEB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SITIOWEB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SITIOWEB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SITIOWEB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SITIOWEB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SITIOWEB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SITIOWEB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SITIOWEB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SITIOWEB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SITIOWEB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SITIOWEB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SITIOWEB] SET  MULTI_USER 
GO
ALTER DATABASE [SITIOWEB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SITIOWEB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SITIOWEB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SITIOWEB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [SITIOWEB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [SITIOWEB]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 13/12/2020 1:52:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categorias](
	[Idcategoria] [int] IDENTITY(1,1) NOT NULL,
	[NombreCate] [varchar](100) NULL,
	[Descripcion] [varchar](200) NULL,
 CONSTRAINT [PK__Categori__ED5D47BCD0DC4400] PRIMARY KEY CLUSTERED 
(
	[Idcategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Compras]    Script Date: 13/12/2020 1:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compras](
	[Idcompra] [int] NOT NULL,
	[numfactura] [int] NULL,
	[Idusuario] [int] NULL,
	[Feha_compra] [date] NULL,
	[Fecha_envio] [date] NULL,
	[Idproveedor] [int] NULL,
	[Totalcompra] [smallmoney] NULL,
	[Fecha_pago] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Idcompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Detalle_venta]    Script Date: 13/12/2020 1:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Detalle_venta](
	[idVenta] [int] IDENTITY(1,1) NOT NULL,
	[nombreProducto] [varchar](80) NOT NULL,
	[cantidad] [int] NULL,
	[precio] [money] NULL,
	[descripcion] [varchar](100) NULL,
	[idUser] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Envios]    Script Date: 13/12/2020 1:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Envios](
	[Idenvio] [int] NOT NULL,
	[Compania] [varchar](100) NULL,
	[Telefono] [nchar](9) NULL,
PRIMARY KEY CLUSTERED 
(
	[Idenvio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pagos]    Script Date: 13/12/2020 1:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pagos](
	[Idpago] [int] NOT NULL,
	[Tipo_pago] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Idpago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 13/12/2020 1:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Productos](
	[Idproducto] [int] IDENTITY(1,1) NOT NULL,
	[NombreProducto] [varchar](100) NULL,
	[Precio_venta] [smallmoney] NULL,
	[Descripcion] [varchar](200) NULL,
	[Imagen] [nvarchar](max) NULL,
	[Cantidad] [int] NULL,
	[Estado] [varchar](15) NULL,
	[Idproveedor] [int] NULL,
	[Idcategoria] [int] NULL,
 CONSTRAINT [PK__Producto__9E7C0D59748A0E15] PRIMARY KEY CLUSTERED 
(
	[Idproducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 13/12/2020 1:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Proveedor](
	[Idproveedor] [int] IDENTITY(1,1) NOT NULL,
	[NombreProveedor] [varchar](200) NULL,
	[Compania] [varchar](200) NULL,
	[Direccion] [varchar](200) NULL,
	[email] [varchar](75) NULL,
	[Telefono] [nchar](500) NULL,
 CONSTRAINT [PK__Proveedo__A63E5AC7AF95AB32] PRIMARY KEY CLUSTERED 
(
	[Idproveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoUsuario]    Script Date: 13/12/2020 1:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoUsuario](
	[idTipo] [int] IDENTITY(1,1) NOT NULL,
	[TipoUsuario] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 13/12/2020 1:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[Idusuario] [int] IDENTITY(1,1) NOT NULL,
	[NombresUsuario] [varchar](200) NULL,
	[Nickusuario] [varchar](200) NULL,
	[Fecha_nacimiento] [date] NULL,
	[Genero] [char](1) NULL,
	[email] [varchar](75) NULL,
	[Direccion] [varchar](200) NULL,
	[Telefono] [nchar](9) NULL,
	[Contra] [varchar](20) NULL,
	[idTipo] [int] NULL,
 CONSTRAINT [PK__Usuario__7AC21576A96CD937] PRIMARY KEY CLUSTERED 
(
	[Idusuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 13/12/2020 1:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ventas](
	[Idventa] [int] NOT NULL,
	[Numfactura] [int] NULL,
	[Idusuario] [int] NULL,
	[Feha_venta] [date] NULL,
	[Fecha_envio] [date] NULL,
	[Idenvio] [int] NULL,
	[Idpago] [int] NULL,
	[Idproveedor] [int] NULL,
	[Total] [smallmoney] NULL,
	[Fecha_pago] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Idventa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Categorias] ON 

INSERT [dbo].[Categorias] ([Idcategoria], [NombreCate], [Descripcion]) VALUES (1, N'Ordenadores', N'Laptop y pc de Escritorio')
INSERT [dbo].[Categorias] ([Idcategoria], [NombreCate], [Descripcion]) VALUES (2, N'Sonido', N'accesorios de musica')
INSERT [dbo].[Categorias] ([Idcategoria], [NombreCate], [Descripcion]) VALUES (3, N'Hogar', N'Accesorios para hogar y mas')
INSERT [dbo].[Categorias] ([Idcategoria], [NombreCate], [Descripcion]) VALUES (4, N'Cocina', N'Todo lo necesario para utelecions de cocina')
INSERT [dbo].[Categorias] ([Idcategoria], [NombreCate], [Descripcion]) VALUES (5, N'Entretenimiento', N'Todo sobre videojuegos y dispoitivos moviles tablets y mas')
SET IDENTITY_INSERT [dbo].[Categorias] OFF
SET IDENTITY_INSERT [dbo].[Detalle_venta] ON 

INSERT [dbo].[Detalle_venta] ([idVenta], [nombreProducto], [cantidad], [precio], [descripcion], [idUser]) VALUES (12, N'Mesa de sala', 1, 95.4900, N'SMesa de cristal para sala de estar', 2)
INSERT [dbo].[Detalle_venta] ([idVenta], [nombreProducto], [cantidad], [precio], [descripcion], [idUser]) VALUES (15, N'Sofa grande', 17, 425.9900, N'Sofa para sala con parte reclinable', 2)
INSERT [dbo].[Detalle_venta] ([idVenta], [nombreProducto], [cantidad], [precio], [descripcion], [idUser]) VALUES (16, N'Laptop HP', 1, 375.9900, N'HP', 2)
INSERT [dbo].[Detalle_venta] ([idVenta], [nombreProducto], [cantidad], [precio], [descripcion], [idUser]) VALUES (17, N'Sofa grande', 1, 425.9900, N'Sofa para sala con parte reclinable', 2)
INSERT [dbo].[Detalle_venta] ([idVenta], [nombreProducto], [cantidad], [precio], [descripcion], [idUser]) VALUES (18, N'Audifonos Gaming', 1, 60.0000, N'Masacegon', 2)
INSERT [dbo].[Detalle_venta] ([idVenta], [nombreProducto], [cantidad], [precio], [descripcion], [idUser]) VALUES (19, N'Laptop HP', 1, 375.9900, N'HP', 2)
INSERT [dbo].[Detalle_venta] ([idVenta], [nombreProducto], [cantidad], [precio], [descripcion], [idUser]) VALUES (20, N'modulo grande', 20, 225.9900, N'Modulo grande para sala', 2)
SET IDENTITY_INSERT [dbo].[Detalle_venta] OFF
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([Idproducto], [NombreProducto], [Precio_venta], [Descripcion], [Imagen], [Cantidad], [Estado], [Idproveedor], [Idcategoria]) VALUES (1, N'Laptop HP', 375.9900, N'HP', N'799054-500-auto.jpg', 48, N'Nuevo', 1, 1)
INSERT [dbo].[Productos] ([Idproducto], [NombreProducto], [Precio_venta], [Descripcion], [Imagen], [Cantidad], [Estado], [Idproveedor], [Idcategoria]) VALUES (2, N'Laptop Dell', 599.9900, N'Dell', N'DEll.jpg', 89, N'Nuevo', 1, 1)
INSERT [dbo].[Productos] ([Idproducto], [NombreProducto], [Precio_venta], [Descripcion], [Imagen], [Cantidad], [Estado], [Idproveedor], [Idcategoria]) VALUES (3, N'Audifonos Gaming', 60.0000, N'Masacegon', N'gamerau.jpg', 79, N'Nuevo', 1, 2)
INSERT [dbo].[Productos] ([Idproducto], [NombreProducto], [Precio_venta], [Descripcion], [Imagen], [Cantidad], [Estado], [Idproveedor], [Idcategoria]) VALUES (4, N'Sofa grande', 425.9900, N'Sofa para sala con parte reclinable', N'sofa-grande.jpeg', 80, N'Nuevo', 1, 3)
INSERT [dbo].[Productos] ([Idproducto], [NombreProducto], [Precio_venta], [Descripcion], [Imagen], [Cantidad], [Estado], [Idproveedor], [Idcategoria]) VALUES (5, N'Sofa pequeño', 185.9900, N'Sofa pequeño para adornar sala', N'sofa-pequeño.jpg', 200, N'Nuevo', 1, 3)
INSERT [dbo].[Productos] ([Idproducto], [NombreProducto], [Precio_venta], [Descripcion], [Imagen], [Cantidad], [Estado], [Idproveedor], [Idcategoria]) VALUES (6, N'Mesa de sala', 95.4900, N'SMesa de cristal para sala de estar', N'mesa-sala.jpg', 150, N'Nuevo', 1, 3)
INSERT [dbo].[Productos] ([Idproducto], [NombreProducto], [Precio_venta], [Descripcion], [Imagen], [Cantidad], [Estado], [Idproveedor], [Idcategoria]) VALUES (7, N'ventilador de sala', 215.1900, N'Ventilador de pared ´para sala', N'ventilador-sala.jpg', 80, N'Nuevo', 1, 3)
INSERT [dbo].[Productos] ([Idproducto], [NombreProducto], [Precio_venta], [Descripcion], [Imagen], [Cantidad], [Estado], [Idproveedor], [Idcategoria]) VALUES (8, N'modulo grande', 225.9900, N'Modulo grande para sala', N'modulo-sala.jpg', 180, N'Nuevo', 1, 3)
INSERT [dbo].[Productos] ([Idproducto], [NombreProducto], [Precio_venta], [Descripcion], [Imagen], [Cantidad], [Estado], [Idproveedor], [Idcategoria]) VALUES (9, N'Television Smart TV', 635.9900, N'Televisor de 60" Smart TV', N'smartTV-sala.jpg', 120, N'Nuevo', 1, 3)
INSERT [dbo].[Productos] ([Idproducto], [NombreProducto], [Precio_venta], [Descripcion], [Imagen], [Cantidad], [Estado], [Idproveedor], [Idcategoria]) VALUES (10, N'Teatro en casa', 295.7900, N'Sistema de teatro en casa', N'teatro-sala.jpg', 200, N'Nuevo', 1, 3)
INSERT [dbo].[Productos] ([Idproducto], [NombreProducto], [Precio_venta], [Descripcion], [Imagen], [Cantidad], [Estado], [Idproveedor], [Idcategoria]) VALUES (11, N'Juego de comedor', 595.7900, N'Sistema de teatro en casa', N'juego-cocina.jpg', 200, N'Nuevo', 1, 4)
INSERT [dbo].[Productos] ([Idproducto], [NombreProducto], [Precio_venta], [Descripcion], [Imagen], [Cantidad], [Estado], [Idproveedor], [Idcategoria]) VALUES (12, N'Refrigerador Centro', 800.0900, N'Refrigeradora de ultimo modelo', N'refri-sala.jpg', 300, N'Nuevo', 1, 4)
INSERT [dbo].[Productos] ([Idproducto], [NombreProducto], [Precio_venta], [Descripcion], [Imagen], [Cantidad], [Estado], [Idproveedor], [Idcategoria]) VALUES (13, N'Alacena', 305.9900, N'Alacena de madera para cocina', N'alacena-cocina.jpg', 400, N'Nuevo', 1, 4)
INSERT [dbo].[Productos] ([Idproducto], [NombreProducto], [Precio_venta], [Descripcion], [Imagen], [Cantidad], [Estado], [Idproveedor], [Idcategoria]) VALUES (14, N'Cocina ', 295.7900, N'Cocina samsung de 4 quemadores', N'cocina-cocina.jpg', 100, N'Nuevo', 1, 4)
INSERT [dbo].[Productos] ([Idproducto], [NombreProducto], [Precio_venta], [Descripcion], [Imagen], [Cantidad], [Estado], [Idproveedor], [Idcategoria]) VALUES (15, N'Licuadora', 95.9100, N'Licuadora de 2 velocidades', N'licuadora-cocina.jpg', 50, N'Nuevo', 1, 4)
INSERT [dbo].[Productos] ([Idproducto], [NombreProducto], [Precio_venta], [Descripcion], [Imagen], [Cantidad], [Estado], [Idproveedor], [Idcategoria]) VALUES (16, N'Juego de cubiertos', 45.2900, N'Juego de cubiertos de acero', N'cubiertos-cocina.jpg', 100, N'Nuevo', 1, 4)
INSERT [dbo].[Productos] ([Idproducto], [NombreProducto], [Precio_venta], [Descripcion], [Imagen], [Cantidad], [Estado], [Idproveedor], [Idcategoria]) VALUES (17, N'TMicroondas', 125.0000, N'Microondas Samsung de 40W', N'microondas-cocina.jpg', 210, N'Nuevo', 1, 4)
INSERT [dbo].[Productos] ([Idproducto], [NombreProducto], [Precio_venta], [Descripcion], [Imagen], [Cantidad], [Estado], [Idproveedor], [Idcategoria]) VALUES (18, N'Play Station 5', 995.7900, N'Consola de videojuegos play station', N'ps5-entre.jpg', 400, N'Nuevo', 1, 5)
INSERT [dbo].[Productos] ([Idproducto], [NombreProducto], [Precio_venta], [Descripcion], [Imagen], [Cantidad], [Estado], [Idproveedor], [Idcategoria]) VALUES (19, N'Celular San¿msung s20', 1800.9900, N'Dispositivo Samsung s20', N's20-entre.jpg', 298, N'Nuevo', 1, 5)
INSERT [dbo].[Productos] ([Idproducto], [NombreProducto], [Precio_venta], [Descripcion], [Imagen], [Cantidad], [Estado], [Idproveedor], [Idcategoria]) VALUES (20, N'Ipad pro', 1205.9900, N'Ipad pro con bionic 4', N'ipad-entre.jpg', 98, N'Nuevo', 1, 5)
INSERT [dbo].[Productos] ([Idproducto], [NombreProducto], [Precio_venta], [Descripcion], [Imagen], [Cantidad], [Estado], [Idproveedor], [Idcategoria]) VALUES (21, N'Iphone 12 pro', 295.7900, N'Dispositivo iphone de la marca Aple', N'iphone-entre.jpg', 50, N'Nuevo', 1, 5)
INSERT [dbo].[Productos] ([Idproducto], [NombreProducto], [Precio_venta], [Descripcion], [Imagen], [Cantidad], [Estado], [Idproveedor], [Idcategoria]) VALUES (22, N'Celular LG', 95.9100, N'Dispositivo LG k-70', N'lg-entre.jpg', 150, N'Nuevo', 1, 4)
INSERT [dbo].[Productos] ([Idproducto], [NombreProducto], [Precio_venta], [Descripcion], [Imagen], [Cantidad], [Estado], [Idproveedor], [Idcategoria]) VALUES (23, N'SmartWatch', 425.2900, N'SmartWatch de la marca Huawei', N'smart_mirrow.jpg', 100, N'Nuevo', 1, 5)
INSERT [dbo].[Productos] ([Idproducto], [NombreProducto], [Precio_venta], [Descripcion], [Imagen], [Cantidad], [Estado], [Idproveedor], [Idcategoria]) VALUES (24, N'Nintendo Switch', 125.0000, N'Dispositivo de videojuegos de nintendo', N'switch-entre.jpg', 100, N'Nuevo', 1, 5)
INSERT [dbo].[Productos] ([Idproducto], [NombreProducto], [Precio_venta], [Descripcion], [Imagen], [Cantidad], [Estado], [Idproveedor], [Idcategoria]) VALUES (25, N'juegos de Switch', 85.0000, N'Juegos de nintendo', N'game-enter.png', 100, N'Nuevo', 1, 5)
INSERT [dbo].[Productos] ([Idproducto], [NombreProducto], [Precio_venta], [Descripcion], [Imagen], [Cantidad], [Estado], [Idproveedor], [Idcategoria]) VALUES (26, N'Wii', 225.9000, N'Consola ninendo Wii', N'wii-entre.jpg', 100, N'Nuevo', 1, 5)
INSERT [dbo].[Productos] ([Idproducto], [NombreProducto], [Precio_venta], [Descripcion], [Imagen], [Cantidad], [Estado], [Idproveedor], [Idcategoria]) VALUES (27, N'Mackook pro', 2425.9900, N'Dispositivo portatil de Aple, Mackbook pro', N'mac-orde.jpg', 70, N'Nuevo', 1, 1)
INSERT [dbo].[Productos] ([Idproducto], [NombreProducto], [Precio_venta], [Descripcion], [Imagen], [Cantidad], [Estado], [Idproveedor], [Idcategoria]) VALUES (28, N'Ordenador MAC', 2805.9900, N'Ordenador MAC de 16"', N'maci-orde.jpg', 100, N'Nuevo', 1, 1)
INSERT [dbo].[Productos] ([Idproducto], [NombreProducto], [Precio_venta], [Descripcion], [Imagen], [Cantidad], [Estado], [Idproveedor], [Idcategoria]) VALUES (29, N'Maquina de escritorio', 695.7900, N'Escritorio con sistem operativo Windows', N'pc-orde.jpg', 150, N'Nuevo', 1, 1)
INSERT [dbo].[Productos] ([Idproducto], [NombreProducto], [Precio_venta], [Descripcion], [Imagen], [Cantidad], [Estado], [Idproveedor], [Idcategoria]) VALUES (30, N' Laptop DELL', 495.9100, N'Odenaodr DELL', N'dell-enter.jpg', 150, N'Nuevo', 1, 1)
SET IDENTITY_INSERT [dbo].[Productos] OFF
SET IDENTITY_INSERT [dbo].[Proveedor] ON 

INSERT [dbo].[Proveedor] ([Idproveedor], [NombreProveedor], [Compania], [Direccion], [email], [Telefono]) VALUES (1, N'Dell', N'Dell', N'Estados Unidos', N'', N'7465-7896                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           ')
SET IDENTITY_INSERT [dbo].[Proveedor] OFF
SET IDENTITY_INSERT [dbo].[TipoUsuario] ON 

INSERT [dbo].[TipoUsuario] ([idTipo], [TipoUsuario]) VALUES (1, N'Cliente')
INSERT [dbo].[TipoUsuario] ([idTipo], [TipoUsuario]) VALUES (2, N'Admin')
SET IDENTITY_INSERT [dbo].[TipoUsuario] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Idusuario], [NombresUsuario], [Nickusuario], [Fecha_nacimiento], [Genero], [email], [Direccion], [Telefono], [Contra], [idTipo]) VALUES (2, N'Elias Jesús Quinteros Escobar', N'Elias', CAST(N'2000-07-11' AS Date), N'M', N'eliasjesu11@gmail.com', N'CL flor Blanca, frente a parque Cuscatlán ', N'70257468 ', N'123456', 2)
INSERT [dbo].[Usuario] ([Idusuario], [NombresUsuario], [Nickusuario], [Fecha_nacimiento], [Genero], [email], [Direccion], [Telefono], [Contra], [idTipo]) VALUES (5, N'Maricela', N'Mari', CAST(N'2001-04-27' AS Date), N'F', N'ej117258@gmail.com', N'CL flor Blanca, frente a parque Cuscatlán ', NULL, N'080808', 1)
INSERT [dbo].[Usuario] ([Idusuario], [NombresUsuario], [Nickusuario], [Fecha_nacimiento], [Genero], [email], [Direccion], [Telefono], [Contra], [idTipo]) VALUES (6, N'Ivan Mendoza', N'Ivan', CAST(N'2020-12-24' AS Date), N'M', N'ej117258@gmail.com', N'San Salvador', N'74589632 ', N'246810', 1)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK__Compras__Idprove__286302EC] FOREIGN KEY([Idproveedor])
REFERENCES [dbo].[Proveedor] ([Idproveedor])
GO
ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK__Compras__Idprove__286302EC]
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK__Compras__Idusuar__276EDEB3] FOREIGN KEY([Idusuario])
REFERENCES [dbo].[Usuario] ([Idusuario])
GO
ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK__Compras__Idusuar__276EDEB3]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK__Productos__Idcat__1BFD2C07] FOREIGN KEY([Idcategoria])
REFERENCES [dbo].[Categorias] ([Idcategoria])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK__Productos__Idcat__1BFD2C07]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK__Productos__Idpro__1B0907CE] FOREIGN KEY([Idproveedor])
REFERENCES [dbo].[Proveedor] ([Idproveedor])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK__Productos__Idpro__1B0907CE]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [fk_idTipo] FOREIGN KEY([idTipo])
REFERENCES [dbo].[TipoUsuario] ([idTipo])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [fk_idTipo]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD FOREIGN KEY([Idenvio])
REFERENCES [dbo].[Envios] ([Idenvio])
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD FOREIGN KEY([Idpago])
REFERENCES [dbo].[Pagos] ([Idpago])
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK__Ventas__Idprovee__21B6055D] FOREIGN KEY([Idproveedor])
REFERENCES [dbo].[Proveedor] ([Idproveedor])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK__Ventas__Idprovee__21B6055D]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK__Ventas__Idusuari__1ED998B2] FOREIGN KEY([Idusuario])
REFERENCES [dbo].[Usuario] ([Idusuario])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK__Ventas__Idusuari__1ED998B2]
GO
/****** Object:  StoredProcedure [dbo].[actualizarcarrito]    Script Date: 13/12/2020 1:52:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[actualizarcarrito](
@cant int,
@idv int
)
as
update Detalle_venta
set cantidad=@cant
where idVenta=@idv
GO
/****** Object:  StoredProcedure [dbo].[ActualizarStock]    Script Date: 13/12/2020 1:52:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[ActualizarStock]
 (
 @numer int
 )
 as
 update Productos
 set cantidad=(cantidad-1)
 where Idproducto=@numer
GO
/****** Object:  StoredProcedure [dbo].[Buscador]    Script Date: 13/12/2020 1:52:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Buscador]
(
  @BusPro varchar(80),
  @BusCat varchar(80)
)
as
select * from Productos a inner join Categorias  b on a.Idcategoria=b.Idcategoria
where a.NombreProducto=@BusPro  or b.NombreCate=@BusCat
GO
/****** Object:  StoredProcedure [dbo].[BuscadorMejorado]    Script Date: 13/12/2020 1:52:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[BuscadorMejorado]
(
  @BusPro varchar(80),
  @BusCat varchar(80)
)
as
select a.NombreProducto,a.Precio_venta,a.Descripcion,a.Imagen,a.Cantidad,a.Idcategoria from Productos a inner join Categorias  b on a.Idcategoria=b.Idcategoria
where a.NombreProducto=@BusPro  or b.NombreCate=@BusCat
GO
/****** Object:  StoredProcedure [dbo].[Carrito1]    Script Date: 13/12/2020 1:52:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Carrito1]
(
 @user varchar(80) 
 )
as
select a.idVenta, b.Nickusuario,a.cantidad,a.Precio,a.nombreProducto,a.descripcion from Detalle_venta a inner join Usuario b on a.idUser=b.Idusuario
where b.Nickusuario=@user
GO
/****** Object:  StoredProcedure [dbo].[deletecarrito]    Script Date: 13/12/2020 1:52:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[deletecarrito](
@idv int
)
as
delete Detalle_venta
where idVenta=@idv
GO
/****** Object:  StoredProcedure [dbo].[detalleCarrito]    Script Date: 13/12/2020 1:52:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  procedure [dbo].[detalleCarrito]
(
@idUsi int
)
as
select nombreProducto, sum(cantidad)as Cantidad,precio ,sum(precio*cantidad)as Total from Detalle_venta
where   idUser=@idUsi 
group by nombreProducto,precio
GO
/****** Object:  StoredProcedure [dbo].[EditarActualizarStock]    Script Date: 13/12/2020 1:52:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[EditarActualizarStock]
 (
 @u varchar(50),
 @cant int
 )
 as 
 update Productos
 set Cantidad=(Cantidad-@cant) 
 where NombreProducto= @u
GO
/****** Object:  StoredProcedure [dbo].[EditarActualizarStocksuma]    Script Date: 13/12/2020 1:52:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create procedure [dbo].[EditarActualizarStocksuma]
 (
 @u varchar(50),
 @cant int
 )
 as 
 update Productos
 set Cantidad=(Cantidad+@cant) 
 where NombreProducto= @u
GO
/****** Object:  StoredProcedure [dbo].[inicioSesion]    Script Date: 13/12/2020 1:52:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[inicioSesion](
@nom_user nvarchar(80),
@pass nvarchar(16))
as
select Nickusuario from Usuario where Nickusuario = @nom_user and Contra = @pass;


GO
/****** Object:  StoredProcedure [dbo].[MontoTotalPagar]    Script Date: 13/12/2020 1:52:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[MontoTotalPagar] (
@idUs int
)
as
select idUSer,sum(precio*cantidad)as Monto from Detalle_venta
where idUSer=@idUs
group by idUSer
GO
/****** Object:  StoredProcedure [dbo].[Perfil]    Script Date: 13/12/2020 1:52:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Perfil]
(
 @Quin varchar(20)
)
as
select NombresUsuario,Nickusuario,Fecha_nacimiento,Genero,email,Direccion,Telefono from Usuario
where Nickusuario=@Quin 
GO
/****** Object:  StoredProcedure [dbo].[Registrar]    Script Date: 13/12/2020 1:52:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Registrar] 
(
@nom varchar(200),
@Nick varchar(200),
@FN date,
@ge char(1),
@em varchar(75),
@Dire varchar(200),
@Tel nchar(9),
@c varchar(20),
@id int
)
as
insert into Usuario (Idusuario,NombresUsuario,Nickusuario,Fecha_nacimiento,Genero,email,Direccion,Telefono,Contra,idTipo) values(@nom,@Nick,@FN,@ge,@em,@em,@Dire,@Tel,@c,@id)

GO
/****** Object:  StoredProcedure [dbo].[RegistrarNew]    Script Date: 13/12/2020 1:52:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[RegistrarNew] 
(
@nom varchar(200),
@Nick varchar(200),
@FN date,
@ge char(1),
@em varchar(75),
@Dire varchar(200),
@Tel nchar(9),
@c varchar(20),
@id int
)
as
insert into Usuario  values(@nom,@Nick,@FN,@ge,@em,@Dire,@Tel,@c,@id)
GO
/****** Object:  StoredProcedure [dbo].[seleccionar]    Script Date: 13/12/2020 1:52:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[seleccionar]
(
 @user varchar(80)
)
as 
select Idusuario from Usuario
where Nickusuario=@user

GO
/****** Object:  StoredProcedure [dbo].[selecciondeProduct]    Script Date: 13/12/2020 1:52:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[selecciondeProduct](
@id int
)
as 
select * from Detalle_Venta
where idVenta=@id
GO
/****** Object:  StoredProcedure [dbo].[UpVenta]    Script Date: 13/12/2020 1:52:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UpVenta] 
(
  @nom varchar(100),
  @cant int,
  @Pr money,
  @desc varchar(max),
  @idu int 
)
as
insert into Detalle_venta values (@nom,@cant,@Pr,@desc, @idu)

GO
USE [master]
GO
ALTER DATABASE [SITIOWEB] SET  READ_WRITE 
GO

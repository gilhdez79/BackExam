USE [Examendb]
GO
/****** Object:  Table [dbo].[Articulos]    Script Date: 09/01/2023 12:00:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CodigoCN] [varchar](50) NULL,
	[Descripcion] [varchar](100) NULL,
	[Precio] [float] NULL,
	[Imagen] [varchar](250) NULL,
	[Stock] [int] NULL,
 CONSTRAINT [PK_Articulos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArticuloTienda]    Script Date: 09/01/2023 12:00:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticuloTienda](
	[idArticulo] [int] NULL,
	[idTienda] [int] NULL,
	[Fecha] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClienteArticulo]    Script Date: 09/01/2023 12:00:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClienteArticulo](
	[idCliente] [int] NULL,
	[idArticulo] [int] NULL,
	[Fecha] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 09/01/2023 12:00:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellidos] [varchar](50) NULL,
	[Direccion] [varchar](150) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tienda]    Script Date: 09/01/2023 12:00:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tienda](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Sucursal] [varchar](50) NULL,
	[Direccion] [varchar](50) NULL,
 CONSTRAINT [PK_Tienda] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Articulos] ON 

INSERT [dbo].[Articulos] ([id], [CodigoCN], [Descripcion], [Precio], [Imagen], [Stock]) VALUES (1, N'00052451', N'Tapete 30x46', 140, N'https://picsum.photos/200/300', 25)
INSERT [dbo].[Articulos] ([id], [CodigoCN], [Descripcion], [Precio], [Imagen], [Stock]) VALUES (2, N'00052451', N'Tapete 30x45', 150, N'https://picsum.photos/200/300', 16)
INSERT [dbo].[Articulos] ([id], [CodigoCN], [Descripcion], [Precio], [Imagen], [Stock]) VALUES (3, N'Samy', N'00004', 0, NULL, 125)
INSERT [dbo].[Articulos] ([id], [CodigoCN], [Descripcion], [Precio], [Imagen], [Stock]) VALUES (4, N'Samy', N'00004', 0, NULL, 125)
INSERT [dbo].[Articulos] ([id], [CodigoCN], [Descripcion], [Precio], [Imagen], [Stock]) VALUES (5, N'Samy', N'00004', 0, NULL, 126)
INSERT [dbo].[Articulos] ([id], [CodigoCN], [Descripcion], [Precio], [Imagen], [Stock]) VALUES (6, N'Samy', N'00004', 0, NULL, 126)
INSERT [dbo].[Articulos] ([id], [CodigoCN], [Descripcion], [Precio], [Imagen], [Stock]) VALUES (7, N'Samy', N'00004', 0, N'https://picsum.photos/200/300', 126)
SET IDENTITY_INSERT [dbo].[Articulos] OFF
GO
SET IDENTITY_INSERT [dbo].[Tienda] ON 

INSERT [dbo].[Tienda] ([id], [Sucursal], [Direccion]) VALUES (1, N'Centro', N'Av. Colin Norte No 101, CP 58745')
SET IDENTITY_INSERT [dbo].[Tienda] OFF
GO
ALTER TABLE [dbo].[ArticuloTienda]  WITH CHECK ADD  CONSTRAINT [FK_ArticuloTienda_Articulos] FOREIGN KEY([idArticulo])
REFERENCES [dbo].[Articulos] ([id])
GO
ALTER TABLE [dbo].[ArticuloTienda] CHECK CONSTRAINT [FK_ArticuloTienda_Articulos]
GO
ALTER TABLE [dbo].[ArticuloTienda]  WITH CHECK ADD  CONSTRAINT [FK_ArticuloTienda_Tienda] FOREIGN KEY([idTienda])
REFERENCES [dbo].[Tienda] ([id])
GO
ALTER TABLE [dbo].[ArticuloTienda] CHECK CONSTRAINT [FK_ArticuloTienda_Tienda]
GO
ALTER TABLE [dbo].[ClienteArticulo]  WITH CHECK ADD  CONSTRAINT [FK_ClienteArticulo_Articulos] FOREIGN KEY([idArticulo])
REFERENCES [dbo].[Articulos] ([id])
GO
ALTER TABLE [dbo].[ClienteArticulo] CHECK CONSTRAINT [FK_ClienteArticulo_Articulos]
GO
ALTER TABLE [dbo].[ClienteArticulo]  WITH CHECK ADD  CONSTRAINT [FK_ClienteArticulo_Clientes] FOREIGN KEY([idCliente])
REFERENCES [dbo].[Clientes] ([id])
GO
ALTER TABLE [dbo].[ClienteArticulo] CHECK CONSTRAINT [FK_ClienteArticulo_Clientes]
GO

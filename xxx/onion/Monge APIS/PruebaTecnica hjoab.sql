USE [PruebaTecnica]
GO

/****** Object:  Table [dbo].[Products]    Script Date: 11/4/2022 8:04:48 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Barcode] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Rate] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET IDENTITY_INSERT  [dbo].[Products] ON

INSERT [dbo].[Products] ([Id],[Name],[Barcode],[Description],[Rate]) VALUES (1,N'Refri', 12345, N'Refrigeradora grande', 9)
INSERT [dbo].[Products] ([Id],[Name],[Barcode],[Description],[Rate]) VALUES (2,N'Celular ', 123456,N'Celular Inteligente', 9 )
INSERT [dbo].[Products] ([Id],[Name],[Barcode],[Description],[Rate]) VALUES (3,N'Cocina', 34567,N'Cocina electrica de discos', 9 )
INSERT [dbo].[Products] ([Id],[Name],[Barcode],[Description],[Rate]) VALUES (4,N'Microondas', 45678, N'Microondas de 15 litros', 9)

SET IDENTITY_INSERT  [dbo].[Products] OFF

/****** Object:  Table [dbo].[Articulo]    Script Date: 10/4/2022 4:42:11 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Articulo](
	[IdArticulo] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[IdMarca] [int] NOT NULL,
	[Sku] [int] NOT NULL,
 CONSTRAINT [PK_Articulo] PRIMARY KEY CLUSTERED 
(
	[IdArticulo] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT  [dbo].[Articulo] ON

INSERT [dbo].[Articulo] ([IdArticulo], [Descripcion], [IdMarca], [Sku]) VALUES (1, N'Refri', 1, 12345)
INSERT [dbo].[Articulo] ([IdArticulo], [Descripcion], [IdMarca], [Sku]) VALUES (2, N'Celular ', 4, 23456)
INSERT [dbo].[Articulo] ([IdArticulo], [Descripcion], [IdMarca], [Sku]) VALUES (3, N'Cocina', 3, 34567)
INSERT [dbo].[Articulo] ([IdArticulo], [Descripcion], [IdMarca], [Sku]) VALUES (4, N'Microondas', 2, 45678)

SET IDENTITY_INSERT  [dbo].[Articulo] OFF

/****** Object:  Table [dbo].[Marca]    Script Date: 10/4/2022 4:42:41 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Marca](
	[IdMarca] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED 
(
	[IdMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT  [dbo].[Marca] ON

INSERT [dbo].[Marca] ([IdMarca], [Descripcion]) VALUES (1, N'Telstar')
INSERT [dbo].[Marca] ([IdMarca], [Descripcion]) VALUES (2, N'LG')
INSERT [dbo].[Marca] ([IdMarca], [Descripcion]) VALUES (3, N'MABE')
INSERT [dbo].[Marca] ([IdMarca], [Descripcion]) VALUES (4, N'Huawei')

SET IDENTITY_INSERT  [dbo].[Marca] OFF


/****** Object:  StoredProcedure [dbo].[usp_ConsultaArticulos]    Script Date: 10/4/2022 4:25:04 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Batch submitted through debugger: PruebaTecnica.sql|37|0|T:\DEV\repos\gl\hjoab\mongepruebatecnica\Enunciado\PruebaTecnica.sql

CREATE PROCEDURE [dbo].[usp_ConsultaArticulos]
AS
BEGIN

	SET NOCOUNT ON;

    
	SELECT a.IdArticulo, 
		   a.Descripcion,
		   a.sku As Sku,
		   b.IdMarca, 
		   b.Descripcion  As  Marca
	from Articulo a WITH(NOLOCK)
	inner join Marca b WITH(NOLOCK) ON a.IdMarca = b.IdMarca
END
GO

/****** Object:  View [dbo].[ArticulosMarcas]    Script Date: 10/4/2022 4:20:54 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create VIEW [dbo].[ArticulosMarcas]
AS
SELECT        a.IdArticulo, a.Descripcion, a.Sku, b.IdMarca, b.Descripcion AS Marca
FROM            dbo.Articulo AS a WITH (NOLOCK) INNER JOIN
                         dbo.Marca AS b WITH (NOLOCK) ON a.IdMarca = b.IdMarca
GO



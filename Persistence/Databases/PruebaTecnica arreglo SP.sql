USE [PruebaTecnica]
GO
/****** Object:  StoredProcedure [dbo].[usp_ConsultaArticulos]    Script Date: 30/3/2022 2:25:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: PruebaTecnica.sql|37|0|T:\DEV\repos\gl\hjoab\mongepruebatecnica\Enunciado\PruebaTecnica.sql

ALTER PROCEDURE [dbo].[usp_ConsultaArticulos]
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

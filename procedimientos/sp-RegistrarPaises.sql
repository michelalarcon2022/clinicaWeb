USE [DBClinica_test]
GO
/****** Object:  StoredProcedure [dbo].[spRegistrarMenu]    Script Date: 30/06/2022 11:51:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[spRegistrarPais]
(@prmNombre varchar(100)
 )
 AS
	BEGIN

	INSERT INTO Paises(nombre)
	VALUES(@prmNombre)
	END

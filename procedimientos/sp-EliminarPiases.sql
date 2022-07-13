USE [DBClinica_test]
GO
/****** Object:  StoredProcedure [dbo].[spEliminarMenu]    Script Date: 30/06/2022 12:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[spEliminarPais]
(@prmIdPais int)
AS
	BEGIN
		UPDATE Paises
		SET estado = 0
		WHERE id= @prmIdPais
	END


--USE [ERP_GMEDINA]
--GO
--/****** Object:  StoredProcedure [rrhh].[UDP_RRHH_tbDepartamentos_Update]    Script Date: 12/12/2019 8:59:58 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
-- ALTER PROCEDURE [rrhh].[UDP_RRHH_tbDepartamentos_Update]
--	(
--		@depto_Id int,
--		@area_Id int,
--		@Car_Descripcion nvarchar(50),
--		@depto_Descripcion nvarchar(100),
--		@depto_UsuarioModifica int,
--		@depto_FechaModifica datetime
--	) AS
--	set nocount on;
--	BEGIN
--		BEGIN TRY
--			BEGIN TRAN
--				declare @Id int
--				set @Id = @depto_Id
--				UPDATE [rrhh].[tbDepartamentos]
--				SET 
--					area_Id = @area_Id,
--					depto_Descripcion = @depto_Descripcion,		
--					depto_UsuarioModifica = @depto_UsuarioModifica,
--					depto_FechaModifica = @depto_FechaModifica
--				WHERE depto_Id  = @depto_Id AND depto_Estado = 1
--				SELECT CAST(@Id AS VARCHAR) AS MensajeError
--				COMMIT TRAN
--		END TRY
--		BEGIN CATCH
--			ROLLBACK TRAN
--			SELECT '-1 ' + ERROR_MESSAGE() AS MensajeError
--		END CATCH
--	END

USE [ERP_GMEDINA]
GO
/****** Object:  StoredProcedure [rrhh].[UDP_RRHH_tbDepartamentos_Update]    Script Date: 12/12/2019 8:59:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 ALTER PROCEDURE [rrhh].[UDP_RRHH_tbDepartamentos_Update]
	(
		@depto_Id int,
		@area_Id int,
		@Car_Descripcion nvarchar(50),
		@depto_Descripcion nvarchar(100),
		@depto_UsuarioModifica int,
		@depto_FechaModifica datetime
	) AS
	set nocount on;
	BEGIN
	BEGIN TRY
	BEGIN TRAN
	declare @car_Id int
	declare @Id int
	set @Id = @depto_Id
	UPDATE [rrhh].[tbDepartamentos]
	SET area_Id = @area_Id,
		--car_Id = @car_Id,
	    depto_Descripcion = @depto_Descripcion,		
		depto_UsuarioModifica = @depto_UsuarioModifica,
		depto_FechaModifica = @depto_FechaModifica,
		@car_Id=car_Id
	WHERE depto_Id  = @depto_Id 
	UPDATE [rrhh].[tbCargos]
	  SET
		[car_Descripcion]=@Car_Descripcion
	  WHERE [car_Id]=@car_Id
      SELECT
        CAST(@Id AS VARCHAR) AS MensajeError
	COMMIT TRAN
	END TRY
	BEGIN CATCH
	ROLLBACK TRAN
	SELECT '-1 ' + ERROR_MESSAGE() AS MensajeError
	END CATCH
	END

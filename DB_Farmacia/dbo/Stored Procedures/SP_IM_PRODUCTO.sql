﻿-- =============================================
-- Author:		<Author,,Jeanneth Mota>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_IM_PRODUCTO] (
    @PROD_INT_ID    UNIQUEIDENTIFIER,
    @PROD_NOMBRE     VARCHAR(50),
    @PROD_SYS_NAME   VARCHAR(50),
	@PROD_PRE_V      DECIMAL(16,2),
	@PROD_PRE_C      DECIMAL(16,2),
	@PROD_CANT       INT,
	@CAT_INT_ID      UNIQUEIDENTIFIER,
	@PROD_STATUS     BIT,
	@PROD_IMAGE		 VARBINARY(MAX)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   BEGIN TRANSACTION

    BEGIN TRY

	IF NOT EXISTS ( SELECT * FROM TBL_PRODUCTO WHERE PROD_INT_ID = @PROD_INT_ID)
	  BEGIN
		  INSERT INTO [dbo].[TBL_PRODUCTO]
            (
				[PROD_INT_ID]
			   ,[PROD_NOMBRE]
			   ,[PROD_SYS_NAME]
			   ,[PROD_PRE_V]
			   ,[PROD_PRE_C]
			   ,[PROD_CANT]
			   ,[CAT_INT_ID]
			   ,[PROD_STATUS]
			   ,[PROD_IMAGE]
			   )
			 VALUES
			   (
					NEWID(),
					@PROD_NOMBRE,
					@PROD_SYS_NAME,
					@PROD_PRE_V,
					@PROD_PRE_C,
					@PROD_CANT,
					@CAT_INT_ID,
					@PROD_STATUS,
					@PROD_IMAGE
			   )

		END
        ELSE
		   BEGIN
				UPDATE TBL_PRODUCTO
				SET PROD_NOMBRE = @PROD_NOMBRE,
					PROD_SYS_NAME = @PROD_SYS_NAME,
					PROD_PRE_V = @PROD_PRE_V,
					PROD_PRE_C = @PROD_PRE_C,
					PROD_CANT = @PROD_CANT,
					CAT_INT_ID = @CAT_INT_ID,
					PROD_STATUS = @PROD_STATUS,
					PROD_IMAGE = @PROD_IMAGE
			  WHERE PROD_INT_ID = @PROD_INT_ID

		  END

   COMMIT TRANSACTION

   END TRY
   BEGIN CATCH
        ROLLBACK TRANSACTION 

    END CATCH
END
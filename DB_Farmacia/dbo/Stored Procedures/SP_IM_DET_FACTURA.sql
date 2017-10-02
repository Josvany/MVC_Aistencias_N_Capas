-- =============================================
-- Author:		<Author,,Jeanneth Mota>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_IM_DET_FACTURA] (
    @FAC_DET_INT_ID     UNIQUEIDENTIFIER,
    @FAC_NUM			VARCHAR(100),
	@PROD_INT_ID        UNIQUEIDENTIFIER,
	@FAC_DET_CANTIDAD   INT,
	@FAC_DET_PRECIO     DECIMAL(16,2),
	@FAC_DET_FECHA      DATETIME
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   BEGIN TRANSACTION

    BEGIN TRY

	  IF NOT EXISTS(SELECT * FROM TBL_DET_FACTURA WHERE FAC_DET_INT_ID = @FAC_DET_INT_ID)
	  BEGIN

     INSERT INTO [dbo].[TBL_DET_FACTURA]
              (
				[FAC_DET_INT_ID]
			   ,[FAC_INT_ID]
			   ,[PROD_INT_ID]
			   ,[FAC_DET_CANTIDAD]
			   ,[FAC_DET_PRECIO]
			   ,[FAC_DET_FECHA]
		      )
		VALUES
			   (
					NEWID(),
					(SELECT FAC_INT_ID FROM TBL_FACTURA WHERE FAC_NUMBER=@FAC_NUM),
					@PROD_INT_ID,
					@FAC_DET_CANTIDAD,
					@FAC_DET_PRECIO,
					@FAC_DET_FECHA	
			   )

		END
        ELSE
		   BEGIN
				UPDATE TBL_DET_FACTURA
				SET PROD_INT_ID = @PROD_INT_ID,
					FAC_DET_CANTIDAD = @FAC_DET_CANTIDAD,
					FAC_DET_PRECIO = @FAC_DET_PRECIO,
					FAC_DET_FECHA = FAC_DET_FECHA
			  WHERE FAC_DET_INT_ID = @FAC_DET_INT_ID

		  END

   COMMIT TRANSACTION

   END TRY
   BEGIN CATCH
        ROLLBACK TRANSACTION 

    END CATCH
END
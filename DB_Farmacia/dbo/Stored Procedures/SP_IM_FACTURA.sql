-- Batch submitted through debugger: SQLQuery12.sql|7|0|C:\Users\Josvany_G\AppData\Local\Temp\~vsBD12.sql
-- =============================================
-- Author:		<Author,,Jeanneth Mota>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_IM_FACTURA] (
	@FAC_NUMBER     NVARCHAR(50),
	@PAG_INT_ID     UNIQUEIDENTIFIER,
	@FAC_FECHA      DATETIME,
	@USE_LOGIN      VARCHAR(100)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   BEGIN TRANSACTION

    BEGIN TRY

	  IF  NOT EXISTS (SELECT * FROM TBL_FACTURA WHERE FAC_NUMBER=  @FAC_NUMBER)
	  BEGIN

		INSERT INTO [dbo].[TBL_FACTURA]
           (
			    [FAC_INT_ID]
			   ,[FAC_NUMBER]
			   ,[PAG_INT_ID]
			   ,[FAC_FECHA]
			   ,[USE_INT_ID]
		   )
			 VALUES
			   (
					NEWID(),
					@FAC_NUMBER,
					@PAG_INT_ID,
					@FAC_FECHA,
					(SELECT USE_INT_ID FROM TBL_USER WHERE USE_LOGIN=@USE_LOGIN)
			   )

		END
        ELSE
		   BEGIN
			DECLARE @TOTAL_S  AS DECIMAL(18,2)
			DECLARE @DISCOUT AS DECIMAL(18,2)
			DECLARE @IVA AS DECIMAL(18,2)
			DECLARE @TOTAL AS DECIMAL(18,2)
			

			SET @TOTAL_S = (SELECT SUM(FAC_DET_CANTIDAD * FAC_DET_PRECIO)  FROM TBL_DET_FACTURA WHERE FAC_DET_INT_ID = (SELECT FAC_DET_INT_ID FROM TBL_FACTURA WHERE FAC_NUMBER =@FAC_NUMBER))
			--SELECT @TOTAL_S
			SET @IVA = @TOTAL_S * 0.15
			--SELECT @IVA

			IF (@TOTAL_S > 1000)
			BEGIN
				SET @DISCOUT = @TOTAL_S * 0.05
			END
			ELSE
			BEGIN
				SET @DISCOUT = 0
			END
			SET @TOTAL = (@TOTAL_S + @IVA) - @DISCOUT
			

			--SELECT @TOTAL
			

				UPDATE TBL_FACTURA
				SET PAG_INT_ID = @PAG_INT_ID,
					FAC_SUB_TOTAL = @TOTAL_S,
					FAC_IVA = @IVA,
					FAC_DESCUENTO = @DISCOUT,
					FAC_TOTAL = @TOTAL
			  WHERE FAC_NUMBER = @FAC_NUMBER


			  DELETE FROM TBL_TEM_PEDI WHERE TEM_USER_LOGIN = @USE_LOGIN
		  END

   COMMIT TRANSACTION

   END TRY
   BEGIN CATCH
        ROLLBACK TRANSACTION 

    END CATCH
END
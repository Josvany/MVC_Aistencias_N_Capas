-- =============================================
-- Author:		<Author,,Jeanneth Mota>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_IM_USER] (
    @USE_INT_ID     UNIQUEIDENTIFIER,
	@USE_INF_INT_ID UNIQUEIDENTIFIER,
	@USE_LOGIN      VARCHAR(100),
    @USE_PASS       VARCHAR(100),
	@ROL_INT_ID     UNIQUEIDENTIFIER,
	@USE_STATUS     BIT
    
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   BEGIN TRANSACTION

    BEGIN TRY

IF NOT EXISTS (SELECT * FROM TBL_USER WHERE USE_INT_ID = @USE_INT_ID)
BEGIN
	  IF ( @USE_INF_INT_ID = CAST(CAST( 0 AS BINARY) AS UNIQUEIDENTIFIER))
	  BEGIN 
		SET @USE_INF_INT_ID = NULL
	  END

	  IF ( @ROL_INT_ID = CAST(CAST( 0 AS BINARY) AS UNIQUEIDENTIFIER))
	  BEGIN 
		SET @ROL_INT_ID = NULL
	  END

		INSERT INTO [dbo].[TBL_USER]
             (
			    [USE_INT_ID]
			   ,[USE_INF_INT_ID]
			   ,[USE_LOGIN]
			   ,[USE_PASS]
			   ,[ROL_INT_ID]
			   ,[USE_STATUS]
		       )
			 VALUES
			   (
					NEWID(),
					@USE_INF_INT_ID,
					@USE_LOGIN,
					@USE_PASS,
					@ROL_INT_ID,
					@USE_STATUS
			   )

		END
        ELSE
		   BEGIN
				UPDATE TBL_USER
				SET USE_PASS = @USE_PASS,
					ROL_INT_ID = @ROL_INT_ID,
					USE_STATUS = @USE_STATUS
			  WHERE USE_INT_ID = @USE_INT_ID

		  END

   COMMIT TRANSACTION

   END TRY
   BEGIN CATCH
        ROLLBACK TRANSACTION 

    END CATCH
END
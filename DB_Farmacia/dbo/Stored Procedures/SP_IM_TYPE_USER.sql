﻿-- =============================================
-- Author:		<Author,,Jeanneth Mota>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_IM_TYPE_USER] (
    @CatTypUser   UNIQUEIDENTIFIER = NULL,
    @Cat_typ_Name   VARCHAR(50)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   BEGIN TRANSACTION

    BEGIN TRY

	  IF NOT EXISTS ( SELECT * FROM CAT_TYPE_USER WHERE CAT_TYP_USER = @CatTypUser)
	  BEGIN

			INSERT INTO [dbo].[CAT_TYPE_USER]
			   (
				    [CAT_TYP_USER]
				   ,[CAT_TYP_NAME]
			   )
			 VALUES
			   (
					NEWID(),
					@Cat_typ_Name
			   )

	    END
        ELSE
		   BEGIN
				UPDATE CAT_TYPE_USER
				SET CAT_TYP_NAME = @Cat_typ_Name
			  WHERE CAT_TYP_USER = @CatTypUser

		  END

   COMMIT TRANSACTION

   END TRY
   BEGIN CATCH
        ROLLBACK TRANSACTION 

    END CATCH
END
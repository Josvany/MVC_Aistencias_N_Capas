-- =============================================
-- Author:		<Author,,Jeanneth Mota>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_ALL_ROLE] 

AS
BEGIN
	SET NOCOUNT ON;

	SELECT ROL_INT_ID,ROL_NAME FROM CAT_ROLE
END
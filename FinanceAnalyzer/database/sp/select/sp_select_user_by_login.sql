CREATE PROCEDURE [dbo].[sp_select_user_by_login]
	@login NVARCHAR(50)
AS
BEGIN
	SELECT * 
	FROM [dbo].[User]
	WHERE [Login] = @login
END
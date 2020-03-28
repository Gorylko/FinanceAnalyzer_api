CREATE PROCEDURE [dbo].[sp_select_salt_by_user_login]
	@login NVARCHAR(50)
AS
BEGIN
	SELECT [PasswordSalt]
	FROM [dbo].[User]
	WHERE [Login] = @login
END
CREATE PROCEDURE [dbo].[sp_select_user_by_login_and_password](
	@login NVARCHAR(50),
	@password VARBINARY(MAX)
	)
AS
BEGIN
	SELECT * 
	FROM [dbo].[User]
	WHERE [Login] = @login AND [Password] = @password
END
CREATE PROCEDURE [dbo].[sp_insert_user]
(
    @login NVARCHAR(50),
    @password VARBINARY(MAX),
	@passwordSalt VARBINARY(MAX)
)
AS
BEGIN
	INSERT INTO [dbo].[User] ([Login], [Password], [PasswordSalt]) VALUES (@login, @password, @passwordSalt)
END
GO
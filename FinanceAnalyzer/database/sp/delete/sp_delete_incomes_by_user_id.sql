CREATE PROCEDURE [dbo].[sp_delete_incomes_by_user_id]
	@userId INT
AS
BEGIN
	DELETE FROM [dbo].[Income] WHERE [UserId] = @userId
END
GO
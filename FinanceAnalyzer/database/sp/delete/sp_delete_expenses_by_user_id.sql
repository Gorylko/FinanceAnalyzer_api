CREATE PROCEDURE [dbo].[sp_delete_expenses_by_user_id]
	@userId INT
AS
BEGIN
	DELETE FROM [dbo].[Expense] WHERE [UserId] = @userId
END
GO
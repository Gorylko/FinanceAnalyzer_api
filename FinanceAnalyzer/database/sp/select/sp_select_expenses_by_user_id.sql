CREATE PROCEDURE [dbo].[sp_select_expenses_by_user_id]
	@userId INT
AS
BEGIN
	SELECT * 
	FROM [dbo].[Expense]
	WHERE [UserId] = @userId
END
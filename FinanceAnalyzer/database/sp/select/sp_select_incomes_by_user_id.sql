CREATE PROCEDURE [dbo].[sp_select_incomes_by_user_id]
	@userId INT
AS
BEGIN
	SELECT * 
	FROM [dbo].[Income]
	WHERE [UserId] = @userId
END
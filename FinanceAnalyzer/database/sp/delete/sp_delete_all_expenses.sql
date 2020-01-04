CREATE PROCEDURE [dbo].[sp_delete_all_expenses]
AS
BEGIN
	DELETE FROM [dbo].[Expense]
END
GO
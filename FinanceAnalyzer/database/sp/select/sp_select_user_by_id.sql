CREATE PROCEDURE [dbo].[sp_select_user_by_id]
	@id INT
AS
BEGIN
	SELECT * 
	FROM [dbo].[User]
	WHERE [Id] = @id
END
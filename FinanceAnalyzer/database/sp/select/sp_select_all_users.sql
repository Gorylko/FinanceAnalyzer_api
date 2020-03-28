CREATE PROCEDURE [dbo].[sp_select_all_users]
AS
BEGIN
	SELECT * FROM [dbo].[User]
END
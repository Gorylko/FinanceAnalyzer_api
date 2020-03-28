CREATE PROCEDURE [dbo].[sp_insert_finance_operation_history]
(
	@userId INT,
	@operationType NVARCHAR(20),
	@date DATETIME,
	@amount DECIMAL(10, 3)
)
AS
BEGIN
	INSERT INTO [dbo].[FinanceOperationHistory] ([UserId], [OperationType], [Date], [Amount])
	VALUES (@userId, @operationType, @date, @amount)
END

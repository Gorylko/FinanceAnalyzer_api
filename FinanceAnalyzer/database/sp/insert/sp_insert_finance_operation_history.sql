CREATE PROCEDURE [dbo].[sp_insert_finance_operation_history]
(
	@userId INT,
	@date DATETIME,
	@amount DECIMAL(10, 3)
)
AS
BEGIN
	INSERT INTO [dbo].[FinanceOperationHistory] ([UserId], [OperationType], [Amount])
	VALUES (@userId, @date, @amount)
END

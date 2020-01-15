set user="gorylko"
set password="Rbhbkk78901234"
set server="kiryl.database.windows.net"
set database="FinanceAnalyser"
set currentPath=%~dp0

sqlcmd -S %server% -d %database% -U %user% -P %password% -i drop_all_tables.sql
sqlcmd -S %server% -d %database% -U %user% -P %password% -i create_tables.sql

sqlcmd -S %server% -d %database% -U %user% -P %password% -i sp\delete\sp_delete_all_expenses
sqlcmd -S %server% -d %database% -U %user% -P %password% -i sp\delete\sp_delete_all_incomes

sqlcmd -S %server% -d %database% -U %user% -P %password% -i sp\insert\sp_insert_expense
sqlcmd -S %server% -d %database% -U %user% -P %password% -i sp\insert\sp_insert_income
sqlcmd -S %server% -d %database% -U %user% -P %password% -i sp\insert\sp_insert_user

sqlcmd -S %server% -d %database% -U %user% -P %password% -i sp\select\sp_select_all_users.sql
sqlcmd -S %server% -d %database% -U %user% -P %password% -i sp\select\sp_select_expenses_by_user_id.sql
sqlcmd -S %server% -d %database% -U %user% -P %password% -i sp\select\sp_select_incomes_by_user_id.sql
sqlcmd -S %server% -d %database% -U %user% -P %password% -i sp\select\sp_select_user_by_id.sql
sqlcmd -S %server% -d %database% -U %user% -P %password% -i sp\select\sp_select_user_by_login.sql
sqlcmd -S %server% -d %database% -U %user% -P %password% -i sp\select\sp_select_user_by_login_and_password.sql
sqlcmd -S %server% -d %database% -U %user% -P %password% -i sp\select\sq_select_salt_by_user_login.sql

pause
set user="gorylko"
set password="Rbhbkk78901234"
set server="kiryl.database.windows.net"
set database="FinanceAnalyser"
set currentPath=%~dp0

sqlcmd -S %server% -d %database% -U %user% -P %password% -i drop_all_tables.sql
sqlcmd -S %server% -d %database% -U %user% -P %password% -i create_tables.sql


pause
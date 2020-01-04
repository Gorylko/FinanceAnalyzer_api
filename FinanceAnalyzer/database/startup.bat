set user="admin"
set password="panties7890"
set server="COMPUDAHTER"
set currentPath=%~dp0

sqlcmd -S %server% -i drop_db.sql
sqlcmd -S %server% -i create_db.sql

sqlcmd -S %server% -i sq\select\sp_select_income_by_user_id.sql
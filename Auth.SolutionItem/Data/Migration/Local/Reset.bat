


 
@echo off
cls
"C:\Program Files\Microsoft SQL Server\110\Tools\Binn\sqlcmd" -E -S .\sqlexpress -i ../Local/DropDb.sql
"C:\Program Files\Microsoft SQL Server\110\Tools\Binn\sqlcmd" -E -S .\sqlexpress -i ../2013-05-19/Migration.sql  

pause






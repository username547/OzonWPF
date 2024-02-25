DECLARE @tableName NVARCHAR(128)
DECLARE tableCursor CURSOR FOR
SELECT name
FROM sys.tables

OPEN tableCursor
FETCH NEXT FROM tableCursor INTO @tableName

WHILE @@FETCH_STATUS = 0
BEGIN
    EXEC ('DROP TABLE ' + @tableName)
    FETCH NEXT FROM tableCursor INTO @tableName
END

CLOSE tableCursor
DEALLOCATE tableCursor
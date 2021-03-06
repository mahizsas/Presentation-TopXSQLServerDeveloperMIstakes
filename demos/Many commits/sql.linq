<Query Kind="SQL">
  <Connection>
    <ID>6f1893f0-280f-4d88-a5b4-df41106dddae</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Test</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

-- Reset
USE tempdb
IF(EXISTS(SELECT * FROM sys.databases WHERE name = 'TopXDeveloperMistakes')) BEGIN
	ALTER DATABASE TopXDeveloperMistakes SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	DROP DATABASE TopXDeveloperMistakes	
END
CREATE DATABASE TopXDeveloperMistakes
GO
USE TopXDeveloperMistakes


-- Create table
CREATE TABLE Images
(
	Number smallint,
	Size int
)


-- Reset waits
TRUNCATE TABLE Images
DBCC SQLPERF('sys.dm_os_wait_stats', CLEAR)


-- Output waits
SELECT
	*
FROM
	sys.dm_os_wait_stats
WHERE
	wait_type = 'WRITELOG'
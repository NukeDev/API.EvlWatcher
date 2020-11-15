
CREATE PROCEDURE [dbo].[InsertApiLog]
	@id varchar(50),
	@io char(2),
	@type varchar(150),
	@method varchar(50),
	@uri varchar(500),
	@ipaddress varchar(20),
	@body text null
AS
BEGIN
	SET NOCOUNT ON;        

	INSERT INTO [dbo].[TS_ApiLog] ([ID], [IO], [Type], [Method], [URI], [IPAddress], [Body], [InsertDate])
	VALUES (@id, @io, @type, @method, @uri, @ipaddress, @body, SYSDATETIMEOFFSET())
END


CREATE PROCEDURE [dbo].[InsertApiErrorLog]
	@id varchar(50),
	@exception text null
AS
BEGIN
	SET NOCOUNT ON;        

	INSERT INTO [dbo].[TS_ApiErrorsLog] ([ID], [Exception], [InsertDate])
	VALUES (@id, @exception, SYSDATETIMEOFFSET())
END
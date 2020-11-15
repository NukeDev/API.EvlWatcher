CREATE TABLE [dbo].[TS_ApiErrorsLog] (
    [PK]         INT                IDENTITY (1, 1) NOT NULL,
    [ID]         VARCHAR (50)       NOT NULL,
    [Exception]  TEXT               NULL,
    [InsertDate] DATETIMEOFFSET (7) NOT NULL,
    PRIMARY KEY CLUSTERED ([PK] ASC)
);


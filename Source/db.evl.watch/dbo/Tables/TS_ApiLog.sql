CREATE TABLE [dbo].[TS_ApiLog] (
    [PK]         INT                IDENTITY (1, 1) NOT NULL,
    [ID]         VARCHAR (50)       NOT NULL,
    [IO]         CHAR (1)           NOT NULL,
    [Type]       VARCHAR (50)       NOT NULL,
    [Method]     VARCHAR (50)       NOT NULL,
    [URI]        VARCHAR (500)      NOT NULL,
    [IPAddress]  VARCHAR (20)       NOT NULL,
    [Body]       TEXT               NULL,
    [InsertDate] DATETIMEOFFSET (7) NOT NULL,
    PRIMARY KEY CLUSTERED ([PK] ASC)
);


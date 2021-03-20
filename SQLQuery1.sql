CREATE TABLE [dbo].[Questions] (
    [Question_ID] INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (MAX) NULL,
    [Duration]    INT            NULL,
    [Text]        NVARCHAR (MAX) NULL,
    [Image]       NVARCHAR (MAX) NULL,
    [Audio]       NVARCHAR (MAX) NULL,
    [PDF]         NVARCHAR (MAX) NULL,
    [Fill_Ups]    NVARCHAR (MAX) NULL,
    [Accept_Text] INT            NULL,
    [Audio_Ans]   INT            NULL,
    [TimeStamp]   NVARCHAR (MAX) NULL,
    [Type]        NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Question_ID] ASC)
);


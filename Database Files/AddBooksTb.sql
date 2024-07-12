CREATE TABLE [dbo].[AddBooksTB] (
    [Book_Id]          INT             NOT NULL,
    [Book_Name]        VARCHAR (100)   NOT NULL,
    [Book_Author]      NVARCHAR (100)  NOT NULL,
    [Book_Publication] VARCHAR (100)   NOT NULL,
    [Purchase_Date]    DATETIME        NOT NULL,
    [Book_Price]       DECIMAL (10, 2) NOT NULL,
    [Book_Quantity]    INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Book_Id] ASC)
);


CREATE TABLE [dbo].[AddBookTB] (
    [Book_Name]        VARCHAR (100) NOT NULL,
    [Book_Author]      NCHAR (100)    NOT NULL,
    [Book_Publication] VARCHAR (100) NOT NULL,
    [Purchase_Date]    DATETIME      NOT NULL,
    [Book_Price]       SMALLMONEY    NOT NULL,
    [Book_Quantity]    INT           NOT NULL
);


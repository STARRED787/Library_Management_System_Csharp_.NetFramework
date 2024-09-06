CREATE TABLE [dbo].[IssueBooksTB] (
    [Member_Id]   INT           NOT NULL,
    [Member_Name] VARCHAR (100) NOT NULL,
    [Address]     VARCHAR (100) NOT NULL,
    [Cantact_Num] VARCHAR (10)  NOT NULL,
    [Email]       VARCHAR (20)  NULL,
    [Book_Name]   VARCHAR (100) NOT NULL,
	[Issue_Date]  DATE          NOT NULL,
    [Return_Date]  DATE          NOT NULL,

    PRIMARY KEY CLUSTERED ([Member_Id] ASC)
);


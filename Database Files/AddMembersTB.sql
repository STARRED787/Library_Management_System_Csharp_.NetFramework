CREATE TABLE [dbo].[AddMembersTB] (
    [Member_Id]   INT           NOT NULL,
    [Member_Name] VARCHAR (100) NOT NULL,
    [Address]     VARCHAR (100) NOT NULL,
    [Cantact_Num] VARCHAR (10)  NOT NULL,
    [Dob]         DATE          NOT NULL,
    [Gender]      VARCHAR (10)  NOT NULL,
    [Email]       VARCHAR (20)  NULL,
    [Start_Date]  DATE          NOT NULL,
    [End_Date]    DATE          NOT NULL,
    PRIMARY KEY CLUSTERED ([Member_Id] ASC)
);


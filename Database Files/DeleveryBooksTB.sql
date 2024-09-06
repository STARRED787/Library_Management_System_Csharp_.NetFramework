CREATE TABLE [dbo].[DeleveryBooksTB] (
    [Member_Id]     INT           NOT NULL,
    [Member_Name]   VARCHAR (100) NOT NULL,
    [Address]       VARCHAR (100) NOT NULL,
    [Cantact_Num]   VARCHAR (10)  NOT NULL,
    [Email]         VARCHAR (20)  NULL,
    [Book_Name]     VARCHAR (100) NOT NULL,
    [Issue_Date]    DATE          NOT NULL,
    [Return_Date]   DATE          NOT NULL,
    [Delevery_Date] DATE          NOT NULL,
    [Late_Days]     INT           NOT NULL,
    [Late_Fees]     MONEY         NOT NULL,
    [Payements]     VARCHAR (20)  NOT NULL
);


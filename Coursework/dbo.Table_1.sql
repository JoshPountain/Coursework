CREATE TABLE [dbo].[Customers]
(
    [CustomerID] NCHAR(5) NOT NULL, 
    [CompanyName] NVARCHAR(50) NOT NULL, 
    [ContactName] NVARCHAR(50) NULL, 
    [Phone] NVARCHAR(24) NULL, 
    CONSTRAINT [PK_Table] PRIMARY KEY ([CustomerID])
)

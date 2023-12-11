CREATE TABLE [dbo].[BlogPosts]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Contents] NVARCHAR(50) NOT NULL, 
    [Timestamp] DATETIME2 NOT NULL DEFAULT SYSDATETIME(), 
    [CategoryId] INT NOT NULL,
    FOREIGN KEY (CategoryId) REFERENCES BlogPostCategories(Id)
)

CREATE TABLE [dbo].[UploadedFiles]
(
	[objid]        INT             NOT NULL,
    [fileName]     NVARCHAR (255)  NULL,
    [fileContents] VARBINARY (MAX) NULL, 
    [locationType] NVARCHAR(50) NULL
)

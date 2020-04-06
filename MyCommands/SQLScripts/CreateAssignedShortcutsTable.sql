
IF NOT EXISTS
(
    SELECT *
    FROM sysobjects
    WHERE id = OBJECT_ID(N'[dbo].[tblAssignedShortcuts]')
)
    BEGIN
        CREATE TABLE tblAssignedShortcuts
        (AssignedShortutId INT NOT NULL IDENTITY(1, 1) PRIMARY KEY, 
         ShortcutCode      INT, 
         MethodName        VARCHAR(MAX), 
         Params            VARCHAR(MAX)
        );
END;
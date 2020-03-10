
INSERT INTO [dbo].[UserDetails]
( 
 [LoginId], [UserName], [EmailId],[Password],[LastLogin]
)
VALUES
( 
 'TestUser', 'TestUser', 'test@gmail.com','password',GETDATE()
)


-- Insert rows into table 'TableName' in schema '[dbo]'
INSERT INTO [dbo].[MeetingDetails]
( -- Columns to insert data into
 [MeetingSubject], [MeetingAgenda], [MeetingTime]
)
VALUES
( -- First row: values for the columns in the list above
'Sprint Planning', 'To plan upcoming sprint','02/07/2020 10:00:00 AM', 'TestUser'
)


-- Add more rows here
GO
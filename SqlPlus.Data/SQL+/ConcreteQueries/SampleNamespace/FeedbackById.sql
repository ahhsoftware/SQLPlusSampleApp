 --+SqlPlusRoutine
    --&Author=Alan Hyneman
    --&Comment=Selects single row from dbo.Feedback table by identity column.
    --&SelectType=SingleRow
--+SqlPlusRoutine

--+Parameters

    DECLARE
    @FeedbackId int = 1
 
 --+Parameters


    SET NOCOUNT ON;
 
    SELECT
        FeedbackId,
        LastName,
        FirstName,
        Email,
        Subject,
        Message,
        Created
    FROM
        dbo.Feedback
    WHERE
        FeedbackId = @FeedbackId;

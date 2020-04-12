
/*
    To build concrete queries include a routine tag with the desired select type, comment, and author.
*/

--+SqlPlusRoutine
    --&SelectType=SingleRow
    --&Comment=Comment
    --&Author=Author
--+SqlPlusRoutine

/*
    Declare the set of variables that you want to pass into the generated service.

    Surround the variables that you want to include as parameters with the --+Parameters tag.

    Any values assigned to these variables are ignored - this allows isolated testing of your SQL without influencing the build.

    By default all variables are created as input parameters.

    If you want an input output parameter you can use the --+InOut tag.

    If you want an output only parameter you can use the --+Output tag.

    The variable name ReturnValue has a special meaning in concrete queries and allows enumerated return values. (Optional)
*/

--+Parameters

    DECLARE

	--+Required
	--+MaxLength=32
	@Name varchar(32) = 'World',

    --+Output
    @ReturnValue int

--+Parameters

/* Your SQL statement(s) here note that Multiple Results are fully supported*/

SELECT CONCAT('Hello ', @Name) AS WelcomeMessage;


IF @@ROWCOUNT = 0
BEGIN
    --+Return=NotFound
    SET @ReturnValue=0;
END;
ELSE
BEGIN
    --+ReturnValue=Ok
    SET @ReturnValue = 1;
END;

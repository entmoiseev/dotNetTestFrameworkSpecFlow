Feature: Library


@mytag
Scenario: Create a book
	Given add new 'book' to library
	| Author | BookName |
	| Tim    | test |
	Then verify that 'book' was added

	
	@mytag
Scenario: Update last created book
	Given add new 'book' to library
	| Author | BookName |
	| Tim    | test |
	When update last created 'book' info with following parameters
	| Author | BookName |
	|Test| TIm|
	Then last created 'book' was updated with following parameters
	| Author | BookName |
	|Test| TIm|


	@mytag
Scenario: Delete last created book
	Given add new 'book' to library
	| Author | BookName |
	| Tim    | test |
	When delete last created 'book' info
	Then last created 'book' was deleted


	@mytag
Scenario: Create a journal
	Given add new 'journal' to library
	| Author | JournalName |
	| Tim    | test1 |
	Then verify that 'journal' was added


	@mytag
Scenario: Update last created journal
	Given add new 'journal' to library
	| Author | JournalName |
	| Tim    | test |
	When update last created 'journal' info with following parameters
	| Author | JournalName |
	|Test| TIm|
	Then last created 'journal' was updated with following parameters
	| Author | JournalName |
	|Test| TIm|

	@mytag
Scenario: Delete last created journal
	Given add new 'journal' to library
	| Author | JournalName |
	| Tim    | test |
	When delete last created 'journal' info
	Then last created 'journal' was deleted

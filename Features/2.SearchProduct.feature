Feature: 2.SearchProduct

A short summary of the feature

@regression @search
Scenario: Search a product and verify results
	Given I navigate to Amazon application
	And I search following product
		| Keyword      |
		| born a crime |
	When I click Search icon
	Then following results should be displayed
		| Product                                                                                            | Reviews | Price |
		| Born a Crime: Stories from a South African Childhood                                               | 106,126 | 10.79 |
		| It's Trevor Noah: Born a Crime: Stories from a South African Childhood (Adapted for Young Readers) | 3,870   | 7.55  |
	

Feature: 3.AddToCart 

@regression @search @e2etest
Scenario: Search an item and Add to cart
	Given I navigate to Amazon application
	And Sign In if not already signed in
	And I search following product
		| Keyword                                                                            |
		| Logitech M510 Wireless Computer Mouse for PC with USB Unifying Receiver - Graphite |
	When I click Search icon
	Then following results should be displayed
		| Product                                                                   | Reviews | Price |
		| M510 Wireless Computer Mouse for PC with USB Unifying Receiver - Graphite | 29,604  | 21.99 |

	When I click on Add to cart
	Then item added message should be displayed

	When I click on cart on Nav bar
	Then the following item should listed in cart
		| ItemName                                                                           | Price  |
		| Logitech M510 Wireless Computer Mouse for PC with USB Unifying Receiver - Graphite | $21.99 |
	And delete the item from the cart
	
	When I click Sign Out button
	Then verify that the user is redirected to SignIn Page

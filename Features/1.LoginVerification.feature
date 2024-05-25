Feature: 1.LoginVerification

@regression @login
Scenario: 1. Login with valid user credentials and Logout
	Given I navigate to Amazon application
	And I click on Sign in from Nav bar
	And I enter email in Sign In page
	And I click on Continue button in Sign In page
	And I enter password in Sign In page

	When I click Sign In button
	Then verify that the user is logged in

	When I click Sign Out button
	Then verify that the user is redirected to SignIn Page

@regression @login
Scenario: 2. Login with invalid user credentials(Invalid Password)
	Given I navigate to Amazon application
	And I click on Sign in from Nav bar
	And I enter following email in Sign In page
		| Email                    |
		| testersuman616@gmail.com |
	And I click on Continue button in Sign In page
	And I enter following password in Sign In page
		| Password      |
		| passwordtest1 |
	When I click Sign In button
	Then Incorrect Password Message should be displayed


@regression @login
Scenario: 3. Login with invalid user credentials(Invalid Email)
	Given I navigate to Amazon application
	And I click on Sign in from Nav bar
	And I enter following email in Sign In page
		| Email                     |
		| testersuman9999@gmail.com |
	And I click on Continue button in Sign In page
	Then Invalid Email Message should be displayed
Feature: APITest
	

@api
Scenario: Testing API for Categories Details 
	Given I perform a get request
	Then assert get request <Name> 
	Then assert value for <CanReList>
	Then assert Promotions is not null and has <PromotionsName> and has a <Description> containing text
	
	Examples:
	| Name           | CanRelist | PromotionsName | Description               |
    | Carbon credits | true      | Gallery        | Good position in category |
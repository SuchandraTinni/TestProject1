Feature: APITest
	

@api
Scenario: Testing API for Categories Details 
	Given I perform a get request <contextPath>
	Then assert get request <Name> 
	Then assert value for <CanReList>
	Then assert Promotions is not null and has <PromotionsName> and has a <Description> containing text
	
	Examples:
	| contextPath                                  | statusCode | Name           | CanRelist | PromotionsName | Description               |
	| Categories/6327/Details.json?catalogue=false | 200        | Carbon credits | true      | Gallery    | Good position in category |
Feature: Testing
	


Scenario:GetProductbyId
	Given I have a valid Id 17
	When I sent get request
	Then I expected valid code response

Scenario:UpdateProduct

	Given I have a valid Product Id 19
	When I sent put request
	Then I expected valid product updated

Scenario:GetProductByCategory

	Given I have a valid category  7
	When I sent get products request
	Then I expected valid code ok response

Scenario:CreateProduct
	Given I have valid parameters
	When I sent post  request
	Then I expected valid product added
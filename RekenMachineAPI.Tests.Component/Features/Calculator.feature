Feature: Calculator api

Background: 
	Given I seed the following calculations
	| Id | CalculationString | Created           | Value | CalculationTypeId |
	| 1  | 3plus5            | 9-8-2018 13:38:56 | 8     | 3                 |
	| 2  | 3plus5keer10      | 9-8-2018 14:05:04 | 103   | 5                 |

Scenario: Get calculations
	When I get all calculations
	Then I retrieve the following calculations
	| Id | CalculationString | Created           | Value | CalculationTypeId |
	| 1  | 3plus5            | 9-8-2018 13:38:56 | 8     | 3                 |
	| 2  | 3plus5keer10      | 9-8-2018 14:05:04 | 103   | 5                 |	
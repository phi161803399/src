Feature: Sample api

Background: 
	Given I seed the following samples
	| Id | Values |
	| 1  | a     |
	| 2  | b     |

Scenario: Get samples
	When I get all samples	
	Then I retrieve the following samples
	| Id | Value |
	| 1  | a     |
	| 2  | b     |

Scenario: Get sample by id
	When I get sample by id 2
	Then I retrieve the following sample
	| Id | Value |
	| 2  | b     |

Scenario: Get unexisting sample
	When I get sample by id 3
	Then I retrieve 404

Scenario: Post sample
	When I post a sample
	| Id | Value |
	|    | c     |
	Then I retrieve 200
	And I should have the following samples
	| Id | Value |
	| 1  | a     |
	| 2  | b     |
	| 3  | c     |

Scenario: Put sample
	When I put sample with id 1
	| Id | Value |
	|    | z     |
	Then I retrieve 200
	And I should have the following samples
	| Id | Value |
	| 1  | z     |
	| 2  | b     |

Scenario: Put unexisting sample
	When I put sample with id 3
	| Id | Value |
	|    | z     |
	Then I retrieve 404

Scenario: Delete sample
	When I delete sample with id 1
	Then I retrieve 200
	And I should have the following samples
	| Id | Value |
	| 2  | b     |

Scenario: Delete unexisting sample
	When I delete sample with id 3
	Then I retrieve 404
# trivia-game api
API for providing and pesristing trivia game data

Projects
## TriviaGame.Api
Api code lives here
1) Controllers: contain routing logic, connects mediators to provide data
2) Converters: Convert data formats (eg. from Entity to Dto)
1) Data: Database integration, including repositories
1) Models: Data models go here, seperated by entities and Dto 
1) Providers: Business logic for requests are applied here, connected to controllers
1) Middleware: Global functions to run on requets

## TriviaGame.Api.IntegrationTests
Intrgration tests live here
1) Tests should implement ApplicationFixture
1) Tests should be in folders matching TriviaGame.Api project folder structure to make them easier to locate
1) Test classes should include [Collection("IntegrationTests")] attribute to assure that the fixture is created only once

## TriviaGame.Api.UnitTests
Unit tests live here
1) Tests should be in folders matching TriviaGame.Api project folder structure to make them easier to locate
1) Tests should use ClassFixture which should be dervied from BaseTestFixture
1) Test files should only contain tests for a single method to make future maintenance easier

## Glossary
- Dto: Data Transfer Object

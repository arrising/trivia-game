﻿namespace TriviaGame.Api.IntegrationTests;

// Required to assure shard ApplicationFixture is only created once
[Collection("IntegrationTests")]
[TestCaseOrderer("TriviaGame.Api.IntegrationTests.PriorityOrderer", "TriviaGame.Api.IntegrationTests")]
public abstract class IntegrationTestBase
{
    protected IntegrationTestBase(ApplicationFixture fixture)
    {
        Fixture = fixture;
    }

    public ApplicationFixture Fixture { get; private set; }
    public abstract string TestUrl { get; }
}

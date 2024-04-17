namespace TriviaGame.Api.IntegrationTests.CategoryControllerTests;

public class CategoryControllerTestBase : IntegrationTestBase
{
    public CategoryControllerTestBase(ApplicationFixture fixture) : base(fixture) { }
    public override string TestUrl => "api/categories";
}

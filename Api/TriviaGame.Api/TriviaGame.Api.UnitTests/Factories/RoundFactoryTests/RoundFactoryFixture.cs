using TriviaGame.Api.Factories;
using TriviaGame.Api.Factories.Interfaces;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Models.Requests;

namespace TriviaGame.Api.UnitTests.Factories.RoundFactoryTests;

public class RoundFactoryFixture : BaseTestFixture<RoundFactory>
{
    public readonly Mock<IFactory<CreateCategoryRequest, CategoryEntity>> CategoryFactory;

    public RoundFactoryFixture()
    {
        CategoryFactory = Repository.Create<IFactory<CreateCategoryRequest, CategoryEntity>>();
    }

    public override RoundFactory CreateInstance() => new(CategoryFactory.Object);
}

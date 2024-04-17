using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Mediators;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.UnitTests.Mediators.CategoryMediatorTests;

public class CategoryMediatorFixture : BaseTestFixture<ICategoryMediator>
{
    public Mock<IRepository<CategoryEntity>> CategoryRepository;

    public CategoryMediatorFixture()
    {
        CategoryRepository = Repository.Create<IRepository<CategoryEntity>>();
    }

    public override ICategoryMediator CreateInstance() =>
        new CategoryMediator(CategoryRepository.Object);
}

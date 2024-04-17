using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Providers;
using TriviaGame.Api.Providers.Interfaces;

namespace TriviaGame.Api.UnitTests.Providers.CategoryProviderTests;

public class CategoryProviderFixture : BaseTestFixture<ICategoryProvider>
{
    public Mock<IRepository<CategoryEntity>> CategoryRepository;

    public CategoryProviderFixture()
    {
        CategoryRepository = Repository.Create<IRepository<CategoryEntity>>();
    }

    public override ICategoryProvider CreateInstance() =>
        new CategoryProvider(CategoryRepository.Object);
}

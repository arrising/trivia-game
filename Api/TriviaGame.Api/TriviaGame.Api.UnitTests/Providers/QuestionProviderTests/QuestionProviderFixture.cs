using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Providers;
using TriviaGame.Api.Providers.Interfaces;

namespace TriviaGame.Api.UnitTests.Providers.QuestionProviderTests;

public class QuestionProviderFixture : BaseTestFixture<IQuestionProvider>
{
    public Mock<IRepository<QuestionEntity>> QuestionRepository;

    public QuestionProviderFixture()
    {
        QuestionRepository = Repository.Create<IRepository<QuestionEntity>>();
    }

    public override IQuestionProvider CreateInstance() =>
        new QuestionProvider(QuestionRepository.Object);
}

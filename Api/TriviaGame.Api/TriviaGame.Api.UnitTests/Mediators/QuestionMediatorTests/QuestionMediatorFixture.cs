using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Mediators;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.UnitTests.Mediators.QuestionMediatorTests;

public class QuestionMediatorFixture : BaseTestFixture<IQuestionMediator>
{
    public Mock<IRepository<QuestionEntity>> QuestionRepository;

    public QuestionMediatorFixture()
    {
        QuestionRepository = Repository.Create<IRepository<QuestionEntity>>();
    }

    public override IQuestionMediator CreateInstance() =>
        new QuestionMediator(QuestionRepository.Object);
}

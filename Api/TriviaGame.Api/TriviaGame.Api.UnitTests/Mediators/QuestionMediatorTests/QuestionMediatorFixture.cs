using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Mediators;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models;

namespace TriviaGame.Api.UnitTests.Mediators.QuestionMediatorTests;

public class QuestionMediatorFixture : BaseTestFixture<IQuestionMediator>
{
    public Mock<IRepository<Question>> QuestionRepository;

    public QuestionMediatorFixture()
    {
        QuestionRepository = Repository.Create<IRepository<Question>>();
    }

    public override IQuestionMediator CreateInstance() =>
        new QuestionMediator(QuestionRepository.Object);
}

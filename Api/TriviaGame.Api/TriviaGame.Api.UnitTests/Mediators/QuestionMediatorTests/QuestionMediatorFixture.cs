using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Mediators;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models;
using TriviaGame.Api.Validators.Interfaces;

namespace TriviaGame.Api.UnitTests.Mediators.QuestionMediatorTests;

public class QuestionMediatorFixture : BaseTestFixture<IQuestionMediator>
{
    public Mock<IIdValidator> IdValidator;
    public Mock<IRepository<Question>> QuestionRepository;

    public QuestionMediatorFixture()
    {
        QuestionRepository = Repository.Create<IRepository<Question>>();
        IdValidator = Repository.Create<IIdValidator>();
    }

    public override IQuestionMediator CreateInstance() =>
        new QuestionMediator(QuestionRepository.Object, IdValidator.Object);
}

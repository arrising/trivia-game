using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models;
using TriviaGame.Api.Validators.Interfaces;

namespace TriviaGame.Api.Mediators
{
    public class QuestionMediator : IQuestionMediator
    {
        private readonly IRepository<Question> _repository;
        private readonly IIdValidator _validator;

        public QuestionMediator(IRepository<Question> repository, IIdValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public Question GetById(string questionId)
        {
            if (_validator.TryGetValidationException(questionId, nameof(questionId), out var exception))
            {
                throw exception;
            }

            return _repository.GetById(questionId)
                   ?? throw new NotFoundException($"QuestionId '{questionId}' was not found");
        }

        public IEnumerable<Question> GetByCategoryId(string categoryId)
        {
            if (_validator.TryGetValidationException(categoryId, nameof(categoryId), out var exception))
            {
                throw exception;
            }

            var result = _repository.GetByParentId(categoryId);

            return result?.Any() == true
                ? result
                : throw new NotFoundException($"Questions for {nameof(categoryId)} '{categoryId}' were not found");
        }
    }
}

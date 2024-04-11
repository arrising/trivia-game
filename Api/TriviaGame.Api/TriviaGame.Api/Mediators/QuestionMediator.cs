﻿using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models;

namespace TriviaGame.Api.Mediators;

/// <summary>
///     Handles business logic regarding Question data
/// </summary>
public class QuestionMediator : IQuestionMediator
{
    private readonly IRepository<Question> _repository;

    public QuestionMediator(IRepository<Question> repository)
    {
        _repository = repository;
    }

    public Question GetById(string questionId) =>
        _repository.GetById(questionId)
        ?? throw new NotFoundException($"QuestionId '{questionId}' was not found");

    public IEnumerable<Question> GetByCategoryId(string categoryId)
    {
        var result = _repository.GetByParentId(categoryId);

        return result?.Any() == true
            ? result
            : throw new NotFoundException($"Questions for {nameof(categoryId)} '{categoryId}' were not found");
    }
}
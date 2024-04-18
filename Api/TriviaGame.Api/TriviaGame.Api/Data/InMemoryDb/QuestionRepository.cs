﻿using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Data.InMemoryDb;

public class QuestionRepository : IRepository<QuestionEntity>
{
    private readonly TriviaGameDbContext _context;

    public QuestionRepository(TriviaGameDbContext context)
    {
        _context = context;
    }

    public QuestionEntity? GetById(string id) =>
        _context.Questions.FirstOrDefault(x => x.Id == id);

    public IEnumerable<QuestionEntity> GetByParentId(string id) =>
        _context.Questions.Where(x => x.CategoryId == id);

    public IEnumerable<QuestionEntity> GetAll() => _context.Questions;
}

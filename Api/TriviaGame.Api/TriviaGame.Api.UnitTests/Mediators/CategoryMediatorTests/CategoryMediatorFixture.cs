﻿using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Mediators;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models;
using TriviaGame.Api.Validators.Interfaces;

namespace TriviaGame.Api.UnitTests.Mediators.CategoryMediatorTests;

public class CategoryMediatorFixture : BaseTestFixture<ICategoryMediator>
{
    public Mock<IRepository<Category>> CategoryRepository;
    public Mock<IIdValidator> IdValidator;

    public CategoryMediatorFixture()
    {
        CategoryRepository = Repository.Create<IRepository<Category>>();
        IdValidator = Repository.Create<IIdValidator>();
    }

    public override ICategoryMediator CreateInstance() =>
        new CategoryMediator(CategoryRepository.Object, IdValidator.Object);
}

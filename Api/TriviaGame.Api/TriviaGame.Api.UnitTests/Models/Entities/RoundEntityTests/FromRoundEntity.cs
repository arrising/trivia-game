using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.UnitTests.Models.Entities.RoundEntityTests
{
    public class FromRoundEntity : IClassFixture<ModelsTestFixture>
    {
        private readonly ModelsTestFixture _fixture;

        public FromRoundEntity(ModelsTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void RoundEntity_From_RoundEntity_HasValue_Good()
        {
            var value = _fixture.AutoFixture.Create<RoundEntity>();
            var expected = new RoundEntity
            {
                Id = value.Id,
                Type = value.Type,
                Categories = value.Categories,
                GameId = value.GameId,
                Game = value.Game
            };

            var actual = new RoundEntity(value);

            actual.Should().BeEquivalentTo(expected).And.NotBeSameAs(value);
        }

        [Fact]
        public void RoundEntity_From_RoundEntity_HasValueMissingCategories_Good()
        {
            var value = _fixture.AutoFixture.Build<RoundEntity>()
                .Without(x => x.Categories)
                .Create();
            var expected = new RoundEntity
            {
                Id = value.Id,
                Type = value.Type,
                Categories = new List<CategoryEntity>(),
                GameId = value.GameId,
                Game = value.Game
            };

            var actual = new RoundEntity(value);

            actual.Should().BeEquivalentTo(expected).And.NotBeSameAs(value);
        }

        [Fact]
        public void RoundEntity_From_RoundEntity_Null_Throws()
        {
            var action = () => new RoundEntity(null);

            action.Should().ThrowExactly<ConversionNullException>()
                .WithMessage("Can not create new RoundEntity from null (Parameter 'round')");
        }
    }
}

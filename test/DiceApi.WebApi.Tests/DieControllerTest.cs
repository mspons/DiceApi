using Microsoft.AspNetCore.Mvc;
using Xunit;

using DiceApi.Core;
using DiceApi.WebApi.Controllers;

namespace DiceApi.WebApi.Tests
{

    /// <summary>
    /// Test class for <see cref="DieController" />.
    /// </summary>
    public class DieControllerTest
    {
        /// <summary>
        /// Verifies that Get() returns a BadRequestResult when given an invalid number 
        /// of sides for the die to roll.
        /// </summary>
        [Fact]
        public void Get_GivenSidesLessThanZero_ReturnsBadRequestResult()
        {
            var sut = new DieController(new Die());

            var result = sut.Get(-1);

            Assert.Equal(typeof(BadRequestResult), result.GetType());
        }

        /// <summary>
        /// Verifies that Get() returns an OkObjectResult when given an valid number 
        /// of sides for the die to roll.
        /// </summary>
        [Fact]
        public void Get_GivenValidSizeValue_ReturnsOkResult()
        {
            var sut = new DieController(new Die());

            var result = sut.Get(6);

            Assert.Equal(typeof(OkObjectResult), result.GetType());
            Assert.Equal(typeof(int), ((OkObjectResult)result).Value.GetType());
        }
    }
}

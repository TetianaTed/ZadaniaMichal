using Xunit;
using Xunit.Sdk;

namespace ZadaniaMichal.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(5, 2 + 3);
        }

        [Fact]
        public void Test_Task1()
        {
            //Arrange
            int[] data = new int[] { 6, 5, 3, 3, 8, 1 };

            //Act
            ZadaniaMichal.Task1.Task1Result operationResult = ZadaniaMichal.Task1.Perform_1(data);

            //Assert
            Assert.Equal(6, operationResult.n);
            Assert.Equal(1, operationResult.numbersGreaterThan);
            Assert.Equal(3, operationResult.numbersOfGaps);
        }

        [Theory]
        [InlineData(new int[] { 6, 5, 3, 3, 8, 1 }, 6, 1, 3)]
        [InlineData(new int[] { 6, 1, 2, 3, 8, 8 }, 6, 2, 3)]
        public void Test_Task1_Parametrizied(int[] data, int expectedN, int expectedNumbersGreaterThan, int expectedNumbersOfGaps)
        {
            //Act
            ZadaniaMichal.Task1.Task1Result operationResult = ZadaniaMichal.Task1.Perform_1(data);

            //Assert
            Assert.Equal(expectedN, operationResult.n);
            Assert.Equal(expectedNumbersGreaterThan, operationResult.numbersGreaterThan);
            Assert.Equal(expectedNumbersOfGaps, operationResult.numbersOfGaps);

        }

    }
}
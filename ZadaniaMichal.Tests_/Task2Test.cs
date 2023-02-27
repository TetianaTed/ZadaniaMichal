using Xunit;

namespace ZadaniaMichal.Tests
{
    public class Task2Test
    {
        [Fact]
        public void Test_Task2()
        {
            //Arrange
            string givenUserString = "BBF";

            //Act
            ZadaniaMichal.Task2.Task2Result operationResult2 = ZadaniaMichal.Task2.Perform_2(givenUserString);

            //Assert
            Assert.Equal(new int[] {66,66,70}, operationResult2.convertToASCII);
            Assert.Equal(0, operationResult2.countedOddNumber);
            Assert.Equal(136, operationResult2.summarizedNumbersOnEvenIndex);
            Assert.Equal(68, operationResult2.foundFirstAsciiNumber);
            Assert.Equal('D', operationResult2.convertedAsciiNumber);

            /*
             5 razy test Theory po 1 assert
            + wyjatek
            fluent assertipn - obejrzec filmik
            inline data - ile chce
             */
        }
    }
}

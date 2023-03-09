using Xunit;
using static ZadaniaMichal.Task2;
using FluentAssertions;

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
            + 5 razy test Theory po 1 assert - done
            + wyjatek - done
            fluent assertipn - obejrzec filmik
            inline data - ile chce - done
             */
        }
        
        //All asserts
        [Theory]
        [InlineData("BBF", new int[] { 66, 66, 70 }, 0, 136, 68, 'D')]
        [InlineData("BFR", new int[] { 66, 70, 82 }, 0, 148, 74, 'J')]
        public void Test_Task2_Parametrizied(string givenUserString, 
                                             int[] expectedConvertToASCII, int expectedCountedOddNumber,
                                             int expectedSummarizedNumbersOnEvenIndex, int expectedFoundFirstAsciiNumber, 
                                             char expectedConvertedAsciiNumber)
        {
            //Act
            ZadaniaMichal.Task2.Task2Result operationResult = ZadaniaMichal.Task2.Perform_2(givenUserString);

            //Assert
            //1.1 Assert.Equal
            
            Assert.Equal(expectedConvertToASCII, operationResult.convertToASCII);
            Assert.Equal(expectedCountedOddNumber, operationResult.countedOddNumber);
            Assert.Equal(expectedSummarizedNumbersOnEvenIndex, operationResult.summarizedNumbersOnEvenIndex);
            Assert.Equal(expectedFoundFirstAsciiNumber, operationResult.foundFirstAsciiNumber);
            Assert.Equal(expectedConvertedAsciiNumber, operationResult.convertedAsciiNumber);
            

            //1.2 Fluent assertions
            operationResult.convertToASCII.Should().Equal(expectedConvertToASCII); //Should().Be not found
            operationResult.countedOddNumber.Should().Be(expectedCountedOddNumber);
            operationResult.summarizedNumbersOnEvenIndex.Should().Be(expectedSummarizedNumbersOnEvenIndex);
            operationResult.foundFirstAsciiNumber.Should().Be(expectedFoundFirstAsciiNumber);
            operationResult.convertedAsciiNumber.Should().Be(expectedConvertedAsciiNumber);
        }

        //Separate asserts
        [Theory]
        [InlineData("BBF", new int[] { 66, 66, 70 })]
        [InlineData("BFR", new int[] { 66, 70, 82 })]
        public void Test_Task2_Parametrizied_ConvertToASCII(string givenUserString,
                                                            int[] expectedConvertToASCII)
        {
            //Act
            ZadaniaMichal.Task2.Task2Result operationResult = ZadaniaMichal.Task2.Perform_2(givenUserString);

            //Assert
            Assert.Equal(expectedConvertToASCII, operationResult.convertToASCII);
        }

        [Theory]
        [InlineData("BBF",0)]
        [InlineData("BFR", 0)]
        public void Test_Task2_Parametrizied_CountedOddNumber(string givenUserString,
                                                              int expectedCountedOddNumber)
        {
            //Act
            ZadaniaMichal.Task2.Task2Result operationResult = ZadaniaMichal.Task2.Perform_2(givenUserString);

            //Assert
            Assert.Equal(expectedCountedOddNumber, operationResult.countedOddNumber);
        }

        [Theory]
        [InlineData("BBF", 136)]
        [InlineData("BFR",148)]
        public void Test_Task2_Parametrizied_SummarizedNumbersOnEvenIndex(string givenUserString,                                           
                                             int expectedSummarizedNumbersOnEvenIndex)
        {
            //Act
            ZadaniaMichal.Task2.Task2Result operationResult = ZadaniaMichal.Task2.Perform_2(givenUserString);

            //Assert
            Assert.Equal(expectedSummarizedNumbersOnEvenIndex, operationResult.summarizedNumbersOnEvenIndex);
        }

        [Theory]
        [InlineData("BBF", 68)]
        [InlineData("BFR", 74)]
        public void Test_Task2_Parametrizied_FoundFirstAsciiNumber(string givenUserString,
                                                                           int expectedFoundFirstAsciiNumber)
        {
            //Act
            ZadaniaMichal.Task2.Task2Result operationResult = ZadaniaMichal.Task2.Perform_2(givenUserString);

            //Assert
            Assert.Equal(expectedFoundFirstAsciiNumber, operationResult.foundFirstAsciiNumber);
        }

        [Theory]
        [InlineData("BBF", 'D')]
        [InlineData("BFR", 'J')]
        public void Test_Task2_Parametrizied_ConvertedAsciiNumber(string givenUserString,                                            
                                                                  char expectedConvertedAsciiNumber)
        {
            //Act
            ZadaniaMichal.Task2.Task2Result operationResult = ZadaniaMichal.Task2.Perform_2(givenUserString);

            //Assert
            Assert.Equal(expectedConvertedAsciiNumber, operationResult.convertedAsciiNumber);
        }

        //Test exception
        [Fact]
        public void TestTask2_ForInvalidArguments_ThrowsException()
        {
            //Arrange
            string givenUserString = "123";

            //Act          
            Action action = () => ZadaniaMichal.Task2.Perform_2(givenUserString);

            //Assert
            Assert.Throws<Exception>(action);   
       
        }

        [Theory]
        [InlineData("123")]
        [InlineData("A3f")]
        [InlineData("bbf")]
        public void TestTask2_ForInvalidArguments_ThrowsException_Parametrizied(string givenUserString)
        {
            //Act          
            Action action = () => ZadaniaMichal.Task2.Perform_2(givenUserString);

            //Assert
            Assert.Throws<Exception>(action);
        }
    }
}

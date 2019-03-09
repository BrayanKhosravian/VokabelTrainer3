using NUnit.Framework;
using VokabelTrainer3.Services;

namespace VokabelTrainer3.Test.Services
{
    [TestFixture]
    public class VocabularyParserServiceTest
    {
        
        [SetUp]
        public void Setup()
        {
        }

        // unit test naming coversion
        // public void Methodname_Scenario_ExpectedBehaviour
        // Arrange
        // Act
        // Assert

        [Test]
        public void FormatVocabForQuit_TrimsInput_ReturnsTrimmedOutput()
        {
            // arrange
            var vocabularyParser = new VocabularyParserService();
            string[] inputs = new string[3]{"  test", "test  ", "  a long sentence with spaces after and before   " }; 
            string[] results = new string[3];

            // act
            int index = 0;
            foreach (var input in inputs)
            {
                results[index] = vocabularyParser.FormatVocabForQuiz(input);
                index++;
            }
          

            // assert
            index = 0;
            foreach (var result in results)
            {
                Assert.That(result, Is.EqualTo(inputs[index].Trim()));
                index++;
            }
   
        }
    }
}
using SimpleArticleWebAPI.BackgroundJob;

namespace SimpleArticleWebAPI.Tests.UnitTests
{
    public class ModifyParagraphTests
    {
        [Fact]
        public void FindAndModifyConcepts_Should_ModifyTextCorrectly_WhenConceptsExist()
        {
            // Arrange
            string inputText = "Shaylee Mansfield is an American deaf actress and former YouTuber.";
            string expectedOutput = "frigging Shaylee frigging Mansfield is an frigging American deaf actress and former YouTuber.";

            // Act
            string modifiedText = ArticlesBackgroundService.FindAndModifyConcepts(inputText);

            // Assert
            Assert.Equal(expectedOutput, modifiedText);
        }
		[Fact]
		public void RemoveDoubleFriggings_Should_RemoveConsecutiveFriggings()
		{
			// Arrange
			string inputParagraph = "frigging Shaylee frigging frigging Mansfield is an frigging frigging American deaf actress and former YouTuber.";

			// Act
			string modifiedParagraph = ArticlesBackgroundService.RemoveDoubleFriggings(inputParagraph);

			// Assert
			Assert.DoesNotContain("frigging frigging", modifiedParagraph);
		}
	}
}
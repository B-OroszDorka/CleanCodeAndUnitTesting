using Xunit;

namespace Week04
{
    public class UserDataProcessorTest
    {
        [Fact]
        public void TestProcessUserDataRefactored_ShouldFindUser()
        {
            // Arrange
            var processor = new UserDataProcessor();
            string[] allUserData = { "user1", "user2", "user3" };
            var userToFind = "user2";
            var shouldFindUser = true;
            var shouldFindUser2 = true;
            var iterations = 0;

            // Act
            var result = processor.ProcessUserDataRefactored(shouldFindUser, shouldFindUser2, allUserData, userToFind, iterations);

            // Assert
            Assert.Equal("User found: user2 at index 1", result);
        }

        [Fact]
        public void TestProcessUserDataRefactored_ProcessData()
        {
            // Arrange
            var processor = new UserDataProcessor();
            string[] allUserData = { "user1", "user2", "user3" };
            var userToFind = "user4";
            var shouldFindUser = false;
            var shouldFindUser2 = true;
            var iterations = 3;

            // Act
            var result = processor.ProcessUserDataRefactored(shouldFindUser, shouldFindUser2, allUserData, userToFind, iterations);

            // Assert
            Assert.Equal("Processing...Processing...Processing...", result);
        }

        [Fact]
        public void TestProcessUserDataRefactored_NoAction()
        {
            // Arrange
            var processor = new UserDataProcessor();
            string[] allUserData = { "user1", "user2", "user3" };
            var userToFind = "user4";
            var shouldFindUser = false;
            var shouldFindUser2 = false;
            var iterations = 3;

            // Act
            var result = processor.ProcessUserDataRefactored(shouldFindUser, shouldFindUser2, allUserData, userToFind, iterations);

            // Assert
            Assert.Equal("No action taken", result);
        }
    }
}

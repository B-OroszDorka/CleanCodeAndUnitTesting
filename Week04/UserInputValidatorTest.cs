using Xunit;

namespace Week04
{
    public class UserInputValidatorTest
    {
        [Fact]
        public void TestValidateUserInputRefactored()
        {
            // Arrange
            UserInputValidator validator = new UserInputValidator();

            // Act & Assert
            Assert.False(validator.ValidateUserInputRefactored(null));
            Assert.False(validator.ValidateUserInputRefactored(""));
            Assert.False(validator.ValidateUserInputRefactored("  "));
            Assert.False(validator.ValidateUserInputRefactored("abc"));
            Assert.False(validator.ValidateUserInputRefactored("abcdefghijklmnopqrstuvwxyz"));
            Assert.False(validator.ValidateUserInputRefactored("user@123"));
            Assert.True(validator.ValidateUserInputRefactored("user123"));
        }
    }
}

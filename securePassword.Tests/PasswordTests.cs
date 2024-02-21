using securePasswordType;
using Xunit;
using System;

namespace securePassword.Tests
{
    public class PasswordTests
    {
        [Theory]
        [InlineData("Ba2#1234sdfr")] 
        [InlineData("P@4d38dhjf9skfsd")] 
        public void Create_ValidPasswords_ReturnsPasswordObject(string validPassword)
        {
            var password = Password.Create(validPassword);

            Assert.NotNull(password);
        }

        [Theory]
        [InlineData("Pa345679010")] 
        [InlineData("Pg34a678901")]
        [InlineData(" ")]
        [InlineData(" sdff   ___ 3$F")]  
        public void Create_InvalidPasswords_ThrowsArgumentException(string invalidPassword)
        {
            var exception = Assert.Throws<ArgumentException>(() => Password.Create(invalidPassword));

            Assert.Equal("Requirements: Include an uppercase character, lowercase character, number and special character. Password must be 12 characters or longer.", exception.Message);
        }
    }
}

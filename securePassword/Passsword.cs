namespace securePasswordType
{
    public class Password
    {
        private string Value { get; }

        private Password(string password)
        {
            Value = password;
        }

        public static Password Create(string password)
        {
            if (!IsValid(password))
            {
              throw new ArgumentException("Requirements: Include an uppercase character, lowercase character, number and special character. Password must be 12 characters or longer. White-spaces forbidden.");    
            }

            return new Password(password);
        }

        private static bool IsValid(string password)
        {
            // Check for minimum length of 8 characters and at least one alphanumeric character
            return password.Length >= 12 && password.Any(ch => !char.IsLetterOrDigit(ch)) && password.Any(char.IsUpper) && password.Any(char.IsLower) && password.Any(char.IsDigit) && !password.Any(char.IsWhiteSpace) &&
            password.Any(ch => !char.IsLetterOrDigit(ch) && ch != '\\' && ch != '"' && ch != '\'');
        }
    }
}

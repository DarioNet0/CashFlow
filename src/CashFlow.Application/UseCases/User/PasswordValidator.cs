using FluentValidation;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace CashFlow.Application.UseCases.User
{
    public class PasswordValidator<T> : PropertyValidator<T, string>
    {
        private const string Error_Message = "ErrorMessage";
        public override string Name => "PasswordValidator";

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return $"{{{Error_Message}}}";
        }

        public override bool IsValid(ValidationContext<T> context, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                context.MessageFormatter.AppendArgument(Error_Message, "A senha não ta boa");
                return false;
            }

            if (password.Length < 8)
            {
                context.MessageFormatter.AppendArgument(Error_Message, "A senha não ta boa");
                return false;
            }

            if (Regex.IsMatch(password, @"[A-Z]+") == false)
            {
                context.MessageFormatter.AppendArgument(Error_Message, "A senha não ta boa");
                return false;
            }

            if (Regex.IsMatch(password, @"[a-z]+") == false)
            {
                context.MessageFormatter.AppendArgument(Error_Message, "A senha não ta boa");
                return false;
            }

            if (Regex.IsMatch(password, @"[0-9]+") == false)
            {
                context.MessageFormatter.AppendArgument(Error_Message, "A senha não ta boa");
                return false;
            }

            if (Regex.IsMatch(password, @"[\!\?\*\.\@]+") == false)
            {
                context.MessageFormatter.AppendArgument(Error_Message, "A senha não ta boa");
                return false;
            }

            return true;
        }
    }
}

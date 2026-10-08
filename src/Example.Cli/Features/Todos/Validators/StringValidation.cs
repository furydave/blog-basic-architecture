using System.CommandLine;
using System.CommandLine.Parsing;

namespace Example.Cli.Features.Todos.Validators;

internal static class StringValidation
{
    extension(Option<string> option)
    {
        /// <summary>
        /// Adds a string length validator to the specified option. The validator checks if the provided string value is not null or whitespace and does not exceed the specified length.
        /// </summary>
        /// <param name="length">The maximum allowed length of the string.</param>
        internal void AddStringLengthValidator(int length)
        {
            option.Validators.Add(result => StringLengthValidator(result, length));
        }

        private static void StringLengthValidator(OptionResult result, int length)
        {
            var text = result.GetValueOrDefault<string>();

            if(string.IsNullOrWhiteSpace(text))
            {
                result.AddError($"The {result.Option.Name} option is required.");
                return;
            }
            if (text.Length > length)
            {
                result.AddError($"The {result.Option.Name} option must not exceed {length} characters.");
            }
        }
    }
}

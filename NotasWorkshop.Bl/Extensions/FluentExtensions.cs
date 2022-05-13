using FluentValidation;

namespace SicopataPedidos.Bl.Validators
{
    public static class FluentExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> WithMessage<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, string errorMessage, Func<T, TProperty, string> predicate)
        {
            return rule.WithMessage(string.Format(errorMessage, ""));

        }
    }
}

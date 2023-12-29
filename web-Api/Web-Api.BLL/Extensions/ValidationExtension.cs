using FluentValidation;


namespace Web_Api.BLL.Extensions
{
    public static class ValidationExtension
    {
        const string PatternForLetter = @"^[a-zA-Z]+$";
        const string PatternForCountry = @"[a-zA-Zа-яА-Я]+(\\s[a-zA-Zа-яА-Я]+)*$";
        const string PatternForPhoneNumber = @"^\+?\d{1,4}?[-.\s]?\(\d{1,3}?\)?[-.\s]?\d{1,4}[-.\s]?\d{1,4}[-.\s]?\d{1,9}$";
        public static IRuleBuilderOptions<T, TProperty> CorrectDate<T, TProperty>(this IRuleBuilderOptions<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.Must(dateTime => !default(DateTime).Equals(dateTime));
        }
        public static IRuleBuilderOptions<T, string> JustLetter<T>(this IRuleBuilderOptions<T, string> ruleBuilder)
        {
            return ruleBuilder.Matches(PatternForLetter);
        }
        public static IRuleBuilderOptions<T, string> IsValidCountry<T>(this IRuleBuilderOptions<T, string> ruleBuilder)
        {
            return ruleBuilder.Matches(PatternForCountry);
        }
        public static IRuleBuilderOptions<T, string> IsValidPhoneNumber<T>(this IRuleBuilderOptions<T, string> ruleBuilder)
        {
            return ruleBuilder.Matches(PatternForPhoneNumber);
        }
    }
}

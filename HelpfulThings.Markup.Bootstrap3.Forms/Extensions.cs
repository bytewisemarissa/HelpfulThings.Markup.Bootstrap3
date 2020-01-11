using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace HelpfulThings.Markup.Bootstrap3Forms
{
    public static class Extensions
    {
        public static T GetAttribute<T>(this ICustomAttributeProvider provider)
            where T : Attribute
        {
            var attributes = provider.GetCustomAttributes(typeof(T), true);
            return attributes.Length > 0 ? attributes[0] as T : null;
        }

        public static string GetDescription<T, TV>(this Expression<Func<T, TV>> expression)
        {
            if (!(expression.Body is MemberExpression memberExpression))
                throw new InvalidOperationException("Expression must be a member expression");
            
            return memberExpression.Member.GetAttribute<DescriptionAttribute>()?.Description;
        }
    }
}

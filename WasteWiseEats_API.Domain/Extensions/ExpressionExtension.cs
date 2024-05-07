using System.Linq.Expressions;

namespace WasteWiseEats_API.Domain.Extensions
{
    public static class ExpressionExtension
    {
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expression, Expression<Func<T, bool>> andExpression)
        {
            ParameterExpression paramter = expression.Parameters.First();

            SubstExpressionVisitor visitor = new()
            {
                subst =
                {
                    [andExpression.Parameters.First()] = paramter
                }
            };

            Expression body =
                Expression.AndAlso(expression.Body, visitor.Visit(andExpression.Body));

            return Expression.Lambda<Func<T, bool>>(body, paramter);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expression, Expression<Func<T, bool>> orExpression)
        {
            ParameterExpression parameter = expression.Parameters.First();

            SubstExpressionVisitor visitor = new()
            {
                subst =
                {
                    [orExpression.Parameters.First()] = parameter
                }
            };

            Expression body =
                Expression.OrElse(expression.Body, visitor.Visit(orExpression.Body));

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }
    internal class SubstExpressionVisitor : ExpressionVisitor
    {
        public Dictionary<Expression, Expression> subst = new();

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return subst.TryGetValue(node, out Expression newValue)
                ? newValue
                : node;
        }
    }
}

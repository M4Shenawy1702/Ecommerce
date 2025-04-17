using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public abstract class Specifcation<T> where T : class
    {
        public Expression<Func<T, bool>>? Criteria { get; }//where
        public List<Expression<Func<T, object>>> IncludeExpression { get; } = new();
        public Expression<Func<T, object>> Orderby { get; private set; }
        public Expression<Func <T, object>> OrderbyDescending { get; private set; }
        protected Specifcation(Expression<Func<T, bool>>? criteria)
        {
            Criteria = criteria;
        }
        protected void AddInclude(Expression<Func<T, object>> expression)
            => IncludeExpression.Add(expression);
        protected void  SetOrderby(Expression<Func<T, object>> expression)
        {
            Orderby = expression;
        }
        protected void SetbyDesc(Expression<Func<T, object>> expression)
        {
            OrderbyDescending = expression;
        }


    }
}

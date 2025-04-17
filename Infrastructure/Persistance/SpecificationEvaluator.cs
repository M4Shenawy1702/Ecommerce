using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public abstract class SpecificationEvaluator
    {
        public static IQueryable<T>GetQuery<T> (IQueryable<T> InputQuery , Specifcation<T> specifcation) where T : class
        {
            var query = InputQuery;
            if (specifcation.Criteria is not null) query = query.Where(specifcation.Criteria);//where
            query = specifcation.IncludeExpression.Aggregate(query, (currentquery, includeexpression) => currentquery.Include(includeexpression));
           if(specifcation.Orderby is not null)
            {
                query=query.OrderBy(specifcation.Orderby);
            }
           else if (specifcation.OrderbyDescending is not null)
            {
                query = query.OrderByDescending(specifcation.OrderbyDescending);
            }
            return query;

        }
        // _dbcontext.set<T> ===> iquerable
        // _dbcontxt.set<T>().where(specification.Criteria).Include(exp)
    }
}

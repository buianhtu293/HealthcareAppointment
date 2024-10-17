using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HealthcareAppointment.Models.Interfaces;

namespace HealthcareAppointment.Models.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification() { }

        public BaseSpecification(Expression<Func<T, bool>> fillter)
        {
            Fillter = fillter;
        }
        public Expression<Func<T, bool>> Fillter { get; private set; }

        public List<Expression<Func<T, object>>> Includes { get; private set; } = new List<Expression<Func<T, object>>> { };

        public Expression<Func<T, object>> OrderByAscending { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnable { get; private set; }

        public void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        public void AddOrderByAscending(Expression<Func<T, object>> orderByAscendingExpression)
        {
            OrderByAscending = orderByAscendingExpression;
        }

        public void AddOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        }

        public void ApplyPaging(int take, int skip)
        {
            Take = take;
            Skip = skip;
            IsPagingEnable = true;
        }
    }
}

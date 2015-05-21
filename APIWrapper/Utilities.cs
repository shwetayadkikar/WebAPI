using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace APIWrapper
{
    public class Utilities
    {
        public static string GetProps<T>(Expression<Func<T, object>> parameters)
        {
            StringBuilder requestedParametersString = new StringBuilder();
            if (parameters != null && parameters.Body != null)
            {
                var body = parameters.Body as System.Linq.Expressions.NewExpression;
                if (body.Members != null && body.Members.Any())
                {
                    foreach (var member in body.Members)
                    {
                        requestedParametersString.Append(member.Name + ",");
                    }
                }
            }
            return requestedParametersString.ToString();
        }
    }
}

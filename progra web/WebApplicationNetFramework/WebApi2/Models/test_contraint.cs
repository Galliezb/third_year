using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace WebApi2.Models {
    public class Test_contraint : IrouteConstraint {

        public bool Match(HttpContextBase httpContext, Route route, string parameterName,
                          RouteValueDictionary values, RouteDirection routeDirection) {
            return httpContext.Request.IsLocal;
        }


    }
}
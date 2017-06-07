using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace StudentsWebAPI.Filters
{
    public class AuthenticationFilter : AuthorizationFilterAttribute
    {

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // check bearer token in the request headers

            var token = FetchFromHeader(actionContext);
            if (token != null)
            {
                // validate the claims from the token here

            }else
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                        return;
            }
            base.OnAuthorization(actionContext);

        }

        private string FetchFromHeader(HttpActionContext actionContext)
        {
            string requestToken = null;

            var authRequest = actionContext.Request.Headers.Authorization;
            if (authRequest != null && !string.IsNullOrEmpty(authRequest.Scheme) && authRequest.Scheme == "Basic")
                requestToken = authRequest.Parameter;
            // hard coding some text to simulate a proper token scenario for all requests
            requestToken = "Some bearer token which is expected from all request";

            return requestToken;
        }
    }
}
using System;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using developwithpassion.specifications.extensions;

namespace app.specs.utility
{
  public class ObjectFactory
  {
    public static class expressions
    {
      public static ExpressionBuilder<ItemToTarget> to_target<ItemToTarget>()
      {
      }

      public class ExpressionBuilder<ItemToTarget>
      {
        public ConstructorInfo get_ctor_of(Expression<Func<ItemToTarget>> ctor)
        {
          return ctor.Body.downcast_to<NewExpression>().Constructor;
        }
      }
    }

    public class web
    {
      public static HttpContext create_http_context()
      {
        return new HttpContext(create_request(), create_response());
      }

      static HttpRequest create_request()
      {
        return new HttpRequest("blah.aspx", "http://localhost/blah.aspx", String.Empty);
      }

      static HttpResponse create_response()
      {
        return new HttpResponse(new StringWriter());
      }
    }
  }
}
 using System.Web;
 using Machine.Specifications;
 using app.specs.utility;
 using app.web.core;
 using app.web.core.aspnet;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(ASPHandler))]  
  public class ASPHandlerSpecs
  {
    public abstract class concern : Observes<IHttpHandler,
                                      ASPHandler>
    {
        
    }

   
    public class when_processing_an_http_context : concern
    {
      Establish c = () =>
      {
        front_controller = depends.on<IProcessRequests>();
        request_factory = depends.on<ICreateControllerRequests>();
        controller_request = new object();


        the_current_context = ObjectFactory.web.create_http_context();
        request_factory.setup(x => x.create_request_from(the_current_context)).Return(controller_request);
      };

      Because b = () =>
        sut.ProcessRequest(the_current_context);


      It should_delegate_the_processing_of_a_controller_request_to_the_front_controller = () =>
        front_controller.received(x => x.process(controller_request));

      static IProcessRequests front_controller;
      static object controller_request;
      static HttpContext the_current_context;
      static ICreateControllerRequests request_factory;
    }
  }
}

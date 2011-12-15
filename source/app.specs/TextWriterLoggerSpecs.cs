 using System.IO;
 using System.Text;
 using Machine.Specifications;
 using app.infrastructure;
 using app.infrastructure.logging.simple;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(TextWriterLogger))]  
  public class TextWriterLoggerSpecs
  {
    public abstract class concern : Observes<ILogInformation,
                                      TextWriterLogger>
    {
        
    }

   
    public class when_logging_an_informational_message : concern
    {
      Establish c = () =>
      {
        message = "This is the message";
        builder = new StringBuilder();
        created_message = "sdfsdfsdf";
        depends.on<TextWriter>(new StringWriter(builder));
        depends.on(typeof(when_logging_an_informational_message));
        depends.on<LoggingMessageFormatter>((the_message, type) =>
        {
          type.ShouldEqual(typeof(when_logging_an_informational_message));
          the_message.ShouldEqual(message);
          return created_message;
        });
      };

      Because b = () =>
        sut.informational(message);


      It should_write_the_message_to_its_text_writer_with_the_correct_details = () =>
      {
        var result = builder.ToString();
        result.ShouldContain(created_message);
      };


      static StringBuilder builder;
      static string message;
      static string created_message;
    }
  }
}

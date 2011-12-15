using System.IO;
using Machine.Specifications;
using app.infrastructure;
using app.infrastructure.logging.simple;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(TextWriterLoggerFactory))]
  public class TextWriterLoggerFactorySpecs
  {
    public abstract class concern : Observes<ICreateLoggers,
                                      TextWriterLoggerFactory>
    {
    }

    public class when_creating_a_logger : concern
    {
      Establish c = () =>
      {
        the_writer = new StringWriter();
        depends.on<CreateLoggingWriter>(() => the_writer);
        formatter = (x,y) => "yes";
        depends.on<LoggingMessageFormatter>(formatter);
      };

      Because b = () =>
        result = sut.create_logger_for(typeof(int));

      It should_return_a_logger_initialized_with_the_correct_details = () =>
      {
        var item = result.ShouldBeAn<TextWriterLogger>();
        item.calling_type.ShouldEqual(typeof(int));
        item.writer.ShouldEqual(the_writer);
        item.formatter.ShouldEqual(formatter);
      };

      static ILogInformation result;
      static TextWriter the_writer;
      static LoggingMessageFormatter formatter;
    }
  }
}
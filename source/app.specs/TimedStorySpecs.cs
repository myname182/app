 using Machine.Specifications;
 using Rhino.Mocks;
 using app.infrastructure;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(TimedStory))]  
  public class TimedStorySpecs
  {
    public abstract class concern : Observes<ISupportAStory,
                                      TimedStory>
    {
        
    }

   
    public class when_run : concern
    {
      Establish c = () =>
      {
        original = depends.on<ISupportAStory>();  
        logger = depends.on<ILogInformation>();
        request = fake.an<IProvideDetailsToCommands>();
        stop_watch = depends.on<ITimeThings>();
        time_ran = 1223;
        stop_watch.setup(x => x.stop()).Return(time_ran);
      };

      Because b = () =>
        sut.process(request);

      It should_start_the_stop_watch = () =>
        stop_watch.received(x => x.start());

      It should_run_the_original_story = () =>
        original.received(x => x.process(request));

      It should_log_the_details_of_running_the_story = () =>
        logger.received(x => x.informational(Arg<string>.Matches(item => item.Contains(time_ran.ToString()))));


      static ITimeThings stop_watch;
      static IProvideDetailsToCommands request;
      static ISupportAStory original;
      static ILogInformation logger;
      static int time_ran;
    }
  }
}

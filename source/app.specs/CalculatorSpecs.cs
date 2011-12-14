using System;
using System.Data;
using System.Security;
using System.Security.Principal;
using System.Threading;
using Machine.Specifications;
using Rhino.Mocks;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  public class CalculatorSpecs
  {
    public abstract class concern : Observes<ICalculate,Calculator>
    {
      
    }

    public class when_attempting_to_add_negative_numbers   :concern
    {
      Because b = () =>
        spec.catch_exception(() => sut.add(-2, 3));

      It should_throw_an_argument_exception = () =>
        spec.exception_thrown.ShouldBeAn<ArgumentException>();

    } 

    public class when_attempting_to_shut_off_the_calculator :concern
    {
      public class and_they_are_not_in_the_correct_security_role:when_attempting_to_shut_off_the_calculator
      {
        Establish c = () =>
        {
          principal = fake.an<IPrincipal>();
          principal.setup(x => x.IsInRole(Arg<string>.Is.NotNull)).Return(false);

          spec.change(() => Thread.CurrentPrincipal).to(principal);
        };

        Because b = () =>
          spec.catch_exception(() => sut.shut_off());


        It should_throw_a_security_exception = () =>
          spec.exception_thrown.ShouldBeAn<SecurityException>();

        static IPrincipal principal;
      }

      public class and_they_are_in_the_correct_security_role:when_attempting_to_shut_off_the_calculator
      {
        Establish c = () =>
        {
          principal = fake.an<IPrincipal>();
          principal.setup(x => x.IsInRole(Arg<string>.Is.NotNull)).Return(true);

          spec.change(() => Thread.CurrentPrincipal).to(principal);
        };

        Because b = () =>
          sut.shut_off();



        static IPrincipal principal;
      }
    } 
    public class when_adding_two_positive_numbers :concern
    {
      Establish c = () =>
      {
        //providing a ctor value explicitly
        depends.on(3);
        connection = depends.on<IDbConnection>();
        command = fake.an<IDbCommand>();
        //explicit sut creation
//        sut_factory.create_using(() => new Calculator(connection, 3,4));

        connection.setup(x => x.CreateCommand()).Return(command);
      };

      Because b = () =>
        result = sut.add(2, 3);

      It should_open_a_connection_to_the_database = () =>
        connection.received(x => x.Open());

      It should_run_a_query = () =>
        command.received(x => x.ExecuteNonQuery());


      It should_return_the_sum = () =>
        result.ShouldEqual(5);

      static int result;
      static IDbConnection connection;
      static IDbCommand command;
    } 
  }
}
using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    using System.Collections.Generic;

    using developwithpassion.specifications.extensions;

    [Subject(typeof(ViewTheProductsInADepartment))]
  public class ViewTheProductsInADepartmentSpecs
  {
    public abstract class concern : Observes<ISupportAStory,
                                      ViewTheProductsInADepartment>
    {
    }

    public class when_run : concern
    {
        Establish c = () =>
            {
                product_repository = depends.on<IFindProducts>();
                display_engine = depends.on<IDisplayReports>();
                request = fake.an<IProvideDetailsToCommands>();
                the_products = new List<ProductItem>();
                request.setup(x => x.map<DepartmentItem>()).Return(the_department);
                product_repository.setup(x => x.get_all_products_in_department(the_department));
            };

        private Because b = () => sut.process(request);

        private It should_display_products_in_the_department =
            () => display_engine.received(x => x.display(the_products));

        private static IProvideDetailsToCommands request;
        private static IFindProducts product_repository;
        private static IDisplayReports display_engine;
        private static List<ProductItem> the_products;
        private static DepartmentItem the_department;
    }
  }
}
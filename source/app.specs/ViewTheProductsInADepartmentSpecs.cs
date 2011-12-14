using System.Collections.Generic;
using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
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
        store_catalog = depends.on<IFindInformationInTheStore>();
        display_engine = depends.on<IDisplayReports>();
        request = fake.an<IProvideDetailsToCommands>();
        the_department = new DepartmentItem();
        the_products = new List<ProductItem> {new ProductItem()};
        
        request.setup(x => x.map<DepartmentItem>()).Return(the_department);
        store_catalog.setup(x => x.get_all_products_in(the_department)).Return(the_products);
      };

      Because b = () => sut.process(request);

      It should_display_products_in_the_department =
        () => display_engine.received(x => x.display(the_products));

      static IProvideDetailsToCommands request;
      static IFindInformationInTheStore store_catalog;
      static IDisplayReports display_engine;
      static IEnumerable<ProductItem> the_products;
      static DepartmentItem the_department;
    }
  }
}
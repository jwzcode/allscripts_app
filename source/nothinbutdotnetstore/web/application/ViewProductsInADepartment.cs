using nothinbutdotnetstore.web.application.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application
{
    public class ViewProductsInADepartment : IPerformApplicationBehaviour
    {
        ICanGetInformationFromTheStoreCatalog store_catalog;
        IDisplayReports display_engine;

        public ViewProductsInADepartment(ICanGetInformationFromTheStoreCatalog store_catalog, IDisplayReports display_engine)
        {
            this.store_catalog = store_catalog;
            this.display_engine = display_engine;
        }

        public ViewProductsInADepartment() : this(new StubStoreCatalog(),
                                                  new StubDisplayEngine())
        {
        }

        public void process(IContainRequestInformation request)
        {
            display_engine.display(
                store_catalog.get_the_products_in(request.map<Department>()));
        }
    }
}
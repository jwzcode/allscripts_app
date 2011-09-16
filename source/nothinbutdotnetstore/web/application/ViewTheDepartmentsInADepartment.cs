using nothinbutdotnetstore.web.application.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application
{
    public class ViewTheDepartmentsInADepartment : IPerformApplicationBehaviour
    {
        ICanGetInformationFromTheStoreCatalog information_from_the_store_catalog_repository;
        IDisplayReports display_engine;

        public ViewTheDepartmentsInADepartment(
            ICanGetInformationFromTheStoreCatalog information_from_the_store_catalog_repository,
            IDisplayReports display_engine)
        {
            this.information_from_the_store_catalog_repository = information_from_the_store_catalog_repository;
            this.display_engine = display_engine;
        }

        public ViewTheDepartmentsInADepartment() : this(new StubStoreCatalog(),
                                                        new StubDisplayEngine())
        {
        }

        public void process(IContainRequestInformation request)
        {
            display_engine.display(
                information_from_the_store_catalog_repository.get_the_departments_in(request.map<Department>()));
        }
    }
}
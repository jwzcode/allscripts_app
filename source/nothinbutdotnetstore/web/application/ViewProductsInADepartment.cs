using nothinbutdotnetstore.web.application.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application
{
    public interface IFindA<ReportModel>
    {
        ReportModel run_report_using(IContainRequestInformation request);
    }

    public class ViewReport<ReportModel> : IPerformApplicationBehaviour
    {
        IDisplayReports display_engine;
        IFindA<ReportModel> query;

        public ViewReport(IDisplayReports display_engine, IFindA<ReportModel> query)
        {
            this.display_engine = display_engine;
            this.query = query;
        }

        public ViewReport(IFindA<ReportModel> query):this(Stub.with<StubDisplayEngine>(),query)
        {
        }

        public void process(IContainRequestInformation request)
        {
            display_engine.display(query.run_report_using(request));
        }
    }

    public class ViewProductsInADepartment : IPerformApplicationBehaviour
    {
        ICanGetInformationFromTheStoreCatalog store_catalog;
        IDisplayReports display_engine;

        public ViewProductsInADepartment(ICanGetInformationFromTheStoreCatalog store_catalog,
                                         IDisplayReports display_engine)
        {
            this.store_catalog = store_catalog;
            this.display_engine = display_engine;
        }

        public ViewProductsInADepartment() : this(Stub.with<StubStoreCatalog>(), Stub.with<StubDisplayEngine>())
        {
        }

        public void process(IContainRequestInformation request)
        {
            display_engine.display(
                store_catalog.get_the_products_in(request.map<Department>()));
        }
    }
}
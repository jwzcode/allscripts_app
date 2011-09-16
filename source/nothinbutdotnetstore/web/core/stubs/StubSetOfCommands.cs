using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.application.stubs;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubSetOfCommands:IEnumerable<IProcessARequest>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<IProcessARequest> GetEnumerator()
        {
                yield return new RequestHandlingCommand(x => true,
                                                    new ViewReport<IEnumerable<Product>>(
                                                        new GetTheProductsInADepartment()));
        }
    }

    public class GetTheProductsInADepartment : IFindA<IEnumerable<Product>>
    {
        ICanGetInformationFromTheStoreCatalog catalog;

        public GetTheProductsInADepartment(ICanGetInformationFromTheStoreCatalog catalog)
        {
            this.catalog = catalog;
        }

        public GetTheProductsInADepartment():this(Stub.with<StubStoreCatalog>())
        {
        }

        public IEnumerable<Product> run_report_using(IContainRequestInformation request)
        {
            return catalog.get_the_products_in(request.map<Department>());
        }
    }
}
using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(ViewTheMainDepartmentsInTheStore))]
    public class ViewTheMainDepartmentsInTheStoreSpecs
    {
        public abstract class concern : Observes<IPerformApplicationBehaviour,
                                            ViewTheMainDepartmentsInTheStore>
        {
        }


        public class when_processing_a_request : concern
        {
            Establish c = () =>
            {
                all_main_departments = new List<Department>{new Department()};
                information_from_the_store_catalog_repository = depends.on<ICanGetInformationFromTheStoreCatalog>();
                display_engine = depends.on<IDisplayReports>();
                request = fake.an<IContainRequestInformation>();

                information_from_the_store_catalog_repository.setup(x => x.get_the_main_departments_in_the_store())
                    .Return(all_main_departments);

            };

            Because b = () =>
                sut.process(request);

            It should_get_a_list_of_the_main_departments_in_the_store = () =>
                information_from_the_store_catalog_repository.received(x => x.get_the_main_departments_in_the_store());

            It should_display_the_main_departments = () =>
                display_engine.received(x => x.display(all_main_departments));

                

            static IContainRequestInformation request;
            static ICanGetInformationFromTheStoreCatalog information_from_the_store_catalog_repository;
            static IEnumerable<Department> all_main_departments;
            static IDisplayReports display_engine;
        }
    }
}
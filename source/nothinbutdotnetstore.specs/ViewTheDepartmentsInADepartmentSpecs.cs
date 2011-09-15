using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(ViewTheDepartmentsInADepartment))]
    class ViewTheDepartmentsInADepartmentSpecs
    {
        public abstract class concern : Observes<IPerformApplicationBehaviour,
                                            ViewTheDepartmentsInADepartment>
        {
        }

        public class when_processing_a_request : concern
        {
            Establish c = () =>
            {
                all_sub_departments = new List<Department> {new Department()};
                parent_department = new Department();
                information_from_the_store_catalog_repository = depends.on<ICanGetInformationFromTheStoreCatalog>();
                display_engine = depends.on<IDisplayReports>();
                request = fake.an<IContainRequestInformation>();

                information_from_the_store_catalog_repository.setup(x => x.get_the_departments_in(parent_department))
                    .Return(all_sub_departments);

                request.setup(x => x.map<Department>()).Return(parent_department);
            };

            Because b = () =>
                sut.process(request);

            It should_display_a_departments = () =>
                display_engine.received(x => x.display(all_sub_departments));

            static IContainRequestInformation request;
            static ICanGetInformationFromTheStoreCatalog information_from_the_store_catalog_repository;
            static IEnumerable<Department> all_sub_departments;
            static IDisplayReports display_engine;
            static Department parent_department;
        }
    }
}
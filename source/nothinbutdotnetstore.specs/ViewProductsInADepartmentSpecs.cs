using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(ViewProductsInADepartment))]
    public class ViewProductsInADepartmentSpecs
    {
        public abstract class concern : Observes<IPerformApplicationBehaviour, ViewProductsInADepartment>
        {
        }

        public class when_observation_name : concern
        {
            Establish c = () =>
            {
                all_products_in_a_department = new List<Product> {new Product()};
                parent_department = new Department();
                product_repository = depends.on<ICanGetInformationFromTheStoreCatalog>();
                display_engine = depends.on<IDisplayReports>();
                request = fake.an<IContainRequestInformation>();

                product_repository.setup(x => x.get_the_products_in(parent_department))
                    .Return(all_products_in_a_department);

                request.setup(x => x.map<Department>()).Return(parent_department);
            };

            Because b = () =>
                sut.process(request);

            It should_display_products_in_a_department = () =>
                display_engine.received(x => x.display(all_products_in_a_department));

            static Department dept;
            static IContainRequestInformation request;
            static ICanGetInformationFromTheStoreCatalog product_repository;
            static IEnumerable<Product> all_products_in_a_department;
            static IDisplayReports display_engine;
            static Department parent_department;
        }
    }
}
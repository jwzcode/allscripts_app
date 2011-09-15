using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.application.stubs
{
    public class StubStoreCatalog : ICanGetInformationFromTheStoreCatalog
    {
        public IEnumerable<Department> get_the_main_departments_in_the_store()
        {
            return Enumerable.Range(1, 199).Select(x => new Department {name = x.ToString("Department 0")});
        }

        public IEnumerable<Department> get_the_departments_in(Department parent)
        {
            return Enumerable.Range(1, 199).Select(x => new Department {name = x.ToString("Sub Department 0")});
        }
        public IEnumerable<Product> get_the_products_in(Department parent_department)
        {
            return Enumerable.Range(1, 199).Select(x => new Product { name = x.ToString("Product 0") });
        }
    }
}
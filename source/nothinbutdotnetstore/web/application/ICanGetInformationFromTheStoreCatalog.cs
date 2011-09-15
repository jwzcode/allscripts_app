using System.Collections.Generic;

namespace nothinbutdotnetstore.web.application
{
    public interface ICanGetInformationFromTheStoreCatalog
    {
        IEnumerable<Department> get_the_main_departments_in_the_store();
        IEnumerable<Department> get_the_departments_in(Department parent_department);
        IEnumerable<Product> get_the_products_in(Department parent_department);
    }
}
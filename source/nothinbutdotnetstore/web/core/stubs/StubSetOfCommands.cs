using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.web.application;

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
                                                    new ViewProductsInADepartment());
        }
    }
}
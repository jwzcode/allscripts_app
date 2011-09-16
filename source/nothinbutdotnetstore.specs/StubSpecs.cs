using Machine.Specifications;
using nothinbutdotnetstore.web.core.stubs;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(Stub))]
    public class StubSpecs
    {
        public class when_creating_a_stub 
        {
            Because b = () =>
                result = Stub.with<AStub>();

            It should_return_an_instance_of_the_requested_stub_type = () =>
                result.ShouldBeAn<AStub>();

            static AStub result;
        }

        public class AStub
        {

        }
    }
}
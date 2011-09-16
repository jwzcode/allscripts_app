using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(Stub))]
    public class StubSpec
    {
        public abstract class concern : Observes<Stub>
        {

        }

        public class when_create_stub_display_engine : concern
        {
            Because b = () =>
                result = Stub.With<StubDisplayEngine>();

            It it_should_be_display_engine_type = () => result.ShouldBeOfType<StubDisplayEngine>();

            static StubDisplayEngine result;
                
        }

        public class when_create_stub_request_factory : concern
        {
            Because b = () =>
                result = Stub.With<StubRequestFactory>();

            It it_should_be_display_request_factory = () => result.ShouldBeOfType<StubRequestFactory>();

            static StubRequestFactory result;

        }
    }
}

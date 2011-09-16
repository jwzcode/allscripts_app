using System.Web;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core
{
    public class RawHttpHandler : IHttpHandler
    {
        IProcessRequests front_controller;
        ICreateRequests request_factory;

        public RawHttpHandler() : this(new FrontController(), Stub.with<StubRequestFactory>())
        {
        }

        public RawHttpHandler(IProcessRequests front_controller, ICreateRequests request_factory)
        {
            this.front_controller = front_controller;
            this.request_factory = request_factory;
        }

        public void ProcessRequest(HttpContext context)
        {
            front_controller.process(request_factory.create_request_from(context));
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}
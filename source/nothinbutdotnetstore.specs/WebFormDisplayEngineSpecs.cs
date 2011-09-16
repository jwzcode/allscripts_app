using System;
using System.Collections.Generic;
using System.Web;
using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.aspnet;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(WebFormDisplayEngine))]
    public class WebFormDisplayEngineSpecs
    {
        public abstract class concern : Observes<IDisplayReports,
                                            WebFormDisplayEngine>
        {
        }

        public class when_displaying_a_report : concern
        {
            Establish c = ()=>
            {
                someData = new Object();

                path = "somepage.aspx";
                http_context = ObjectFactory.web.create_http_context();
                depends.on(http_context);
                depends.on(path);
            };

            Because b = () =>
                sut.display(someData);

            It should_set_the_data_in_context = () =>
                http_context.Items["data"].ShouldNotBeNull();

            It data_in_context_should_be_the_same_as_input_data = () =>
                http_context.Items["data"].ShouldBeTheSameAs(someData);

            //It should_transfer_to_a_page = () =>
            //    http_context.Server.received(x => x.Transfer(path));

            static System.Web.HttpContext http_context;
            static object someData;
            static IHttpHandler http_handler;
            static string path;
        }
    }

}
using System.Web;

namespace nothinbutdotnetstore.web.core.aspnet
{
    public class WebFormDisplayEngine :IDisplayReports
    {
        HttpContext http_context;
        string target_page_url;

        public WebFormDisplayEngine(HttpContext http_context, string target_page_url)
        {
            this.http_context = http_context;
            this.target_page_url = target_page_url;
        }

        public void display<ReportModel>(ReportModel model)
        {
            http_context.Items.Add("data",model);
            //http_context.Server.Transfer(target_page_url);

        }
    }
}
using Umbraco.Cms.Core.Dashboards;

namespace Portfolio.Core.Models.Umbraco.Dashboards
{
    public class ContactDashboard : IDashboard
    {
        public string Alias => "contactDashboard";
        public string View => "/App_Plugins/ContactDashboard/dashboard.html";
        public string[] Sections => new[] { "content" };
        public IAccessRule[] AccessRules => null;
    }
}
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Portfolio.Core.Extensions;
using Portfolio.Core.Models.Umbraco;
using Portfolio.Core.Models.ViewModels;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Extensions;

namespace Portfolio.Core.Controllers.Render
{
    public class SearchController : RenderController
    {

        private List<IPublishedContent> Recurrent(IPublishedContent currentNode, List<IPublishedContent> nodes, string search)
        {

            foreach (var property in currentNode.Properties)
            {
                if (!property.GetValue().ToString()!.Contains(search)) continue;
                nodes.Add(currentNode);
                break;
            }
            
            if (currentNode.Children != null)
            {
                nodes.AddRange(currentNode.Children);

                foreach (var child in currentNode.Children)
                {
                    Recurrent(child, nodes, search);
                }
            }

            return nodes;
        }
        
        public IActionResult Search(string query = null)
        {
            var search = (Search)CurrentPage;
            var viewModel = new SearchViewModel();
            viewModel.Build(CurrentPage);
            
            var children = new List<IPublishedContent>();

            children = Recurrent(viewModel.Content.Root(), children, query);
            
            viewModel.Results = children;

            return CurrentTemplate(viewModel);
        }
        
        public SearchController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using OnatrixCMS.Services;
using OnatrixCMS.ViewModels;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace OnatrixCMS.Controllers;

public class FormController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, FormSubmissionService formSubmissionService) : SurfaceController(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
{
    private readonly FormSubmissionService _formSubmissionService = formSubmissionService;

    public IActionResult HandleCallbackForm(CallbackViewModel model)
    {
        if (!ModelState.IsValid)
        {
            // Handle error
            return CurrentUmbracoPage();
        }

        var result = _formSubmissionService.SaveCallbackRequest(model);

        if (!result)
        {
            // Handle error
            return RedirectToCurrentUmbracoPage();
        }

        // Handle success
        return RedirectToCurrentUmbracoPage();
    }
}

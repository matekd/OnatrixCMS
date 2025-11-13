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

public class FormController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, FormSubmissionService formSubmissionService, EmailService emailService) : SurfaceController(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
{
    private readonly FormSubmissionService _formSubmissionService = formSubmissionService;
    private readonly EmailService _emailService = emailService;

    public async Task<IActionResult> HandleCallbackForm(CallbackViewModel model)
    {
        if (!ModelState.IsValid)
            return CurrentUmbracoPage();

        var result = _formSubmissionService.SaveCallbackRequest(model);

        if (!result)
        {
            TempData["FormError"] = "Something went wrong.";
            return RedirectToCurrentUmbracoPage();
        }

        await _emailService.SendEmail(
            model.Email,
            "Formulär bekräftelse",
            @"Din förfrågan har tagits emot. Vi komer att svara inom kort.",
            @"<html>
			    <body>
				    <p>
					    Din förfrågan har tagits emot.
				    </p>

                    <p>
					    Vi komer att svara inom kort.
				    </p>

                    <p>
                        © Onatrix. All rights reserved.
                    </p>
			    </body>
		    </html>"
            );

        TempData["FormSuccess"] = "Your request has been saved.";
        return RedirectToCurrentUmbracoPage();
    }

    public async Task<IActionResult> HandleSupportForm(SupportViewModel model)
    {
        if (!ModelState.IsValid)
            return CurrentUmbracoPage();

        var result = _formSubmissionService.SaveSupportRequest(model);

        if (!result)
        {
            TempData["FormError"] = "Something went wrong.";
            return RedirectToCurrentUmbracoPage();
        }

        await _emailService.SendEmail(
            model.Email,
            "Formulär bekräftelse",
            @"Din förfrågan har tagits emot. Vi komer att svara inom kort.",
            @"<html>
			    <body>
				    <p>
					    Din förfrågan har tagits emot.
				    </p>

                    <p>
					    Vi komer att svara inom kort.
				    </p>

                    <p>
                        © Onatrix. All rights reserved.
                    </p>
			    </body>
		    </html>"
            );

        TempData["FormSuccess"] = "Your request has been saved.";
        return RedirectToCurrentUmbracoPage();
    }

    public async Task<IActionResult> HandleQuestionForm(QuestionViewModel model)
    {
        if (!ModelState.IsValid)
            return CurrentUmbracoPage();
        

        var result = _formSubmissionService.SaveQuestionRequest(model);

        if (!result)
        {
            TempData["FormError"] = "Something went wrong.";
            return RedirectToCurrentUmbracoPage();
        }

        await _emailService.SendEmail(
            model.Email,
            "Formulär bekräftelse",
            @"Din förfrågan har tagits emot. Vi komer att svara inom kort.",
            @"<html>
			    <body>
				    <p>
					    Din förfrågan har tagits emot.
				    </p>

                    <p>
					    Vi komer att svara inom kort.
				    </p>

                    <p>
                        © Onatrix. All rights reserved.
                    </p>
			    </body>
		    </html>"
            );

        TempData["FormSuccess"] = "Your request has been saved.";
        return RedirectToCurrentUmbracoPage();
    }
}

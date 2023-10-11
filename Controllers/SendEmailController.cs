using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Accounts;
using WebApi.Models.Email;
using WebApi.Services;

namespace WebApi.Controllers;

// [Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class SendEmailController : Controller
{
    private readonly IEmailService _emailService;

    public SendEmailController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    [AllowAnonymous]
    public ActionResult Send(EmailModel model)
    {
        _emailService.Send(model.To, model.Subject, model.Html, model.From);
        return Ok(new {msg = "Ok"});
    }
    [HttpPost]
    [AllowAnonymous]
    public ActionResult SendOfQq(EmailRequest model)
    {
        _emailService.SendOfQq(model);
        return Ok(new {msg = "Ok"});
    }
    [HttpGet]
    // [AllowAnonymous]
    public ActionResult SendOfQq()
    {
        // _emailService.SendOfQq(model);
        return Ok(new {msg = "Ok"});
    }
}
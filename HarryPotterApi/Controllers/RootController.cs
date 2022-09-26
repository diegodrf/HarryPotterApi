﻿using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
[ApiController]
[Route("")]
public class RootController: ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        var scheme = HttpContext.Request.Scheme;
        var host = HttpContext.Request.Host.Host;
        var port = HttpContext.Request.Host.Port ?? (scheme.Contains('s') ? 443 : 80);
        var path = "swagger/index.html";
        var uri = new UriBuilder(scheme, host, port, path).ToString();
        return Redirect(uri);
    }
}
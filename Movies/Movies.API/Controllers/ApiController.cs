using System;
using Microsoft.AspNetCore.Mvc;

namespace Movies.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ApiController : ControllerBase
    {
        public ApiController()
        {
        }
    }
}


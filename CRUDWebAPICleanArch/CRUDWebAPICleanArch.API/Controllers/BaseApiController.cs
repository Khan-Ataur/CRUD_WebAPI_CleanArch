using CRUDWebAPICleanArch.API.Filter;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWebAPICleanArch.API.Controllers
{
    [Route("api/[controller]")]
    [TypeFilter(typeof(AuthorizationFilterAttribute))]
    [ApiController]
    public class BaseApiController : Controller
    {
    }
}

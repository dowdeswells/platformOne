using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using leases.api.Application;
using Microsoft.AspNetCore.Mvc;

namespace leases.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IValuesRepository _repo;
        private readonly ISomeHelper _someHelper;

        public ValuesController(IValuesRepository repo, ISomeHelper someHelper)
        {
            _repo = repo;
            _someHelper = someHelper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _someHelper.DoSomething();
            return _repo.GetAll().ToArray();
        }

    }
}
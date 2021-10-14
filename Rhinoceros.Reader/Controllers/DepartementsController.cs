using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rhinoceros.Reader.Repositories;
using Rhinoceros.Reader.Services;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rhinoceros.Reader.Controllers
{

    [ApiController]
    [Route("api/departements")]
    public class DepartementsController : ControllerBase
    {
        private readonly ILogger<DepartementsController> _logger;

        public DepartementsController(ILogger<DepartementsController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [Route("all")]

        public ActionResult<IEnumerable<Departement>> Get()
        {
            try
            {
                return Ok(DepartementService.GetAll());

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("name?{name}")]
        public ActionResult<IEnumerable<Departement>> GetDeptByName(string name)
        {
            try
            {
                return Ok(DepartementService.GetDeptByName(name));

            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpGet]
        [Route("name?{code}")]
        public ActionResult<IEnumerable<Departement>> GetDeptByCode(string code)
        {
            try
            {
                return Ok(DepartementService.GetDeptByName(code));

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


        [HttpPost]
        [Route("search?{param}")]
        public ActionResult<IEnumerable<Departement>> GetDeptByParams(string param)
        {
            try
            {
                return Ok(DepartementService.GetDeptByName(param));

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}

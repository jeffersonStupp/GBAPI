using Azure.Identity;
using GB.dominio.Entidades;
using GB.dominio.Interfaces;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

namespace GBAPI.Controllers
{
    public class GBControler : Controller
    {
        private readonly IUserServico _userservico;

        public GBControler(IUserServico userservico)
        {
            _userservico = userservico;
        }

        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(User model)
        {
            try
            {
                _userservico.AddUser(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet]
        [Route("logar")]
        public IActionResult Logar(string username, string password)
        {
            return Ok();
        }
    }
}
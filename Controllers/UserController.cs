using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContaBill.Data;
using ContaBill.Models;
using ContaBill.Repositories;
using ContaBill.Services;
using Microsoft.AspNetCore.Authorization;
using System;

namespace ContaBill.Controllers
{
  [ApiController]
  [Route("v1/users")]
  public class UserController : ControllerBase
  {

    private readonly UserRepository _repository;

    public UserController(UserRepository repository)
    {
      _repository = repository;
    }

    public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
    {
      var user = _repository.Get(model.Username, model.Password);

      if (user == null)
      {
        return NotFound(new { message = "Usuário ou senha inválidos!" });
      }

      var token = TokenService.GenerateToken(user);

      user.Password = "";

      return new
      {
        user = user,
        token = token
      };
    }

    [HttpGet]
    [Route("anonymous")]
    [AllowAnonymous]
    public string Anonymous() => "Anônimo";

    [HttpGet]
    [Route("authenticated")]
    [Authorize]
    public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

    [HttpGet]
    [Route("employee")]
    [Authorize(Roles = "employee,manager")]
    public string Employee() => "Funcionário";

    [HttpGet]
    [Route("manager")]
    [Authorize(Roles = "manager")]
    public string Manager() => "Gerente";
  }
}

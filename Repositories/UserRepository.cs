using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContaBill.Models;
using ContaBill.Data;
using ContaBill.DTO;

namespace ContaBill.Repositories
{
  public class UserRepository
  {

    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
      _context = context;
    }

    public User Get(string username, string password)
    {
      var users = _context.Users.ToList();
      return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
    }
  }
}

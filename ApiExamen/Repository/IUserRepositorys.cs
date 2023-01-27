using ApiExamen.Dtos;
using ApiExamen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExamen.Repository
{
    public interface IUserRepositorys
    {
        UserDTO GetUser(UserModel userMode);
    }
}

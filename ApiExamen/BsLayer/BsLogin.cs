using ApiExamen.Data;
using ApiExamen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExamen.BsLayer
{
    public class BsLogin
    {
        private readonly ExamendbContext _dbCntext;
        OperationResult<Models.UserResponse> operationResult = new OperationResult<Models.UserResponse>();

        public BsLogin(ExamendbContext dbcontext)
        {
            _dbCntext = dbcontext;
        }

        public OperationResult<User> GetCUser(UserLogin user)
        {
            OperationResult<User> operationResult = new OperationResult<User>();
            try
            {
                var existe = _dbCntext.Users.Where(u=>u.IdUser.Equals(user.UserName) && u.Password.Equals(user.Password))
                             .Join( _dbCntext.UserRoles, a=> a.Id, b=>b.IdUser,(a,b)=> new {User = a, UserRole =b})
                           

                             .Select(s=> new User { 
                                Id   = s.User.Id,
                                EmailAddress = s.User.EmailAddress,
                                GivenName = s.User.GivenName,
                                IdUser = s.User.IdUser,
                                UserName     = s.User.UserName,
                                Surname = s.User.Surname,
                                Rol = _dbCntext.Roles.FirstOrDefault(r=> r.Id == s.UserRole.IdRol).RolName
                             });

                if (existe != null)
                {
                  //  UserResponse ur = new UserResponse { Id = existe.Id, IdUser = existe.IdUser };

                    operationResult.Success = true;
                    operationResult.InfoMensaje = new SystemMessage { Message = "Usuario Valido", TipoMensaje = TipoMensaje.Default };
                    operationResult.SetSuccesObject(existe.FirstOrDefault());
                }
                else
                {

                    operationResult.Success = true;
                    operationResult.InfoMensaje = new SystemMessage { Message = "Usuario Ivalido", TipoMensaje = TipoMensaje.Default };
                    operationResult.SetSuccesObject(null);
                }


            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.InfoMensaje = new SystemMessage { Message = "Error Obtener la Informacion", TipoMensaje = TipoMensaje.Error };

            }

            return operationResult;
        }

    }
}

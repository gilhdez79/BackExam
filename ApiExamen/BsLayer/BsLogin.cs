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

        public OperationResult<Models.UserResponse> GetCUser(User user)
        {
            try
            {
                var existe = _dbCntext.Users.FirstOrDefault(u=>u.IdUser.Equals(user.IdUser) && u.Password.Equals(user.Password));

                if (existe != null)
                {
                    UserResponse ur = new UserResponse { Id = existe.Id, IdUser = existe.IdUser };

                    operationResult.Success = true;
                    operationResult.InfoMensaje = new SystemMessage { Message = "Usuario Valido", TipoMensaje = TipoMensaje.Default };
                    operationResult.SetSuccesObject(ur);
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

using ApiExamen.Data;
using ApiExamen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExamen.BsLayer
{
    public class BsCliente
    {
        private readonly ExamendbContext _dbCntext;
        OperationResult<Data.Cliente> operationResult = new OperationResult<Data.Cliente>();

        public BsCliente(ExamendbContext dbcontext)
        {
            _dbCntext = dbcontext;
        }

        public OperationResult<Data.Cliente> InsetCliente(Data.Cliente cliente)
        {
            try
            {
                var existe = _dbCntext.Clientes.Find(cliente.Id);

                _dbCntext.Clientes.Add(cliente);
                _dbCntext.SaveChanges();

                operationResult.Success = true;
                operationResult.InfoMensaje = new SystemMessage { Message = "Guardado Correctamente", TipoMensaje = TipoMensaje.Default };
                operationResult.SetSuccesObject(null);

            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.InfoMensaje = new SystemMessage { Message = "Error Obtener la Informacion", TipoMensaje = TipoMensaje.Error };

            }

            return operationResult;
        }
        public OperationResult<Data.Cliente> UpdateCliente(Data.Cliente tienda)
        {
            try
            {
                var existe = _dbCntext.Clientes.Find(tienda.Id);

                if (existe != null)
                {
                    existe.Direccion = tienda.Direccion;
                    existe.Apellidos = tienda.Apellidos;
                    existe.Nombre = tienda.Nombre;


                    // _dbCntext.Clientes.Update(cliente);
                    _dbCntext.SaveChanges();

                    operationResult.Success = true;
                    operationResult.InfoMensaje = new SystemMessage { Message = "Guardado Correctamente", TipoMensaje = TipoMensaje.Default };
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
        public OperationResult<Data.Cliente> DeleteCliente(int id)
        {
            try
            {
                var existe = _dbCntext.Clientes.Find(id);

                if (existe != null)
                {

                    _dbCntext.Clientes.Remove(existe);
                    _dbCntext.SaveChanges();

                    operationResult.Success = true;
                    operationResult.InfoMensaje = new SystemMessage { Message = "Guardado Correctamente", TipoMensaje = TipoMensaje.Default };
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

        public OperationResult<Data.Cliente> GetCliente(int id)
        {
            try
            {
                var existe = _dbCntext.Clientes.Find(id);

                if (existe != null)
                {

                    operationResult.Success = true;
                    operationResult.InfoMensaje = new SystemMessage { Message = "Guardado Correctamente", TipoMensaje = TipoMensaje.Default };
                    operationResult.SetSuccesObject(existe);
                }


            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.InfoMensaje = new SystemMessage { Message = "Error Obtener la Informacion", TipoMensaje = TipoMensaje.Error };

            }

            return operationResult;
        }

        public OperationResult<IEnumerable<Data.Cliente>> GetAllCliente()
        {
            OperationResult<IEnumerable<Data.Cliente>> operationResult = new OperationResult<IEnumerable<Data.Cliente>>();

            try
            {
                var existe = _dbCntext.Clientes.AsEnumerable().ToList();

                if (existe != null)
                {

                    operationResult.Success = true;
                    operationResult.InfoMensaje = new SystemMessage { Message = "Guardado Correctamente", TipoMensaje = TipoMensaje.Default };
                    operationResult.SetSuccesObject(existe);
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

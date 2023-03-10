using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiExamen.Data;
using ApiExamen.Models;


namespace ApiExamen.BsLayer
{
    public class BsTienda
    {
        private readonly ExamendbContext _dbCntext;
        OperationResult<Data.Tienda> operationResult = new OperationResult<Data.Tienda>();

        public BsTienda(ExamendbContext dbcontext)
        {
            _dbCntext = dbcontext;
        }

        public OperationResult<Data.Tienda> InsetTienda(Data.Tienda tienda)
        {
            try
            {

                _dbCntext.Tienda.Add(new Tienda2 
                {  
                    Sucursal = tienda.Sucursal,
                    Direccion = tienda.Direccion
                });
                
                
                
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
        public OperationResult<Data.Tienda> UpdateTienda(Data.Tienda tienda)
        {
            try
            {
                var existe = _dbCntext.Tienda.Find(tienda.Id);

                if (existe != null)
                {
                    existe.Direccion = tienda.Direccion;
                    existe.Sucursal = tienda.Sucursal;
                   

                    // _dbCntext.Tiendas.Update(articulo);
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
        public OperationResult<Data.Tienda> DeleteTienda(int id)
        {
            try
            {
                var existe = _dbCntext.Tienda.Find(id);

                if (existe != null)
                {

                    _dbCntext.Tienda.Remove(existe);
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

        public OperationResult<Data.Tienda2> GetTienda(int id)
        {
            OperationResult<Data.Tienda2> operationResult = new OperationResult<Data.Tienda2>();
            try
            {
                var existe = _dbCntext.Tienda.Find(id);

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

        public OperationResult<IEnumerable<Data.Tienda2>> GetAllTienda()
        {
            OperationResult<IEnumerable<Data.Tienda2>> operationResult = new OperationResult<IEnumerable<Data.Tienda2>>();

            try
            {
                var existe = _dbCntext.Tienda.AsEnumerable().ToList();

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

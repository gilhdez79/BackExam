using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiExamen.Data;
using ApiExamen.Models;

namespace ApiExamen.BsLayer
{

    public class BsArticulo
    {
        private readonly ExamendbContext _dbCntext;
        OperationResult<Data.Articulo> operationResult = new OperationResult<Data.Articulo>();

        public BsArticulo(ExamendbContext dbcontext)
        {
            _dbCntext = dbcontext;
        }
        public BsArticulo()
        {

        }
        public OperationResult<Data.Articulo> InsetArticulo(Data.Articulo articulo)
        {
            try
            {
                var existe = _dbCntext.Articulos.Find(articulo.Id);

                _dbCntext.Articulos.Add(articulo);
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
        public OperationResult<Data.Articulo> UpdateArticulo(Data.Articulo articulo)
        {
            try
            {
                var existe = _dbCntext.Articulos.Find(articulo.Id);

                if (existe != null)
                {
                    existe.CodigoCn = articulo.CodigoCn;
                    existe.Descripcion = articulo.Descripcion;
                    existe.Imagen = articulo.Imagen;
                    existe.Precio = articulo.Precio;
                    existe.Stock = articulo.Stock;

                   // _dbCntext.Articulos.Update(articulo);
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
        public OperationResult<Data.Articulo> DeleteArticulo(int id)
        {
            try
            {
                var existe = _dbCntext.Articulos.Find(id);

                if (existe != null)
                {
                    
                    _dbCntext.Articulos.Remove(existe);
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

        public OperationResult<Data.Articulo> GetArticulo(int id)
        {
            try
            {
                var existe = _dbCntext.Articulos.Find(id);

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

        public OperationResult<IEnumerable<Data.Articulo> > GetAllArticulo()
        {
            OperationResult<IEnumerable<Data.Articulo>> operationResult = new OperationResult<IEnumerable<Data.Articulo>>();

            try
            {
                var existe = _dbCntext.Articulos.AsEnumerable().ToList();

                if (existe != null)
                {

                    operationResult.Success = true;
                    operationResult.InfoMensaje = new SystemMessage { Message = "Guardado Correctamente", TipoMensaje = TipoMensaje.Default };
                    operationResult.SetSuccesObject(existe );
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

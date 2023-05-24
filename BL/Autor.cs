using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Autor
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BusquedaLibrosContext contex = new DL.BusquedaLibrosContext())
                {
                    var RowsAfected = contex.Autors.FromSqlRaw("AutorGetAll").ToList();

                    result.Objects = new List<object>();

                    if (contex != null)
                    {
                        foreach (var obj in RowsAfected)
                        {
                            ML.Autor autor = new ML.Autor();

                            autor.IdAutor = (int)obj.IdAutor;
                            autor.Nombre = obj.Nombre;
                            autor.ApellidoPaterno = obj.ApellidoPaterno;
                            autor.ApellidoMaterno = obj.ApellidoMaterno;
                            autor.FechaNacimiento = obj.FechaNacimiento.ToString("dd-MM-yyyy");
                            autor.PaisNacimiento = obj.PaisDeOrigen;
                            autor.NombreCompleto = obj.Nombre + obj.ApellidoPaterno + obj.ApellidoMaterno;

                            result.Objects.Add(autor);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}

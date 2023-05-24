using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {
        public static ML.Result Add(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BusquedaLibrosContext contex = new DL.BusquedaLibrosContext())
                {
                    int RowsAfected = contex.Database.ExecuteSqlRaw($"LibroAdd {libro.Autor.IdAutor}, '{libro.Titulo}', {libro.AñoPublicacion}, {libro.Editorial.IdEditorial}, '{libro.Portada}', '{libro.Sinopsis}'");

                    if (RowsAfected > 0)
                    {
                        result.Correct = true; ;
                    }
                    else
                    {
                        result.Correct = false;
                        Console.WriteLine("Ocurrio un error al ingresar el libro");
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

        public static ML.Result Update(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BusquedaLibrosContext contex = new DL.BusquedaLibrosContext())
                {
                    int RowsAfected = contex.Database.ExecuteSqlRaw($"LibroUpdate  {libro.IdLibro}, {libro.Autor.IdAutor}, '{libro.Titulo}', {libro.AñoPublicacion}, {libro.Editorial.IdEditorial}, '{libro.Portada}', '{libro.Sinopsis}'");

                    if (RowsAfected > 0)
                    {
                        result.Correct = true; ;
                    }
                    else
                    {
                        result.Correct = false;
                        Console.WriteLine("Ocurrio un error al ingresar el libro");
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

        public static ML.Result DeleteForAutor(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BusquedaLibrosContext contex = new DL.BusquedaLibrosContext())
                {
                    int RowsAfected = contex.Database.ExecuteSqlRaw($"LibroDeleteForAutor {libro.Autor.IdAutor}");

                    if (RowsAfected > 0)
                    {
                        result.Correct = true; ;
                    }
                    else
                    {
                        result.Correct = false;
                        Console.WriteLine("Ocurrio un error al ingresar el libro");
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

        public static ML.Result DeleteForEditorial(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BusquedaLibrosContext contex = new DL.BusquedaLibrosContext())
                {
                    int RowsAfected = contex.Database.ExecuteSqlRaw($"LibroDeleteForEditorial {libro.Editorial.IdEditorial}");

                    if (RowsAfected > 0)
                    {
                        result.Correct = true; ;
                    }
                    else
                    {
                        result.Correct = false;
                        Console.WriteLine("Ocurrio un error al ingresar el libro");
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

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BusquedaLibrosContext contex = new DL.BusquedaLibrosContext())
                {
                    var RowsAfected = contex.Libros.FromSqlRaw("LibroGetAll").ToList();

                    result.Objects = new List<object>();

                    if (contex != null)
                    {
                        foreach (var obj in RowsAfected)
                        {
                            ML.Libro libro = new ML.Libro();
                            libro.IdLibro = (int)obj.IdLibro;
                            libro.Autor = new ML.Autor();
                            libro.Autor.IdAutor = (int)obj.IdLibro;
                            libro.Autor.Nombre = obj.Nombre;
                            libro.Autor.ApellidoPaterno = obj.ApellidoPaterno;
                            libro.Autor.ApellidoMaterno = obj.ApellidoMaterno;
                            libro.Titulo = obj.TituloLibro;
                            libro.AñoPublicacion = (int)obj.AñoPublicacion;
                            libro.Editorial = new ML.Editorial();
                            libro.Editorial.IdEditorial = (int)obj.IdEditorial;
                            libro.Editorial.Nombre = obj.Editorial;
                            libro.Portada = obj.Portada;
                            libro.Sinopsis = obj.Sinopsis;

                            result.Objects.Add(libro);
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
        public static ML.Result GetByAutor(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BusquedaLibrosContext contex = new DL.BusquedaLibrosContext())
                {
                    var RowsAfected = contex.Libros.FromSqlRaw($"LibroGetByAutor  {libro.Autor.IdAutor}").ToList();

                    result.Objects = new List<object>();

                    if (contex != null)
                    {
                        foreach (var obj in RowsAfected)
                        {
                            // ML.Libro libro = new ML.Libro();
                            libro.IdLibro = (int)obj.IdLibro;
                            libro.Autor = new ML.Autor();
                            libro.Autor.IdAutor = (int)obj.IdAutor;
                            libro.Autor.Nombre = obj.Nombre;
                            libro.Autor.ApellidoPaterno = obj.ApellidoPaterno;
                            libro.Autor.ApellidoMaterno = obj.ApellidoMaterno;
                            libro.Titulo = obj.TituloLibro;
                            libro.AñoPublicacion = (int)obj.AñoPublicacion;
                            libro.Editorial = new ML.Editorial();
                            libro.Editorial.IdEditorial = (int)obj.IdEditorial;
                            libro.Editorial.Nombre = obj.Editorial;
                            libro.Portada = obj.Portada;
                            libro.Sinopsis = obj.Sinopsis;

                            result.Objects.Add(libro);
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

        public static ML.Result GetByTituloLibre(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BusquedaLibrosContext contex = new DL.BusquedaLibrosContext())
                {
                    var RowsAfected = contex.Libros.FromSqlRaw($"LibroGetByTituloLibro  '{libro.Titulo}'").ToList();
                    result.Objects = new List<object>();

                    if (contex != null)
                    {
                        foreach (var obj in RowsAfected)
                        {
                            // ML.Libro libro = new ML.Libro();
                            libro.IdLibro = (int)obj.IdLibro;
                            libro.Autor = new ML.Autor();
                            libro.Autor.IdAutor = (int)obj.IdAutor;
                            libro.Autor.Nombre = obj.Nombre;
                            libro.Autor.ApellidoPaterno = obj.ApellidoPaterno;
                            libro.Autor.ApellidoMaterno = obj.ApellidoMaterno;
                            libro.Titulo = obj.TituloLibro;
                            libro.AñoPublicacion = (int)obj.AñoPublicacion;
                            libro.Editorial = new ML.Editorial();
                            libro.Editorial.IdEditorial = (int)obj.IdEditorial;
                            libro.Editorial.Nombre = obj.Editorial;
                            libro.Portada = obj.Portada;
                            libro.Sinopsis = obj.Sinopsis;

                            result.Objects.Add(libro);
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

        public static ML.Result GetByAutorAndFechaPublicacion(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BusquedaLibrosContext contex = new DL.BusquedaLibrosContext())
                {
                    var RowsAfected = contex.Libros.FromSqlRaw($"LibroGetByAutorAndFechaPublicacion  {libro.Autor.IdAutor}, '{libro.AñoPublicacion}'").ToList();

                    result.Objects = new List<object>();

                    if (contex != null)
                    {
                        foreach (var obj in RowsAfected)
                        {
                            // ML.Libro libro = new ML.Libro();
                            libro.IdLibro = (int)obj.IdLibro;
                            libro.Autor = new ML.Autor();
                            libro.Autor.IdAutor = (int)obj.IdAutor;
                            libro.Autor.Nombre = obj.Nombre;
                            libro.Autor.ApellidoPaterno = obj.ApellidoPaterno;
                            libro.Autor.ApellidoMaterno = obj.ApellidoMaterno;
                            libro.Titulo = obj.TituloLibro;
                            libro.AñoPublicacion = (int)obj.AñoPublicacion;
                            libro.Editorial = new ML.Editorial();
                            libro.Editorial.IdEditorial = (int)obj.IdEditorial;
                            libro.Editorial.Nombre = obj.Editorial;
                            libro.Portada = obj.Portada;
                            libro.Sinopsis = obj.Sinopsis;

                            result.Objects.Add(libro);
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

        public static ML.Result GetByFechaPublicacion(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BusquedaLibrosContext contex = new DL.BusquedaLibrosContext())
                {
                    var RowsAfected = contex.Libros.FromSqlRaw($"LibroGetByFechaPublicacion  '{libro.AñoPublicacion}'").ToList();

                    result.Objects = new List<object>();

                    if (contex != null)
                    {
                        foreach (var obj in RowsAfected)
                        {
                            // ML.Libro libro = new ML.Libro();
                            libro.IdLibro = (int)obj.IdLibro;
                            libro.Autor = new ML.Autor();
                            libro.Autor.IdAutor = (int)obj.IdAutor;
                            libro.Autor.Nombre = obj.Nombre;
                            libro.Autor.ApellidoPaterno = obj.ApellidoPaterno;
                            libro.Autor.ApellidoMaterno = obj.ApellidoMaterno;
                            libro.Titulo = obj.TituloLibro;
                            libro.AñoPublicacion = (int)obj.AñoPublicacion;
                            libro.Editorial = new ML.Editorial();
                            libro.Editorial.IdEditorial = (int)obj.IdEditorial;
                            libro.Editorial.Nombre = obj.Editorial;
                            libro.Portada = obj.Portada;
                            libro.Sinopsis = obj.Sinopsis;
                            result.Objects.Add(libro);
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

        public static ML.Result Busqueda(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BusquedaLibrosContext context = new DL.BusquedaLibrosContext())
                {
                    var RowsAffected = context.Libros.FromSqlRaw($"LibrosGetAll '{libro.Titulo}', {libro.Autor.IdAutor}, {libro.Editorial.IdEditorial}, {libro.AñoPublicacion}").ToList();
                    result.Objects = new List<object>();

                  
                        foreach (var obj in RowsAffected)
                        {
                           ML.Libro libro1 = new ML.Libro();
                            libro1.IdLibro = (int)obj.IdLibro;
                            libro1.Autor = new ML.Autor();
                            libro1.Autor.IdAutor = (int)obj.IdAutor;
                            libro1.Autor.Nombre = obj.Nombre;
                            libro1.Autor.ApellidoPaterno = obj.ApellidoPaterno;
                            libro1.Autor.ApellidoMaterno = obj.ApellidoMaterno;
                            libro1.Titulo = obj.TituloLibro;
                            libro1.AñoPublicacion = (int)obj.AñoPublicacion;
                            libro1.Editorial = new ML.Editorial();
                            libro1.Editorial.IdEditorial = (int)obj.IdEditorial;
                            libro1.Editorial.Nombre = obj.Editorial;
                            libro1.Portada = obj.Portada;
                            libro1.Sinopsis = obj.Sinopsis;

                            result.Objects.Add(libro1);
                        }
                        result.Correct = true;
                  
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

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
                    int RowsAfected = contex.Database.ExecuteSqlRaw($"LibroAdd {libro.Autor.IdAutor}, '{libro.Titulo}', '{libro.AñoPublicacion}', {libro.Editorial.IdEditorial}, '{libro.Portada}', '{libro.Sinopsis}'");

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
                    int RowsAfected = contex.Database.ExecuteSqlRaw($"LibroUpdate  {libro.IdLibro}, {libro.Autor.IdAutor}, '{libro.Titulo}', '{libro.AñoPublicacion}', {libro.Editorial.IdEditorial}, '{libro.Portada}', '{libro.Sinopsis}'");

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


        public static ML.Result GetByAutor(ML.Libro libro)

        public static ML.Result DeleteForAutor(ML.Libro libro)

        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BusquedaLibrosContext contex = new DL.BusquedaLibrosContext())
                {

                    var RowsAfected = contex.Libros.FromSqlRaw($"LibroGetByAutor  {libro.Autor.IdAutor}").AsEnumerable().FirstOrDefault();

                    result.Object = new object();
                    if (RowsAfected != null)
                    {

                        libro.IdLibro = (int)RowsAfected.IdLibro;
                        libro.Autor = new ML.Autor();
                        libro.Autor.IdAutor = (int)RowsAfected.IdAutor;
                        libro.Autor.Nombre = RowsAfected.IdAutorNavigation.Nombre;
                        libro.Autor.ApellidoPaterno = RowsAfected.IdAutorNavigation.ApellidoPaterno;
                        libro.Autor.ApellidoMaterno = RowsAfected.IdAutorNavigation.ApellidoMaterno;
                        libro.Titulo = RowsAfected.TituloLibro;
                        libro.AñoPublicacion = RowsAfected.AñoPublicacion.ToString("dd-MM-yyyy");
                        libro.Editorial = new ML.Editorial();
                        libro.Editorial.IdEditorial = RowsAfected.IdEditorialNavigation.IdEditorial;
                        libro.Editorial.Nombre = RowsAfected.IdEditorialNavigation.Nombre;
                        libro.Portada = RowsAfected.Portada;
                        libro.Sinopsis = RowsAfected.Sinopsis;

                        result.Object = libro;

                        result.Correct = true;

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

                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla Libros";

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


        public static ML.Result GetByAutorAndFechaPublicacion(ML.Libro libro)


            return result;
        }

        public static ML.Result GetAll()

        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BusquedaLibrosContext contex = new DL.BusquedaLibrosContext())
                {

                    var RowsAfected = contex.Libros.FromSqlRaw($"LibroGetByAutorAndFechaPublicacion  {libro.Autor.IdAutor}, '{libro.AñoPublicacion}'").AsEnumerable().FirstOrDefault();

                    result.Object = new object();
                    if (RowsAfected != null)
                    {

                        libro.IdLibro = (int)RowsAfected.IdLibro;
                        libro.Autor = new ML.Autor();
                        libro.Autor.IdAutor = (int)RowsAfected.IdAutor;
                        libro.Autor.Nombre = RowsAfected.IdAutorNavigation.Nombre;
                        libro.Autor.ApellidoPaterno = RowsAfected.IdAutorNavigation.ApellidoPaterno;
                        libro.Autor.ApellidoMaterno = RowsAfected.IdAutorNavigation.ApellidoMaterno;
                        libro.Titulo = RowsAfected.TituloLibro;
                        libro.AñoPublicacion = RowsAfected.AñoPublicacion.ToString("dd-MM-yyyy");
                        libro.Editorial = new ML.Editorial();
                        libro.Editorial.IdEditorial = RowsAfected.IdEditorialNavigation.IdEditorial;
                        libro.Editorial.Nombre = RowsAfected.IdEditorialNavigation.Nombre;
                        libro.Portada = RowsAfected.Portada;
                        libro.Sinopsis = RowsAfected.Sinopsis;

                        result.Object = libro;


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
                            libro.AñoPublicacion = obj.AñoPublicacion.ToString("dd-MM-yyyy");
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
                            libro.AñoPublicacion = obj.AñoPublicacion.ToString("dd-MM-yyyy");
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

                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla Libros";

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

        public static ML.Result GetByTituloLibre(ML.Libro libro)

        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BusquedaLibrosContext contex = new DL.BusquedaLibrosContext())
                {

                    var RowsAfected = contex.Libros.FromSqlRaw($"LibroGetByFechaPublicacion  '{libro.AñoPublicacion}'").AsEnumerable().FirstOrDefault();

                    result.Object = new object();
                    if (RowsAfected != null)
                    {

                        libro.IdLibro = (int)RowsAfected.IdLibro;
                        libro.Autor = new ML.Autor();
                        libro.Autor.IdAutor = (int)RowsAfected.IdAutor;
                        libro.Autor.Nombre = RowsAfected.IdAutorNavigation.Nombre;
                        libro.Autor.ApellidoPaterno = RowsAfected.IdAutorNavigation.ApellidoPaterno;
                        libro.Autor.ApellidoMaterno = RowsAfected.IdAutorNavigation.ApellidoMaterno;
                        libro.Titulo = RowsAfected.TituloLibro;
                        libro.AñoPublicacion = RowsAfected.AñoPublicacion.ToString("dd-MM-yyyy");
                        libro.Editorial = new ML.Editorial();
                        libro.Editorial.IdEditorial = RowsAfected.IdEditorialNavigation.IdEditorial;
                        libro.Editorial.Nombre = RowsAfected.IdEditorialNavigation.Nombre;
                        libro.Portada = RowsAfected.Portada;
                        libro.Sinopsis = RowsAfected.Sinopsis;

                        result.Object = libro;


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
                            libro.AñoPublicacion = obj.AñoPublicacion.ToString("dd-MM-yyyy");
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

                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla Libros";

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



        public static ML.Result BusquedaAbierta(ML.Libro libro)

        public static ML.Result GetByAutorAndFechaPublicacion(ML.Libro libro)

        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BusquedaLibrosContext contex = new DL.BusquedaLibrosContext())
                {

                    var RowsAfected = contex.Libros.FromSqlRaw($"LibrosGetAll '{libro.Titulo}','{libro.Autor.IdAutor}','{libro.Editorial.IdEditorial}','{libro.AñoPublicacion}'");

                    result.Objects = new List<object>();
                    if (RowsAfected != null)
                    {
                        foreach (var obj in RowsAfected)
                        {

                            libro.IdLibro = (int)obj.IdLibro;
                            libro.Autor = new ML.Autor();
                            libro.Autor.IdAutor = (int)obj.IdAutor;
                            libro.Autor.Nombre = obj.IdAutorNavigation.Nombre;
                            libro.Autor.ApellidoPaterno = obj.IdAutorNavigation.ApellidoPaterno;
                            libro.Autor.ApellidoMaterno = obj.IdAutorNavigation.ApellidoMaterno;
                            libro.Titulo = obj.TituloLibro;
                            libro.AñoPublicacion = obj.AñoPublicacion.ToString("dd-MM-yyyy");
                            libro.Editorial = new ML.Editorial();
                            libro.Editorial.IdEditorial = obj.IdEditorialNavigation.IdEditorial;
                            libro.Editorial.Nombre = obj.IdEditorialNavigation.Nombre;
                            libro.Portada = obj.Portada;
                            libro.Sinopsis = obj.Sinopsis;
                            result.Objects.Add(libro);
                        }




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
                            libro.AñoPublicacion = obj.AñoPublicacion.ToString("dd-MM-yyyy");
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
                            libro.AñoPublicacion = obj.AñoPublicacion.ToString("dd-MM-yyyy");
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

                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla Libros";

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

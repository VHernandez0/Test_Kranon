using Microsoft.AspNetCore.Mvc;

namespace PL_Kranon.Controllers
{
    public class LibroController : Controller
    {

        [HttpGet]
        public IActionResult GetAll()
         {
            ML.Libro libro = new ML.Libro();
            ML.Autor autor = new ML.Autor();
            ML.Editorial editorial = new ML.Editorial();
            libro.Libros = new List<object>();
            autor.Autores = new List<object>();
            editorial.Editoriales = new List<object>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5235/api/");

                var responseTask = client.GetAsync("Autor/GetAll");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {

                        ML.Autor resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Autor>(resultItem.ToString());
                        autor.Autores.Add(resultItemList);
                    }
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al hacer la consulta";
                    return View("Modal");
                }

            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5235/api/");

                var responseTask = client.GetAsync("Editorial/GetAll");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {

                        ML.Editorial resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Editorial>(resultItem.ToString());
                        editorial.Editoriales.Add(resultItemList);
                    }
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al hacer la consulta";
                    return View("Modal");
                }

            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5235/api/");

                 var responseTask = client.GetAsync("Libro/GetAll");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
    
                        ML.Libro resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Libro>(resultItem.ToString());
                        libro.Libros.Add(resultItemList);
                    }
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al hacer la consulta";
                    return View("Modal");
                }
                libro.Autor = new ML.Autor();
                libro.Autor.Autores = autor.Autores;
                libro.Editorial = new ML.Editorial();
                libro.Editorial.Editoriales = editorial.Editoriales;
            }
            return View(libro);
        }

        [HttpPost]
        public IActionResult GetAll(ML.Libro libro)
        {
            
            ML.Autor autor = new ML.Autor();
            ML.Editorial editorial = new ML.Editorial();
            libro.Libros = new List<object>();
            autor.Autores = new List<object>();
            editorial.Editoriales = new List<object>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5235/api/");

                var responseTask = client.GetAsync("Autor/GetAll");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {

                        ML.Autor resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Autor>(resultItem.ToString());
                        autor.Autores.Add(resultItemList);
                    }
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al hacer la consulta";
                    return View("Modal");
                }

            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5235/api/");

                var responseTask = client.GetAsync("Editorial/GetAll");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {

                        ML.Editorial resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Editorial>(resultItem.ToString());
                        editorial.Editoriales.Add(resultItemList);
                    }
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al hacer la consulta";
                    return View("Modal");
                }

            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5235/api/");

                var responseTask = client.PostAsJsonAsync("Libro/GetAll", libro);
                responseTask.Wait();

                var resultUsuario = responseTask.Result;

                if (resultUsuario.IsSuccessStatusCode)
                {
                    var readTask = resultUsuario.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Libro resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Libro>(resultItem.ToString());
                        libro.Libros.Add(resultItemList);
                    }
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al hacer la consulta";
                    return View("Modal");
                }
                libro.Autor = new ML.Autor();
                libro.Autor.Autores = autor.Autores;
                libro.Editorial = new ML.Editorial();
                libro.Editorial.Editoriales = editorial.Editoriales;
            }
            return View(libro);
        }

        [HttpPost]
        public ActionResult Delete(int IdAutor)
        {
            ML.Result resultListProduct = new ML.Result();
            ML.Libro libro = new ML.Libro();

            libro.Autor.IdAutor = IdAutor;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5235/api/");


                var postTask = client.GetAsync("api/Libro/DeleteforAutor" + libro);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Se Elimino con exito";
                    return View("Modal");
                    ;
                }
                else
                {
                    ViewBag.Message = "Error al eliminar";
                    return View("Modal");
                }
            }
        }








        [HttpGet]
        public ActionResult Form(int? idLibro)
        {
            ML.Libro libro = new ML.Libro();
            ML.Autor autor = new ML.Autor();
            ML.Editorial editorial = new ML.Editorial();
            libro.Libros = new List<object>();
            autor.Autores = new List<object>();
            libro.Editorial = new ML.Editorial();
            editorial.Editoriales = new List<object>();
            libro.Autor = new ML.Autor();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5235/api/");

                var responseTask = client.GetAsync("Autor/GetAll");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {

                        ML.Autor resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Autor>(resultItem.ToString());
                        autor.Autores.Add(resultItemList);
                    }
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al hacer la consulta";
                    return View("Modal");
                }

            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5235/api/");

                var responseTask = client.GetAsync("Editorial/GetAll");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {

                        ML.Editorial resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Editorial>(resultItem.ToString());
                        editorial.Editoriales.Add(resultItemList);
                    }
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al hacer la consulta";
                    return View("Modal");
                }

            }


            if (idLibro == null)
            {
                libro.Autor.Autores = autor.Autores;

                libro.Editorial.Editoriales = editorial.Editoriales;
                return View(libro);
            }
            else
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5235/api/");
                    var responseTask = client.GetAsync("Libro/GetbyId/" + idLibro);
                    responseTask.Wait();
                    var resultAPI = responseTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                         libro = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Libro>(readTask.Result.Object.ToString());

                    }
                    
                    libro.Autor.Autores = autor.Autores;
                
                    libro.Editorial.Editoriales = editorial.Editoriales;

                }
               
                return View(libro);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Libro libro)
        {

                IFormFile file = Request.Form.Files["inpImagen"];
                if (file != null)
                {
                    libro.Portada = Convert.ToBase64String(ConvertToBytes(file));

                }
                ML.Result result = new ML.Result();
                //add o update
                if (libro.IdLibro == 0)
                {
                    //add
                    using (var client = new HttpClient())
                    {
                    client.BaseAddress = new Uri("http://localhost:5235/api/");
                    var postTask = client.PostAsJsonAsync<ML.Libro>("Libro/Add", libro);
                        postTask.Wait();

                        var resulUsuario = postTask.Result;
                        if (resulUsuario.IsSuccessStatusCode)
                        {
                            ViewBag.Message = "El Libro se agrego correctamente";

                        }
                        else
                        {
                            ViewBag.Message = "Hubo un error al agregar el libro" + result.ErrorMessage;
                        }
                    }

                }
                else
                {

                    //update
                    using (var client = new HttpClient())
                    {
                    client.BaseAddress = new Uri("http://localhost:5235/api/");
                    var postTask = client.PutAsJsonAsync<ML.Libro>("Libro/Update", libro);
                        postTask.Wait();

                        var resultUpdate = postTask.Result;
                        if (resultUpdate.IsSuccessStatusCode)
                        {
                            ViewBag.Message = "El libro se actualizo correctamente";

                        }
                        else
                        {
                            ViewBag.Message = "Hubo un error al actualizar el libro" + result.ErrorMessage;
                        }

                    }

                }

            return View("Modal");
        }




        public static byte[] ConvertToBytes(IFormFile imagen) //Covierte a bytes la imagen
        {

            using var fileStream = imagen.OpenReadStream();

            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int)fileStream.Length);

            return bytes;
        }

    }
}

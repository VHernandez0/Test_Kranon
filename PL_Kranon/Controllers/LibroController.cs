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

        //[HttpGet]
        //public IActionResult GetAll(ML.Libro libro)
        //{
            
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:5201/Api/");

        //        var responseTask = client.PostAsJsonAsync("Usuario/GetAll", libro);
        //        responseTask.Wait();

        //        var resultUsuario = responseTask.Result;

        //        if (resultUsuario.IsSuccessStatusCode)
        //        {
        //            var readTask = resultUsuario.Content.ReadAsAsync<ML.Result>();
        //            readTask.Wait();

        //            foreach (var resultItem in readTask.Result.Objects)
        //            {
        //                ML.Libro resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Libro>(resultItem.ToString());
        //                libro.Libros.Add(resultItemList);
        //            }
        //        }
        //        else
        //        {
        //            ViewBag.Message = "Ocurrio un error al hacer la consulta";
        //            return View("Modal");
        //        }

        //    }
        //    return View(libro);
        //}
    }
}

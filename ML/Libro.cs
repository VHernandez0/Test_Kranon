﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public int Año_Publicacion { get; set; }
        public ML.Editorial Editorial { get; set; }
        public ML.Autor Autor { get; set; }

    }
}
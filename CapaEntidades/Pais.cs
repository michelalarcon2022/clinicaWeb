﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Pais
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Ciudad> Ciudades { get; set; }

    }
}

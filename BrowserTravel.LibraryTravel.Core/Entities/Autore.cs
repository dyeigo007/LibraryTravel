﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BrowserTravel.LibraryTravel.Core.Entities
{
    public partial class Autore
    {
        public Autore()
        {
            AutoresHasLibros = new HashSet<AutoresHasLibro>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        public virtual ICollection<AutoresHasLibro> AutoresHasLibros { get; set; }
    }
}

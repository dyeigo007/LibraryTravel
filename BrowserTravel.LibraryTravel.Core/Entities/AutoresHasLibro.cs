using System;
using System.Collections.Generic;

#nullable disable

namespace BrowserTravel.LibraryTravel.Core.Entities
{
    public partial class AutoresHasLibro
    {
        public int Id { get; set; }
        public int IdAutores { get; set; }
        public int IdLibro { get; set; }

        public virtual Autore IdAutoresNavigation { get; set; }
        public virtual Libro IdLibroNavigation { get; set; }
    }
}

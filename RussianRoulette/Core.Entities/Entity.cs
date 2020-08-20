//   -----------------------------------------------------------------------
//   <copyright file=Entity.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 12:11</Date>
//   <Update> 2020-08-20 - 12:11</Update>
//   -----------------------------------------------------------------------

using System;

namespace Core.Entities
{
    public abstract class Entity
    {

        public Guid Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public StatusType Status { get; set; }


    }
}
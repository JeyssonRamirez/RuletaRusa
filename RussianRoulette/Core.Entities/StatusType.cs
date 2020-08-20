//   -----------------------------------------------------------------------
//   <copyright file=StatusType.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 11:43</Date>
//   <Update> 2020-08-20 - 12:11</Update>
//   -----------------------------------------------------------------------

namespace Core.Entities
{
    public enum StatusType
    {
        Active = 0,

        Pending = 1,

        Inactive = 2,

        Locked = 3,

        Deleted = 4,

        Other = 5
    }
}
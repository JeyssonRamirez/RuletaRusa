//   -----------------------------------------------------------------------
//   <copyright file=RequestBodyType.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 11:46</Date>
//   <Update> 2020-08-20 - 11:46</Update>
//   -----------------------------------------------------------------------

namespace Crosscutting.Util
{
    public enum RequestBodyType
    {
        None = 1,
        FormData = 2,
        xWWWFormUrlEncode = 3,
        Raw = 4,
        Binary = 5,
        GraphQL = 6
    }
}
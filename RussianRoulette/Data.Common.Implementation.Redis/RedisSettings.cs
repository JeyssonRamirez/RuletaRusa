//   -----------------------------------------------------------------------
//   <copyright file=RedisSettings.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 18:35</Date>
//   <Update> 2020-08-20 - 18:35</Update>
//   -----------------------------------------------------------------------

namespace Data.Common.Implementation.Redis
{
    public class RedisSettings
    {
        public string Server { get; set; }
        public string Password { get; set; }
        public bool Ssl { get; set; }
        public int Port { get; set; }
    }
}
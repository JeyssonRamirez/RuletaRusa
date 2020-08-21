//   -----------------------------------------------------------------------
//   <copyright file=DSParameter.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 11:46</Date>
//   <Update> 2020-08-20 - 11:46</Update>
//   -----------------------------------------------------------------------

namespace Crosscutting.Util
{
    public class DSParameter
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the value.
        /// </summary>
        public string Value { get; set; }

        public bool Output { get; set; }

        public bool Send { get; set; }


        #endregion
    }
}
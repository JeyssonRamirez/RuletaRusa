//   -----------------------------------------------------------------------
//   <copyright file=OpenRouletteResult.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 20:49</Date>
//   <Update> 2020-08-20 - 20:49</Update>
//   -----------------------------------------------------------------------

namespace Core.DataTransferObject
{
    public class OpenRouletteResult : BaseApiResult
    {
        public new bool Data { set; get; }
    }
    public class DeleteRouletteResult : BaseApiResult
    {
        public new bool Data { set; get; }
    }
}
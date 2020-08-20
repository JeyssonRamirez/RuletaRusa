//   -----------------------------------------------------------------------
//   <copyright file=Bet.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 17:09</Date>
//   <Update> 2020-08-20 - 17:09</Update>
//   -----------------------------------------------------------------------

namespace Core.Entities
{
    public class Bet :Entity
    {
        private long RouletteId { get; set; }
        public long UserId { get; set; }
        public ColorType Color { get; set; }
        public int Number { get; set; }
        public decimal Amount { get; set; }
    }
}
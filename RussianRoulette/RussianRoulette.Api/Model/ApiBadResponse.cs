using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RussianRoulette.Api.Model
{
    public class ApiBadResponse : BaseApiResponse
    {
    
        public virtual object Data { get; set; }
        public object DetailException { get; set; }
    }

   
}

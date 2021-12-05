using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/valuesHamda")]
    [ApiController]
    public class ValuesHamda
    {
        public string Get()
        {
            throw new Exception("Error");
            return "Hello";
        }
    }
}

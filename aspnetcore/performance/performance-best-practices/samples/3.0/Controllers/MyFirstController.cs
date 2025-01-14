﻿using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace performance_best_practices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    #region snippet1
    public class BadStreamReaderController : Controller
    {
        [HttpGet("/contoso")]
        public ActionResult<ContosoData> Get()
        {           
            var json = new StreamReader(Request.Body).ReadToEnd();

            return JsonSerializer.Deserialize<ContosoData>(json);
        }
    }
    #endregion

    #region snippet2
    public class GoodStreamReaderController : Controller
    {
        [HttpGet("/contoso")]
        public async Task<ActionResult<ContosoData>> Get()
        {
            return await JsonSerializer.DeserializeAsync<ContosoData>(Request.Body);
        }

    }
    #endregion
    public class ContosoData
    {
    }
}


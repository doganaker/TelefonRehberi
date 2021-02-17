using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rapor.API.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapor.API.Controllers
{
    [ApiController]
    public class RaporController : Controller
    {
        private readonly RaporContext _raporContext;
        private ConsumerConfig _config;

        public RaporController(RaporContext raporContext, ConsumerConfig config)
        {
            _raporContext = raporContext;
            this._config = config;
        }

        //public int KisiAmount()
        //{
        //    return 32;
        //}

        [Route("kisial")]
        [HttpGet]
        public IActionResult GetKisi()
        {
            using (var consumer = new ConsumerBuilder<Null, string>(_config).Build())
            {
                consumer.Subscribe("temp-topic");
                while (true)
                {
                    var cr = consumer.Consume();
                    var msg = cr.Message.Value;
                    return Ok(msg);
                }
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Rehber.API.Models.ORM.Context;
using Rehber.API.Models.ORM.Entities;
using Rehber.API.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rehber.API.Controllers
{
    [ApiController]
    public class IletisimBilgisiController : Controller
    {
        private readonly RehberContext _rehberContext;

        public IletisimBilgisiController(RehberContext rehberContext)
        {
            _rehberContext = rehberContext;
        }

        [Route("IletisimBilgisi/Add")]
        [HttpPost]
        public IActionResult AddIletisimBilgisi([FromForm] IletisimBilgisiAddVM model)
        {
            if (ModelState.IsValid)
            {
                IletisimBilgisi iletisim = new IletisimBilgisi();
                iletisim.KisiID = model.KisiId;
                iletisim.Phone = model.phone;
                iletisim.EMail = model.email;
                iletisim.Address = model.address;

                _rehberContext.IletisimBilgisis.Add(iletisim);
                _rehberContext.SaveChanges();

                model.id = iletisim.ID;

                return Ok(model);
            }
            else
            {
                return BadRequest(ModelState.Values);
            }
        }
    }
}

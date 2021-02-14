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
    public class KisiController : Controller
    {
        private readonly RehberContext _rehberContext;

        public KisiController(RehberContext rehberContext)
        {
            _rehberContext = rehberContext;
        }

        [Route("kisilistesi")]
        [HttpGet]
        public List<KisiListVM> GetKisiList()
        {
            var kisiler = _rehberContext.Kisis.Where(q => q.IsDeleted == false).Select(q => new KisiListVM()
            {
                ID = q.ID,
                name = q.Name,
                surname = q.Surname,
                company = q.Company,
                //IletisimList = q.IletisimList
            }).ToList();

            return kisiler;
        }

        [Route("Kisi/Add")]
        [HttpPost]
        public IActionResult AddKisi([FromForm] KisiAddVM model)
        {
            if (ModelState.IsValid)
            {
                Kisi kisi = new Kisi();
                kisi.Name = model.name;
                kisi.Surname = model.surname;
                kisi.Company = model.company;

                _rehberContext.Kisis.Add(kisi);
                _rehberContext.SaveChanges();

                model.id = kisi.ID;

                return Ok(model);
            }
            else
            {
                return BadRequest(ModelState.Values);
            }
        }
    }
}

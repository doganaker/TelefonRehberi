using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            }).ToList();

            return kisiler;
        }

        [Route("kisidetay/{id}")]
        [HttpGet]
        public KisiDetailVM GetDetail(int id)
        {
            Kisi kisi = _rehberContext.Kisis.Find(id);

            if(kisi != null)
            {
                var detail = _rehberContext.Kisis.Where(q => q.IsDeleted == false).Select(q => new KisiDetailVM()
                {
                    id = q.ID,
                    name = q.Name,
                    surname = q.Surname,
                    company = q.Company,
                    iletisimList = _rehberContext.IletisimBilgisis.Where(q => q.IsDeleted == false && q.KisiID == id).Select(q => new IletisimBilgisiDetailVM()
                    {
                        phone = q.Phone,
                        email = q.EMail,
                        address = q.Address
                    }).ToList()
                }).FirstOrDefault(x => x.id == id);

                return detail;
            }
            else
            {
                return null;
            }
            
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

        [Route("Kisi/Delete")]
        [HttpPost]
        public IActionResult DeleteKisi([FromForm] KisiDeleteVM model)
        {
            var kisi = _rehberContext.Kisis.Find(model.KisiId);

            if(kisi != null)
            {
                kisi.IsDeleted = true;
                
                //_rehberContext.Remove(kisi); if data should be erased from database permanently.
                
                _rehberContext.SaveChanges();


                return Ok(kisi);
            }
            else
            {
                return BadRequest("Aradığınız kişi bulunamadı :(");
            }
        }
    }
}

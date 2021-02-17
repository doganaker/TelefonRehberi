using NUnit.Framework;
using Rehber.API.Controllers;
using Rehber.API.Models.ORM.Context;
using Rehber.API.Models.VM;
using System;
using System.Collections.Generic;
using System.Text;

namespace TelefonRehberi.Test.RehberAPI.ControllersTest
{
    class IletisimBilgisiControllerTests
    {
        [Test]
        public void AddIletisimBilgisiTest()
        {
            RehberContext _rehberContext = new RehberContext();
            IletisimBilgisiController ıletisimBilgisi = new IletisimBilgisiController(_rehberContext);

            IletisimBilgisiAddVM model = new IletisimBilgisiAddVM();

            var result = ıletisimBilgisi.AddIletisimBilgisi(model);

            Assert.IsNotNull(result);
        }
    }
}

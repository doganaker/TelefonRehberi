using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Rehber.API.Controllers;
using Rehber.API.Models.ORM.Context;

namespace TelefonRehberi.Test.RehberAPI.ControllersTest
{
    class KisiControllerTests
    {
        [Test]
        public void GetKisiListTest()
        {
            RehberContext _rehberContext = new RehberContext();
            KisiController kisiController = new KisiController(_rehberContext);
            var result = kisiController.GetKisiList();

            Assert.IsTrue(result.Count > 0);
        }

        [Test]
        public void GetDetailTest()
        {

            RehberContext _rehberContext = new RehberContext();
            KisiController kisiController = new KisiController(_rehberContext);

            var result = kisiController.GetDetail(4);

            Assert.IsNotNull(result);

        }
    }
}

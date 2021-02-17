using System;
using System.Collections.Generic;
using System.Text;
using Confluent.Kafka;
using NUnit.Framework;
using Rehber.API.Controllers;
using Rehber.API.Models.ORM.Context;
using Rehber.API.Models.VM;

namespace TelefonRehberi.Test.RehberAPI.ControllersTest
{
    class KisiControllerTests
    {
        [Test]
        public void GetKisiListTest()
        {
            RehberContext _rehberContext = new RehberContext();
            ProducerConfig _config = new ProducerConfig();
            KisiController kisiController = new KisiController(_rehberContext,_config);
            var result = kisiController.GetKisiList();

            Assert.IsTrue(result.Count > 0);
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetDetailTest()
        {
            RehberContext _rehberContext = new RehberContext();
            ProducerConfig _config = new ProducerConfig();
            KisiController kisiController = new KisiController(_rehberContext,_config);

            var result = kisiController.GetDetail(4);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.iletisimList);
        }

        [Test]
        public void AddKisiTest()
        {
            RehberContext _rehberContext = new RehberContext();
            ProducerConfig _config = new ProducerConfig();
            KisiController kisiController = new KisiController(_rehberContext, _config);

            KisiAddVM model = new KisiAddVM();

            var result = kisiController.AddKisi(model);

            Assert.IsNotNull(result);
            Assert.IsNotNull(model.id, model.name, model.surname, model.company);
        }

        [Test]
        public void DeleteKisiTest()
        {
            RehberContext _rehberContext = new RehberContext();
            ProducerConfig _config = new ProducerConfig();
            KisiController kisiController = new KisiController(_rehberContext, _config);

            KisiDeleteVM model = new KisiDeleteVM();

            var result = kisiController.DeleteKisi(model);

            Assert.IsNotNull(result);
            Assert.IsNotNull(model);
        }
    }
}

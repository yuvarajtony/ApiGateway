using Physician_BussinessLogic;
using PAE = FluentAPI.Entities;
using Models;

namespace PhysicianAvailability_Testing_Mapper
{
    [TestFixture]
    public class Tests
    {
        // entity to model

        [Test]
        public void Test1()
        {
            PAE.PhysicianAvailablity physician = new PAE.PhysicianAvailablity();
            var model = Mapper.PhyMap(physician);
            Assert.AreEqual(model.GetType(), typeof(Physicianavailability));
        }

        // model to entity

        [Test]
        public void Test2()
        {
            Physicianavailability physician = new Physicianavailability();
            var model = Mapper.PhyMap(physician);
            Assert.AreEqual(model.GetType(), typeof(PAE.PhysicianAvailablity));
        }
    }
}
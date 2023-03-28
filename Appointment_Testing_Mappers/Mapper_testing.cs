using Appointment_BusinessLogic;
using Appointment_Models;
using AE = FluentApi.Entities;


namespace Appointment_Testing_Mappers
{
    [TestFixture]
    public class Tests
    {

        // entity to model tasting
        [Test]
        public void Test1()
        {
            AE.Appointment appointment = new AE.Appointment();
            var model = Mapper.Map(appointment);
            Assert.AreEqual(model.GetType(), typeof(Appointment));
        }

        // model to entity tasting
        [Test]
        public void Test2()
        {
            Appointment appointment = new Appointment();
            var entity = Mapper.Map(appointment);
            Assert.AreEqual(entity.GetType(), typeof(AE.Appointment));
        }
    }
}
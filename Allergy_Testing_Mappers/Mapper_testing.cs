using Allergy_Business_Logic;
using Models;
using AE = EntityApi.Entities;


namespace Testing_Mappers
{
    [TestFixture]
    public class Tests
    {

        Mapper map = new Mapper();

        // Entity to model testing for allergy

        [Test]
        public void testAllergy_1()
        {
            AE.Allergy allergy = new AE.Allergy();
            var model = map.Map(allergy);
            Assert.AreEqual(model.GetType(), typeof(Allergy));
        }

        // Model Entity to testing for allergy
        [Test]
        public void tastAllergy_2()
        {
            Allergy allergy = new Allergy();
            var entity = map.Map(allergy);
            Assert.AreEqual(entity.GetType(), typeof(AE.Allergy));
        }


    }
}
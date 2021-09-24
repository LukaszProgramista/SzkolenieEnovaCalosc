using NUnit.Framework;
using Soneta.Test;
using Soneta.Types;

namespace Soneta.Szkolenie.Tests
{
    internal class LotyTests1 : DbTransactionTestBase
    {
        public override void ClassSetup()
        {
            LoadAssembly("Soneta.Szkolenie");
            base.ClassSetup();
        }

        [Test]
        public void NowyLotTest()
        {
            Lot lot = null;

            lot = Add(new Lot());

            InUITransaction(() => lot.KodUslugi = "NL");
            InUITransaction(() => lot.Nazwa = "Nowy Lot");
            InUITransaction(() => lot.LokalizacjaMiejscowosc = "Warszawa");
            InUITransaction(() => lot.Cena = new Currency(3000d));

            SaveDispose();

            lot = Get(lot);

            Assert.AreEqual("NL", lot.KodUslugi, "�le podstawiony kod us�ugi");
            Assert.AreEqual("Nowy Lot", lot.Nazwa, "�le podstawiona nazwa");
            Assert.AreEqual("Warszawa", lot.LokalizacjaMiejscowosc, "�le podstawiona miejscowo��");
            Assert.AreEqual(new Currency(3000d), lot.Cena, "�le podstawiona cena");
        }
    }
}

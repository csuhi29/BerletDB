// <copyright file="LogicTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PassRegister.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Moq;
    using NUnit.Framework;
    using PassRegister.Data;
    using PassRegister.Logic;
    using PassRegister.Repository;

    /// <summary>
    /// Test class for Logic class.
    /// </summary>
    [TestFixture]
    public class LogicTest
    {
        private List<BERLET> Passes { get; set; }

        private List<DOLGOZO> Workers { get; set; }

        private List<CEG> Companies { get; set; }

        private List<VASARLAS> Sales { get; set; }

        private Mock<IRepository<DOLGOZO>> DolgozoMoq { get; set; }

        private Mock<IRepository<BERLET>> BerletMoq { get; set; }

        private Mock<IRepository<CEG>> CegMoq { get; set; }

        private Mock<IRepository<VASARLAS>> VasarlasMoq { get; set; }

        private Logic LogicTester { get; set; }

        /// <summary>
        /// Setup method for all tests.
        /// </summary>
        [SetUp]
        public void BIGSetup()
        {
            this.Sales = new List<VASARLAS>()
            {
                new VASARLAS { VASARLAS_ID = 111, BERLET_ID = 1, DOLGOZO_ID = 10, BERLET_MEGNEVEZES = "proba2", ERVENYESSEG_KEZDETE = DateTime.Parse("2011.05.14."), IGAZOLVANY_SZAM = 19212 },
                new VASARLAS { VASARLAS_ID = 222, BERLET_ID = 3, DOLGOZO_ID = 20, BERLET_MEGNEVEZES = "proba3", ERVENYESSEG_KEZDETE = DateTime.Parse("2012.02.19."), IGAZOLVANY_SZAM = 19323 },
                new VASARLAS { VASARLAS_ID = 333, BERLET_ID = 4, DOLGOZO_ID = 40, BERLET_MEGNEVEZES = "proba4", ERVENYESSEG_KEZDETE = DateTime.Parse("2001.12.22."), IGAZOLVANY_SZAM = 19652 }
            };

            this.VasarlasMoq = new Mock<IRepository<VASARLAS>>();
            this.VasarlasMoq.Setup(
                x => x.Read()).Returns(this.Sales);
            this.VasarlasMoq.Setup(
                x => x.Add(It.IsAny<VASARLAS>())).Callback((VASARLAS vasarlas) => this.Sales.Add(vasarlas));
            this.VasarlasMoq.Setup(
                x => x.Delete(It.IsAny<VASARLAS>())).Callback((VASARLAS vasarlas) => this.Sales.Remove(vasarlas));

            this.Companies = new List<CEG>()
            {
                new CEG { CEG_ID = 11, ADOSZAM = 111111, CEGNEV = "ELso Ceg", ALAPITAS_DATUMA = DateTime.Parse("1991.08.24."), JEGYZETT_TOKE = 400000, SZEKHELY = "Budapest" },
                new CEG { CEG_ID = 12, ADOSZAM = 222222, CEGNEV = "Masodik Ceg", ALAPITAS_DATUMA = DateTime.Parse("1981.04.15."), JEGYZETT_TOKE = 3000, SZEKHELY = "Budapest" },
                new CEG { CEG_ID = 13, ADOSZAM = 333333, CEGNEV = "Harmadik Ceg", ALAPITAS_DATUMA = DateTime.Parse("1971.05.13."), JEGYZETT_TOKE = 500000, SZEKHELY = "Budapest" }
            };

            this.CegMoq = new Mock<IRepository<CEG>>();
            this.CegMoq.Setup(
                x => x.Read()).Returns(this.Companies);
            this.CegMoq.Setup(
                x => x.Add(It.IsAny<CEG>())).Callback((CEG ceg) => this.Companies.Add(ceg));
            this.CegMoq.Setup(
                x => x.Delete(It.IsAny<CEG>())).Callback((CEG ceg) => this.Companies.Remove(ceg));

            this.Workers = new List<DOLGOZO>()
            {
                new DOLGOZO { DOLGOZO_ID = 10, CEG_ID = 11, NEM = "f", NEV = "Elso Elemer", SZULETESI_EV = 1980, SZULETESI_HELY = "Bukarest", IGAZOLVANY_SZAM = 19212 },
                new DOLGOZO { DOLGOZO_ID = 20, CEG_ID = 13, NEM = "l", NEV = "Masodik Marton", SZULETESI_EV = 1990, SZULETESI_HELY = "Prága", IGAZOLVANY_SZAM = 19323 },
                new DOLGOZO { DOLGOZO_ID = 30, CEG_ID = 12, NEM = "f", NEV = "Harmadik Hugó", SZULETESI_EV = 1985, SZULETESI_HELY = "Kistarcsa", IGAZOLVANY_SZAM = 19652 }
            };
            this.DolgozoMoq = new Mock<IRepository<DOLGOZO>>();
            this.DolgozoMoq.Setup(
                x => x.Read()).Returns(this.Workers).Verifiable();
            this.DolgozoMoq.Setup(
                x => x.Add(It.IsAny<DOLGOZO>())).Callback((DOLGOZO dolgozo) => this.Workers.Add(dolgozo)).Verifiable();
            this.DolgozoMoq.Setup(
                x => x.Delete(It.IsAny<DOLGOZO>())).Callback((DOLGOZO dolgozo) => this.Workers.Remove(dolgozo)).Verifiable();

            this.Passes = new List<BERLET>()
            {
                new BERLET { BERLET_ID = 1, MEGNEVEZES = "proba1", AR = 500, KEDVEZMENY_TIPUS = "nincs", ERVENYESSEG_IDO = 1, BERLET_FORMATUM = "elektronikus" },
                new BERLET { BERLET_ID = 2, MEGNEVEZES = "proba2", AR = 600, KEDVEZMENY_TIPUS = "diák", ERVENYESSEG_IDO = 30, BERLET_FORMATUM = "papír/elektronikus" },
                new BERLET { BERLET_ID = 3, MEGNEVEZES = "proba3", AR = 800, KEDVEZMENY_TIPUS = "diák", ERVENYESSEG_IDO = 15, BERLET_FORMATUM = "papír" }
            };

            this.BerletMoq = new Mock<IRepository<BERLET>>();
            this.BerletMoq.Setup(
                x => x.Read()).Returns(this.Passes).Verifiable();
            this.BerletMoq.Setup(
                x => x.Add(It.IsAny<BERLET>())).Callback((BERLET berlet) => this.Passes.Add(berlet)).Verifiable();
            this.BerletMoq.Setup(
                x => x.Delete(It.IsAny<BERLET>())).Callback((BERLET berlet) => this.Passes.Remove(berlet)).Verifiable();
            this.LogicTester = new Logic(this.DolgozoMoq.Object, this.BerletMoq.Object, this.CegMoq.Object, this.VasarlasMoq.Object);
        }

        /// <summary>
        /// Test method for testing Add method of Dolgozo.
        /// </summary>
        [Test]
        public void TestAddDolgozo()
        {
            DOLGOZO dolgozo = new DOLGOZO { DOLGOZO_ID = 40, CEG_ID = 14, NEM = "l", NEV = "Negyedik Norbert", SZULETESI_EV = 1993, SZULETESI_HELY = "Bécs", IGAZOLVANY_SZAM = 15452 };
            int expected = this.Workers.Count + 1;
            this.LogicTester.CreateDolgozo(dolgozo);
            Assert.That(this.LogicTester.ReadDolgozo().Count, Is.EqualTo(expected));
            Assert.That(this.LogicTester.ReadDolgozo().Single(x => x.DOLGOZO_ID == 40), Is.EqualTo(dolgozo));
            this.DolgozoMoq.Verify(x => x.Add(It.IsAny<DOLGOZO>()), Times.Once);
        }

        /// <summary>
        /// Test method for testing Add method of Berlet.
        /// </summary>
        [Test]
        public void TestAddBerlet()
        {
            BERLET berlet = new BERLET { BERLET_ID = 4, MEGNEVEZES = "proba4", AR = 1000, KEDVEZMENY_TIPUS = "nincs", ERVENYESSEG_IDO = 15, BERLET_FORMATUM = "papír" };
            int expected = this.Passes.Count + 1;
            this.LogicTester.CreateBerlet(berlet);
            Assert.That(this.LogicTester.ReadBerlet().Count, Is.EqualTo(expected));
            Assert.That(this.LogicTester.ReadBerlet().Single(x => x.BERLET_ID == 4), Is.EqualTo(berlet));
            this.BerletMoq.Verify(x => x.Add(It.IsAny<BERLET>()), Times.Once);
        }

        /// <summary>
        /// Test method for testing Add method of Ceg.
        /// </summary>
        [Test]
        public void TestAddCeg()
        {
            CEG ceg = new CEG { CEG_ID = 14, ADOSZAM = 444444, CEGNEV = "Negyedik Ceg", ALAPITAS_DATUMA = DateTime.Parse("1941.03.01."), JEGYZETT_TOKE = 600000, SZEKHELY = "Budapest" };
            int expected = this.Companies.Count + 1;
            this.LogicTester.CreateCeg(ceg);
            Assert.That(this.LogicTester.ReadCeg().Count, Is.EqualTo(expected));
            Assert.That(this.LogicTester.ReadCeg().Single(x => x.CEG_ID == 14), Is.EqualTo(ceg));
            this.CegMoq.Verify(x => x.Add(It.IsAny<CEG>()), Times.Once);
        }

        /// <summary>
        /// Test method for testing Add method of Vasarlas.
        /// </summary>
        [Test]
        public void TestAddVasarlas()
        {
            VASARLAS vasarlas = new VASARLAS { VASARLAS_ID = 444, BERLET_ID = 3, DOLGOZO_ID = 30, BERLET_MEGNEVEZES = "proba2", ERVENYESSEG_KEZDETE = DateTime.Parse("2000.05.03."), IGAZOLVANY_SZAM = 15452 };
            int expected = this.Sales.Count + 1;
            this.LogicTester.CreateVasarlas(vasarlas);
            Assert.That(this.LogicTester.ReadVasarlas().Count, Is.EqualTo(expected));
            Assert.That(this.LogicTester.ReadVasarlas().Single(x => x.VASARLAS_ID == 444), Is.EqualTo(vasarlas));
            this.VasarlasMoq.Verify(x => x.Add(It.IsAny<VASARLAS>()), Times.Once);
        }

        /// <summary>
        /// Test method for testing Read method of Dolgozo.
        /// </summary>
        [Test]
        public void TestReadDolgozo()
        {
            var result = this.LogicTester.ReadDolgozo();
            Assert.That(result.Count(), Is.EqualTo(this.Workers.Count()));
            this.DolgozoMoq.Verify(x => x.Read(), Times.Once);
        }

        /// <summary>
        /// Test method for testing Read method of Berlet.
        /// </summary>
        [Test]
        public void TestReadBerlet()
        {
            var result = this.LogicTester.ReadBerlet();
            Assert.That(result.Count(), Is.EqualTo(this.Passes.Count()));
            this.BerletMoq.Verify(x => x.Read(), Times.Once);
        }

        /// <summary>
        /// Test method for testing Read method of Dolgozo.
        /// </summary>
        [Test]
        public void TestReadCeg()
        {
            var result = this.LogicTester.ReadCeg();
            Assert.That(result.Count(), Is.EqualTo(this.Companies.Count()));
            this.CegMoq.Verify(x => x.Read(), Times.Once);
        }

        /// <summary>
        /// Test method for testing Read method of Berlet.
        /// </summary>
        [Test]
        public void TestReadVasarlas()
        {
            var result = this.LogicTester.ReadVasarlas();
            Assert.That(result.Count(), Is.EqualTo(this.Sales.Count()));
            this.VasarlasMoq.Verify(x => x.Read(), Times.Once);
        }

        /// <summary>
        /// Testing method for Modify Dolgozo.
        /// </summary>
        [Test]
        public void TestModifyDolgozo()
        {
            DOLGOZO d = this.Workers.Single(x => x.DOLGOZO_ID == 10);
            this.LogicTester.UpdateDolgozo(d);
            d.DOLGOZO_ID = 10;
            d.CEG_ID = 11;
            d.NEV = "Uj";
            d.NEM = "f";
            d.SZULETESI_EV = 1980;
            d.SZULETESI_HELY = "Bukarest";
            d.IGAZOLVANY_SZAM = 19212;
            Assert.That(this.LogicTester.ReadDolgozo().Single(x => x.DOLGOZO_ID == 10).NEV, Is.EqualTo("Uj"));
            this.DolgozoMoq.Verify(x => x.Read(), Times.Once);
            this.DolgozoMoq.Verify(x => x.Modify(10, d), Times.Once);
        }

        /// <summary>
        /// Testing method for Modify Berlet.
        /// </summary>
        [Test]
        public void TestModifyBerlet()
        {
            BERLET b = this.Passes.Single(x => x.BERLET_ID == 1);
            this.LogicTester.UpdateBerlet(b);
            b.BERLET_ID = 1;
            b.MEGNEVEZES = "Ujproba1";
            b.AR = 500;
            b.KEDVEZMENY_TIPUS = "nincs";
            b.ERVENYESSEG_IDO = 1;
            b.BERLET_FORMATUM = "elektronikus";
            Assert.That(this.LogicTester.ReadBerlet().Single(x => x.BERLET_ID == 1).MEGNEVEZES, Is.EqualTo("Ujproba1"));
            this.BerletMoq.Verify(x => x.Read(), Times.Once);
            this.BerletMoq.Verify(x => x.Modify(1, b), Times.Once);
        }

        /// <summary>
        /// Testing method for Modify Ceg.
        /// </summary>
        [Test]
        public void TestModifyCeg()
        {
            CEG c = this.Companies.Single(x => x.CEG_ID == 11);
            this.LogicTester.UpdateCeg(c);
            c.CEG_ID = 11;
            c.ADOSZAM = 111111;
            c.CEGNEV = "ELso UJ Ceg";
            c.ALAPITAS_DATUMA = DateTime.Parse("1991.08.24.");
            c.JEGYZETT_TOKE = 500000;
            c.SZEKHELY = "Budapest";
            Assert.That(this.LogicTester.ReadCeg().Single(x => x.CEG_ID == 11).JEGYZETT_TOKE, Is.EqualTo(500000));
            this.CegMoq.Verify(x => x.Read(), Times.Once);
            this.CegMoq.Verify(x => x.Modify(11, c), Times.Once);
        }

        /// <summary>
        /// Testing method for Modify Vasarlas.
        /// </summary>
        [Test]
        public void TestModifyVasarlas()
        {
            VASARLAS v = this.Sales.Single(x => x.VASARLAS_ID == 111);
            this.LogicTester.UpdateVasarlas(v);
            v.VASARLAS_ID = 111;
            v.BERLET_ID = 1;
            v.DOLGOZO_ID = 10;
            v.BERLET_MEGNEVEZES = "UJproba2";
            v.ERVENYESSEG_KEZDETE = DateTime.Parse("2011.05.14.");
            v.IGAZOLVANY_SZAM = 19212;
            Assert.That(this.LogicTester.ReadVasarlas().Single(x => x.VASARLAS_ID == 111).BERLET_MEGNEVEZES, Is.EqualTo("UJproba2"));
            this.VasarlasMoq.Verify(x => x.Read(), Times.Once);
            this.VasarlasMoq.Verify(x => x.Modify(111, v), Times.Once);
        }

        /// <summary>
        /// Testing function Delete for Dolgozo.
        /// </summary>
        [Test]
        public void TestDeleteDolgozo()
        {
            DOLGOZO d = this.Workers.Single(x => x.DOLGOZO_ID == 10);
            int expected = this.Workers.Count - 1;
            this.LogicTester.DeleteDolgozo(d);
            Assert.That(this.LogicTester.ReadDolgozo().Count, Is.EqualTo(expected));
            Assert.That(this.LogicTester.ReadDolgozo().Where(x => x.DOLGOZO_ID == 10).Count, Is.EqualTo(0));
            this.DolgozoMoq.Verify(x => x.Read(), Times.Exactly(2));
            this.DolgozoMoq.Verify(x => x.Delete(It.IsAny<DOLGOZO>()), Times.Once);
        }

        /// <summary>
        /// Testing function Delete for Berlet.
        /// </summary>
        [Test]
        public void TestDeleteBerlet()
        {
            BERLET b = this.Passes.Single(x => x.BERLET_ID == 1);
            int expected = this.Workers.Count - 1;
            this.LogicTester.DeleteBerlet(b);
            Assert.That(this.LogicTester.ReadBerlet().Count, Is.EqualTo(expected));
            Assert.That(this.LogicTester.ReadBerlet().Where(x => x.BERLET_ID == 1).Count, Is.EqualTo(0));
            this.BerletMoq.Verify(x => x.Read(), Times.Exactly(2));
            this.BerletMoq.Verify(x => x.Delete(It.IsAny<BERLET>()), Times.Once);
        }

        /// <summary>
        /// Testing function Delete for Ceg.
        /// </summary>
        [Test]
        public void TestDeleteCeg()
        {
            CEG c = this.Companies.Single(x => x.CEG_ID == 11);
            int expected = this.Workers.Count - 1;
            this.LogicTester.DeleteCeg(c);
            Assert.That(this.LogicTester.ReadCeg().Count, Is.EqualTo(expected));
            Assert.That(this.LogicTester.ReadCeg().Where(x => x.CEG_ID == 11).Count, Is.EqualTo(0));
            this.CegMoq.Verify(x => x.Read(), Times.Exactly(2));
            this.CegMoq.Verify(x => x.Delete(It.IsAny<CEG>()), Times.Once);
        }

        /// <summary>
        /// Testing function Delete for Vasarlas.
        /// </summary>
        [Test]
        public void TestDeleteVasarlas()
        {
            VASARLAS v = this.Sales.Single(x => x.VASARLAS_ID == 111);
            int expected = this.Sales.Count - 1;
            this.LogicTester.DeleteVasarlas(v);
            Assert.That(this.LogicTester.ReadVasarlas().Count, Is.EqualTo(expected));
            Assert.That(this.LogicTester.ReadVasarlas().Where(x => x.VASARLAS_ID == 111).Count, Is.EqualTo(0));
            this.VasarlasMoq.Verify(x => x.Read(), Times.Exactly(2));
            this.VasarlasMoq.Verify(x => x.Delete(It.IsAny<VASARLAS>()), Times.Once);
        }

        /// <summary>
        /// This method tests the "AtLeast2" method's run.
        /// </summary>
        [Test]
        public void TestAtLeast2Method()
        {
            var q = from a in this.LogicTester.ReadVasarlas()
                    group a by a.BERLET_MEGNEVEZES into g
                    where g.Count() >= 2
                    select new { Berlet_Megnevezes = g.Key, Eladott_darab = g.Count() };

            Assert.That(this.LogicTester.ReadVasarlas().GroupBy(a => a.BERLET_MEGNEVEZES).Where(g => g.Count() >= 2), Is.EqualTo(q));

            this.VasarlasMoq.Verify(x => x.Read(), Times.Exactly(2));
        }

        /// <summary>
        /// This method tests the GivenName nonCRUD method.
        /// </summary>
        [Test]
        public void TestGivenName()
        {
            var q = from a in this.LogicTester.ReadDolgozo()
                    from b in this.LogicTester.ReadVasarlas()
                    where a.DOLGOZO_ID == b.DOLGOZO_ID && b.BERLET_MEGNEVEZES == "proba2"
                    select new { Berlet_neve = b.BERLET_MEGNEVEZES, Dolgozo_neve = a.NEV };

            Assert.That(this.LogicTester.ReadDolgozo().Join(this.LogicTester.ReadVasarlas(), x => x.DOLGOZO_ID, y => y.DOLGOZO_ID, (x, y) => new { Berlet_neve = y.BERLET_MEGNEVEZES, Dolgozo_neve = x.NEV }).Where(y => y.Berlet_neve == "proba2"), Is.EqualTo(q));
            this.DolgozoMoq.Verify(x => x.Read(), Times.Exactly(2));
            this.VasarlasMoq.Verify(x => x.Read(), Times.Exactly(4));
        }

        /// <summary>
        /// Thismethod tests the NoSale nonCRUD method.
        /// </summary>
        [Test]
        public void TestNoSale()
        {
            var q = from a in this.LogicTester.ReadDolgozo()
                    from b in this.LogicTester.ReadVasarlas()
                    from c in this.LogicTester.ReadBerlet()
                    where a.DOLGOZO_ID == b.DOLGOZO_ID && b.BERLET_ID == c.BERLET_ID && c.KEDVEZMENY_TIPUS == "nincs"
                    select new { Dolgozo_Neve = a.NEV, Szuletesi_Ev = a.SZULETESI_EV, Berlet_Megnevezes = b.BERLET_MEGNEVEZES };

            this.DolgozoMoq.Verify(x => x.Read(), Times.Once);
            this.VasarlasMoq.Verify(x => x.Read(), Times.Never);
            this.BerletMoq.Verify(x => x.Read(), Times.Never);
        }
    }
}

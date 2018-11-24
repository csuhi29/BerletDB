// <copyright file="Logic.cs" company="CsuhajCompany">
// Copyright (c) CsuhajCompany. All rights reserved.
// </copyright>

namespace PassRegister.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using PassRegister.Repository;

    public class Logic : ILogic
    {
        private DolgozoRepository dolgozoRepo;
        private BerletRepository berletRepo;
        private CegRepository cegRepo;
        private VasarlasRepository vasarlasRepo;

        public Logic()
        {
            this.dolgozoRepo = new DolgozoRepository();
            this.berletRepo = new BerletRepository();
            this.cegRepo = new CegRepository();
            this.vasarlasRepo = new VasarlasRepository();
        }

        public void CreateBerlet()
        {
            Console.WriteLine("[BERLET_ID, MEGNEVEZES, AR, ERVENYESSEGI_IDO, KEDVEZMENY_TIPUS, BERLET_FORMATUM]");
            Console.WriteLine("Ebben a sorrendben kérem írja be az adatokat, minden adat után 'enter' leütése szükséges.");
            int id = int.Parse(Console.ReadLine());
            string megn = Console.ReadLine();
            int ar = int.Parse(Console.ReadLine());
            int erv = int.Parse(Console.ReadLine());
            string tipus = Console.ReadLine();
            string formatum = Console.ReadLine();
            this.berletRepo.Add(id, megn, ar, erv, tipus, formatum);
        }

        public void CreateCeg()
        {
            Console.WriteLine("[ceg_id, cegnev, szekhely, adoszam, alapitas_datuma, jegyzett_toke]");
            Console.WriteLine("Ebben a sorrendben kérem írja be az adatokat, minden adat után 'enter' leütése szükséges.");
            int id = int.Parse(Console.ReadLine());
            string nev = Console.ReadLine();
            string szek = Console.ReadLine();
            int ado = int.Parse(Console.ReadLine());
            DateTime alap = DateTime.Parse(Console.ReadLine());
            int toke = int.Parse(Console.ReadLine());
            this.cegRepo.Add(id, nev, szek, ado, alap, toke);
        }

        public void CreateDolgozo()
        {
            Console.WriteLine("dolgozo_id, ceg_id, nev, nem, szuletesi_hely, szuletesi_ev, igazolvany_szam");
            Console.WriteLine("Ebben a sorrendben kérem írja be az adatokat, minden adat után 'enter' leütése szükséges.");
            int id = int.Parse(Console.ReadLine());
            int did = int.Parse(Console.ReadLine());
            string nev = Console.ReadLine();
            string nem = Console.ReadLine();
            string hely = Console.ReadLine();
            int szul = int.Parse(Console.ReadLine());
            int ig = int.Parse(Console.ReadLine());
            this.dolgozoRepo.Add(id, did, nev, nem, hely, szul, ig);
        }

        public void CreateVasarlas()
        {
            Console.WriteLine("vasarlas_id, dolgozo_id, berlet_id, berlet_megnevezes, igazolvany_szam, ervenyesseg_kezdete");
            Console.WriteLine("Ebben a sorrendben kérem írja be az adatokat, minden adat után 'enter' leütése szükséges.");
            int id = int.Parse(Console.ReadLine());
            int id2 = int.Parse(Console.ReadLine());
            int id3 = int.Parse(Console.ReadLine());
            string nev = Console.ReadLine();
            int ig = int.Parse(Console.ReadLine());
            DateTime dt = DateTime.Parse(Console.ReadLine());
            this.vasarlasRepo.Add(id, id2, id3, nev, ig, dt);
        }

        public void DeleteBerlet()
        {
            Console.WriteLine("Törlendő ID-je: ");
            int id = int.Parse(Console.ReadLine());
            this.berletRepo.Delete(id);
        }

        public void DeleteCeg()
        {
            Console.WriteLine("Törlendő ID-je: ");
            int id = int.Parse(Console.ReadLine());
            this.cegRepo.Delete(id);
        }

        public void DeleteDolgozo()
        {
            Console.WriteLine("Törlendő ID-je: ");
            int id = int.Parse(Console.ReadLine());
            this.dolgozoRepo.Delete(id);
        }

        public void DeleteVasarlas()
        {
            Console.WriteLine("Törlendő ID-je: ");
            int id = int.Parse(Console.ReadLine());
            this.vasarlasRepo.Delete(id);
        }

        public void ReadBerlet()
        {
            this.berletRepo.Read();
        }

        public void ReadCeg()
        {
            this.cegRepo.Read();
        }

        public void ReadDolgozo()
        {
            this.dolgozoRepo.Read();
        }

        public void ReadVasarlas()
        {
            this.vasarlasRepo.Read();
        }

        public void UpdateBerlet()
        {
            Console.WriteLine("Adja meg a módosítani kívánt tétel 'ID'-jét:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Adja meg melyik tulajdonságot kívánja módosítani: ");
            string prop = Console.ReadLine();
            this.berletRepo.Modify(id, prop);
        }

        public void UpdateCeg()
        {
            Console.WriteLine("Adja meg a módosítani kívánt tétel 'ID'-jét:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Adja meg melyik tulajdonságot kívánja módosítani: ");
            string prop = Console.ReadLine();
            this.cegRepo.Modify(id, prop);
        }

        public void UpdateDolgozo()
        {
            Console.WriteLine("Adja meg a módosítani kívánt tétel 'ID'-jét:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Adja meg melyik tulajdonságot kívánja módosítani: ");
            string prop = Console.ReadLine();
            this.dolgozoRepo.Modify(id, prop);
        }

        public void UpdateVasarlas()
        {
            Console.WriteLine("Adja meg a módosítani kívánt tétel 'ID'-jét:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Adja meg melyik tulajdonságot kívánja módosítani: ");
            string prop = Console.ReadLine();
            this.vasarlasRepo.Modify(id, prop);
        }

        public void GivenName()
        {
            throw new NotImplementedException();
        }

        public void NoSale()
        {
            throw new NotImplementedException();
        }

        public void AtLeast2()
        {
            throw new NotImplementedException();
        }
    }
}

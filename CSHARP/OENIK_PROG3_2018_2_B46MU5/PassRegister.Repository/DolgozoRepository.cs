// <copyright file="DolgozoRepository.cs" company="CsuhajCompany">
// Copyright (c) CsuhajCompany. All rights reserved.
// </copyright>

namespace PassRegister.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using PassRegister.Data;

    public class DolgozoRepository : IDolgozoRepository
    {
        private PassRegisterDatabaseEntities entities;

        public DolgozoRepository()
        {
            this.entities = new PassRegisterDatabaseEntities();
        }

        public void Add(int dolgozo_id, int ceg_id, string nev, string nem, string szuletesi_hely, int szuletesi_ev, int igazolvany_szam)
        {
            DOLGOZO dolgozo = new DOLGOZO
            {
                DOLGOZO_ID = dolgozo_id,
                CEG_ID = ceg_id,
                NEV = nev,
                NEM = nem,
                SZULETESI_HELY = szuletesi_hely,
                SZULETESI_EV = szuletesi_ev,
                IGAZOLVANY_SZAM = igazolvany_szam
            };
            this.entities.DOLGOZO.Add(dolgozo);
            this.entities.SaveChanges();
        }

        public void Delete(int id)
        {
            foreach (DOLGOZO d in this.entities.DOLGOZO)
            {
                if (d.DOLGOZO_ID == id)
                {
                    this.entities.DOLGOZO.Remove(d);
                }
            }

            this.entities.SaveChanges();
        }

        public void Modify(int id, string property)
        {
            foreach (DOLGOZO d in this.entities.DOLGOZO)
            {
                if (d.DOLGOZO_ID == id)
                {
                    if (property == "NEV")
                    {
                        d.NEV = Console.ReadLine();
                    }
                    else if (property == "NEM")
                    {
                        d.NEM = Console.ReadLine();
                    }
                    else if (property == "SZULETESI_HELY")
                    {
                        d.SZULETESI_HELY = Console.ReadLine();
                    }
                    else if (property == "SZULETESI_HELY")
                    {
                        d.SZULETESI_EV = int.Parse(Console.ReadLine());
                    }
                    else if (property == "IGAZOLVANY_SZAM")
                    {
                        d.IGAZOLVANY_SZAM = int.Parse(Console.ReadLine());
                    }

                    break;
                }
            }

            this.entities.SaveChanges();
        }

        public void Read()
        {
            foreach (var item in this.entities.DOLGOZO)
            {
                Console.WriteLine(item.DOLGOZO_ID + "\t" + item.CEG_ID + "\t" + item.NEV + "\t" +
                    item.NEM + "\t" + item.SZULETESI_HELY + "\t" + item.SZULETESI_EV + "\t" + item.IGAZOLVANY_SZAM);
            }
        }
    }
}

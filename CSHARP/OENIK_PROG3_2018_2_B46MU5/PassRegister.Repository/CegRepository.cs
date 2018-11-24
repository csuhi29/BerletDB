// <copyright file="CegRepository.cs" company="CsuhajCompany">
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

    public class CegRepository : ICegRepository
    {
        private PassRegisterDatabaseEntities entites;

        public CegRepository()
        {
            this.entites = new PassRegisterDatabaseEntities();
        }

        public void Add(int ceg_id, string cegnev, string szekhely, int adoszam, DateTime alapitas_datuma, int jegyzett_toke)
        {
            CEG c = new CEG
            {
                CEG_ID = ceg_id,
                CEGNEV = cegnev,
                SZEKHELY = szekhely,
                ADOSZAM = adoszam,
                ALAPITAS_DATUMA = alapitas_datuma,
                JEGYZETT_TOKE = jegyzett_toke
            };
            this.entites.CEG.Add(c);
            this.entites.SaveChanges();
        }

        public void Delete(int id)
        {
            foreach (CEG c in this.entites.CEG)
            {
                if (c.CEG_ID == id)
                {
                    this.entites.CEG.Remove(c);
                }
            }

            this.entites.SaveChanges();
        }

        public void Modify(int id, string property)
        {
            foreach (CEG c in this.entites.CEG)
            {
                if (c.CEG_ID == id)
                {
                    if (property == "CEGNEV")
                    {
                        c.CEGNEV = Console.ReadLine();
                    }
                    else if (property == "SZEKHELY")
                    {
                        c.SZEKHELY = Console.ReadLine();
                    }
                    else if (property == "ADOSZAM")
                    {
                        c.ADOSZAM = int.Parse(Console.ReadLine());
                    }
                    else if (property == "ALAPITAS_DATUMA")
                    {
                        c.ALAPITAS_DATUMA = DateTime.Parse(Console.ReadLine());
                    }
                    else if (property == "JEGYZETT_TOKE")
                    {
                        c.JEGYZETT_TOKE = int.Parse(Console.ReadLine());
                    }

                    break;
                }
            }

            this.entites.SaveChanges();
        }

        public void Read()
        {
            foreach (var item in this.entites.CEG)
            {
                Console.WriteLine(item.CEG_ID + "\t" + item.CEGNEV + "\t" + item.SZEKHELY + "\t" +
                    item.ADOSZAM + "\t" + item.ALAPITAS_DATUMA + "\t" + item.JEGYZETT_TOKE);
            }
        }
    }
}

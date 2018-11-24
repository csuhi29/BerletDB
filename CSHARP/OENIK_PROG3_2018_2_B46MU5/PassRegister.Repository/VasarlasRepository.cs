// <copyright file="VasarlasRepository.cs" company="CsuhajCompany">
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

    public class VasarlasRepository : IVasarlasRepository
    {
        private PassRegisterDatabaseEntities entities;

        public VasarlasRepository()
        {
            this.entities = new PassRegisterDatabaseEntities();
        }

        public void Add(int vasarlas_id, int dolgozo_id, int berlet_id, string berlet_megnevezes, int igazolvany_szam, DateTime ervenyesseg_kezdete)
        {
            VASARLAS v = new VASARLAS
            {
                VASARLAS_ID = vasarlas_id,
                DOLGOZO_ID = dolgozo_id,
                BERLET_ID = berlet_id,
                BERLET_MEGNEVEZES = berlet_megnevezes,
                IGAZOLVANY_SZAM = igazolvany_szam,
                ERVENYESSEG_KEZDETE = ervenyesseg_kezdete
            };
            this.entities.VASARLAS.Add(v);
            this.entities.SaveChanges();
        }

        public void Delete(int id)
        {
            foreach (VASARLAS v in this.entities.VASARLAS)
            {
                if (v.VASARLAS_ID == id)
                {
                    this.entities.VASARLAS.Remove(v);
                }
            }

            this.entities.SaveChanges();
        }

        public void Modify(int id, string property)
        {
            foreach (VASARLAS v in this.entities.VASARLAS)
            {
                if (v.VASARLAS_ID == id)
                {
                    if (property == "BERLET_MEGNEVEZESE")
                    {
                        v.BERLET_MEGNEVEZES = Console.ReadLine();
                    }
                    else if (property == "IGAZOLVANY_SZAM")
                    {
                        v.IGAZOLVANY_SZAM = int.Parse(Console.ReadLine());
                    }
                    else if (property == "ERVENYESSEG_KEZDETE")
                    {
                        v.ERVENYESSEG_KEZDETE = DateTime.Parse(Console.ReadLine());
                    }

                    break;
                }
            }

            this.entities.SaveChanges();
        }

        public void Read()
        {
            foreach (var item in this.entities.VASARLAS)
            {
                Console.WriteLine(item.VASARLAS_ID + "\t" + item.DOLGOZO_ID + "\t" + item.BERLET_ID + "\t" +
                    item.BERLET_MEGNEVEZES + "\t" + item.IGAZOLVANY_SZAM + "\t" + item.ERVENYESSEG_KEZDETE);
            }
        }
    }
}

// <copyright file="BerletRepository.cs" company="CsuhajCompany">
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

    public class BerletRepository : IBerletRepository
    {
        private PassRegisterDatabaseEntities entities;

        public BerletRepository()
        {
            this.entities = new PassRegisterDatabaseEntities();
        }

        public void Add(int berlet_id, string megnevezes, int ar, int ervenyessegi_ido, string kedvezmeny_tipus, string berlet_formatum)
        {
            BERLET berlet = new BERLET
            {
                BERLET_ID = berlet_id,
                MEGNEVEZES = megnevezes,
                AR = ar,
                ERVENYESSEG_IDO = ervenyessegi_ido,
                KEDVEZMENY_TIPUS = kedvezmeny_tipus,
                BERLET_FORMATUM = berlet_formatum
            };
            this.entities.BERLET.Add(berlet);
            this.entities.SaveChanges();
        }

        public void Delete(int id)
        {
            foreach (BERLET b in this.entities.BERLET)
            {
                if (b.BERLET_ID == id)
                {
                    this.entities.BERLET.Remove(b);
                }
            }

            this.entities.SaveChanges();
        }

        public void Modify(int id, string property)
        {
            foreach (BERLET b in this.entities.BERLET)
            {
                if (b.BERLET_ID == id)
                {
                    if (property == "MEGNEVEZES")
                    {
                        b.MEGNEVEZES = Console.ReadLine();
                    }
                    else if (property == "AR")
                    {
                        b.AR = int.Parse(Console.ReadLine());
                    }
                    else if (property == "ERVENYESSEGI_IDO")
                    {
                        b.ERVENYESSEG_IDO = int.Parse(Console.ReadLine());
                    }
                    else if (property == "KEDVEZMENY_TIPUS")
                    {
                        b.KEDVEZMENY_TIPUS = Console.ReadLine();
                    }
                    else if (property == "BERLET_FORMATUM")
                    {
                        b.BERLET_FORMATUM = Console.ReadLine();
                    }

                    break;
                }
            }

            this.entities.SaveChanges();
        }

        public void Read()
        {
            foreach (var item in this.entities.BERLET)
            {
                Console.WriteLine(item.BERLET_ID + "\t" + item.MEGNEVEZES + "\t" + item.AR + "\t" +
                    item.ERVENYESSEG_IDO + "\t" + item.KEDVEZMENY_TIPUS + "\t" + item.BERLET_FORMATUM);
            }
        }
    }
}

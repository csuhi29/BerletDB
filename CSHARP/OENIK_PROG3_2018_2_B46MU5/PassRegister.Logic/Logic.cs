// <copyright file="Logic.cs" company="CsuhajCompany">
// Copyright (c) CsuhajCompany. All rights reserved.
// </copyright>

namespace PassRegister.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Script.Serialization;
    using PassRegister.Data;
    using PassRegister.Repository;

    /// <summary>
    /// This class implements all methods of the ILogic interface.
    /// </summary>
    public class Logic : ILogic
    {
        private readonly IRepository<DOLGOZO> dolgozo;
        private readonly IRepository<BERLET> berlet;
        private readonly IRepository<CEG> ceg;
        private readonly IRepository<VASARLAS> vasarlas;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logic"/> class.
        /// </summary>
        public Logic()
        {
            this.ceg = new Repository<CEG>();
            this.dolgozo = new Repository<DOLGOZO>();
            this.vasarlas = new Repository<VASARLAS>();
            this.berlet = new Repository<BERLET>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Logic"/> class.
        /// Constructor for Logic for Mocking.
        /// </summary>
        /// <param name="d">DolgozoInterface for Mock..</param>
        /// <param name="b">BerletInterface for Mock.</param>
        /// <param name="c">CegInterface for Mock.</param>
        /// <param name="v">VasarlasInterface for Mock.</param>
        public Logic(IRepository<DOLGOZO> d, IRepository<BERLET> b, IRepository<CEG> c, IRepository<VASARLAS> v)
        {
            this.dolgozo = d ?? throw new ArgumentNullException(nameof(d));
            this.berlet = b ?? throw new ArgumentNullException(nameof(b));
            this.ceg = c ?? throw new ArgumentNullException(nameof(c));
            this.vasarlas = v ?? throw new ArgumentNullException(nameof(v));
        }

        /// <summary>
        /// Gets a new Berlet with a given name and random parameters.
        /// </summary>
        public async void WebRequest()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("HTTP kérés indítva ...");
                HttpClient client = new HttpClient();
                Console.Write("Adja meg milyen megnevezésű bérletet kíván felvenni: ");
                string megnevezes = Console.ReadLine();
                string response = await client.GetStringAsync("http://localhost:8080/PassRegister.JavaWeb/PassRegisterServlet?berlet=" + megnevezes);
                BERLET b = new JavaScriptSerializer().Deserialize<BERLET>(response);
                Console.WriteLine("Új rendelés: ");
                Console.WriteLine("BERLET_ID   MEGNEVEZES   AR   ERVENYESSEGI_IDO   KEDVEZMENY_TIPUS   BERLET_FORMATUM");
                Console.WriteLine(b.BERLET_ID + " " + b.MEGNEVEZES + " " + b.AR + " " + b.ERVENYESSEG_IDO + " " + b.KEDVEZMENY_TIPUS + " " + b.BERLET_FORMATUM);
                Console.WriteLine("Elmenti? [Y / N]");
                ConsoleKeyInfo k = Console.ReadKey(true);
                switch (k.KeyChar.ToString())
                {
                    case "y":
                        if (!this.berlet.Read().Any(x => x.BERLET_ID == b.BERLET_ID))
                        {
                            this.berlet.Add(b);
                        }
                        else
                        {
                            Console.WriteLine("Már létezik ilyen ID ezért nem lehet elmenteni az újonnan generált bérletet.");
                        }

                        break;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Nem sikerült elindítani a Servletet. Kérem próbálja újbol. Esetleg nem fut a java végpont?");
            }
        }

        /// <inheritdoc/>
        public void CreateBerlet(BERLET b)
        {
            this.berlet.Add(b);
        }

        /// <inheritdoc/>
        public void CreateCeg(CEG c)
        {
            this.ceg.Add(c);
        }

        /// <inheritdoc/>
        public void CreateVasarlas(VASARLAS v)
        {
            this.vasarlas.Add(v);
        }

        /// <inheritdoc/>
        public void DeleteBerlet(BERLET b)
        {
            b = this.berlet.Read().FirstOrDefault(u => u.BERLET_ID == b.BERLET_ID);
            this.berlet.Delete(b);
        }

        /// <inheritdoc/>
        public void DeleteCeg(CEG c)
        {
            c = this.ceg.Read().FirstOrDefault(u => u.CEG_ID == c.CEG_ID);
            this.ceg.Delete(c);
        }

        /// <inheritdoc/>
        public void DeleteDolgozo(DOLGOZO d)
        {
            d = this.dolgozo.Read().FirstOrDefault(u => u.DOLGOZO_ID == d.DOLGOZO_ID);
            this.dolgozo.Delete(d);
        }

        /// <inheritdoc/>
        public void DeleteVasarlas(VASARLAS v)
        {
            v = this.vasarlas.Read().FirstOrDefault(u => u.VASARLAS_ID == v.VASARLAS_ID);
            this.vasarlas.Delete(v);
        }

        /// <inheritdoc/>
        public List<BERLET> ReadBerlet()
        {
            return this.berlet.Read();
        }

        /// <inheritdoc/>
        public List<CEG> ReadCeg()
        {
            return this.ceg.Read();
        }

        /// <inheritdoc/>
        public List<DOLGOZO> ReadDolgozo()
        {
            return this.dolgozo.Read();
        }

        /// <inheritdoc/>
        public List<VASARLAS> ReadVasarlas()
        {
            return this.vasarlas.Read();
        }

        /// <inheritdoc/>
        public void UpdateBerlet(BERLET berlet)
        {
            this.berlet.Modify(berlet.BERLET_ID, berlet);
        }

        /// <inheritdoc/>
        public void UpdateCeg(CEG ceg)
        {
            this.ceg.Modify(ceg.CEG_ID, ceg);
        }

        /// <inheritdoc/>
        public void UpdateDolgozo(DOLGOZO dolgozo)
        {
            this.dolgozo.Modify(dolgozo.DOLGOZO_ID, dolgozo);
        }

        /// <inheritdoc/>
        public void UpdateVasarlas(VASARLAS vasarlas)
        {
            this.vasarlas.Modify(vasarlas.VASARLAS_ID, vasarlas);
        }

        /// <inheritdoc/>
        public void GivenName(string nev)
        {
            var q = from a in this.dolgozo.Read()
                    from b in this.vasarlas.Read()
                    where a.DOLGOZO_ID == b.DOLGOZO_ID && b.BERLET_MEGNEVEZES == nev
                    select new { Berlet_neve = b.BERLET_MEGNEVEZES, Dolgozo_neve = a.NEV };

            foreach (var item in q)
            {
                Console.WriteLine(item);
            }
        }

        /// <inheritdoc/>
        public void NoSale()
        {
            var q = from a in this.dolgozo.Read()
                    from b in this.vasarlas.Read()
                    from c in this.berlet.Read()
                    where a.DOLGOZO_ID == b.DOLGOZO_ID && b.BERLET_ID == c.BERLET_ID && c.KEDVEZMENY_TIPUS == "nincs"
                    select new { Dolgozo_Neve = a.NEV, Szuletesi_Ev = a.SZULETESI_EV, Berlet_Megnevezes = b.BERLET_MEGNEVEZES };

            foreach (var item in q)
            {
                Console.WriteLine(item);
            }
        }

        /// <inheritdoc/>
        public void AtLeast2()
        {
            var q = from a in this.vasarlas.Read()
                    group a by a.BERLET_MEGNEVEZES into g
                    where g.Count() >= 2
                    select new { Berlet_Megnevezes = g.Key, Eladott_darab = g.Count() };

            foreach (var item in q)
            {
                Console.WriteLine(item);
            }
        }

        /// <inheritdoc/>
        public void CreateDolgozo(DOLGOZO d)
        {
            this.dolgozo.Add(d);
        }
    }
}

// <copyright file="Logic.cs" company="CsuhajCompany">
// Copyright (c) CsuhajCompany. All rights reserved.
// </copyright>

namespace PassRegister.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
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
            this.berlet.Delete(b);
        }

        /// <inheritdoc/>
        public void DeleteCeg(CEG c)
        {
            this.ceg.Delete(c);
        }

        /// <inheritdoc/>
        public void DeleteDolgozo(DOLGOZO d)
        {
            this.dolgozo.Delete(d);
        }

        /// <inheritdoc/>
        public void DeleteVasarlas(VASARLAS v)
        {
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

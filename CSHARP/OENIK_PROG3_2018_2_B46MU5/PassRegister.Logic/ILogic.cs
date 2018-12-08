// <copyright file="ILogic.cs" company="CsuhajCompany">
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

    /// <summary>
    /// ILogic interface that represents all CRUSs for all tables thus the notCRUD methods.
    /// </summary>
    public interface ILogic
    {
        /// <summary>
        /// This Logic method use BerletRepository to create new BERLET element.
        /// </summary>
        /// <param name="berlet">Berlet that will be created.</param>
        void CreateBerlet(BERLET berlet);

        /// <summary>
        /// This Logic method use DolgozoRepository to create new DOLGOZO element.
        /// </summary>
        /// <param name="dolgozo">Dolgozo that will be created.</param>
        void CreateDolgozo(DOLGOZO dolgozo);

        /// <summary>
        /// This Logic method use CegRepsoitory to create new CEG element.
        /// </summary>
        /// <param name="ceg">Ceg that will be created.</param>
        void CreateCeg(CEG ceg);

        /// <summary>
        /// This Logic method use VasarlasRepository to create new VASARLAS element.
        /// </summary>
        /// <param name="vasarlas">Vasarlas that will be created.</param>
        void CreateVasarlas(VASARLAS vasarlas);

        /// <summary>
        /// This Logic method use DolgozoRepsitory to List all element in DOLGOZO table.
        /// </summary>
        /// <returns>Return the list of the Dolgozo table.</returns>
        List<DOLGOZO> ReadDolgozo();

        /// <summary>
        /// This Logic method use BerletRepository to List all element in BERLET table.
        /// </summary>
        /// <returns>Returns the list of the Berlet table.</returns>
        List<BERLET> ReadBerlet();

        /// <summary>
        /// This Logic method use CegRepository to List all element in CEG table.
        /// </summary>
        /// <returns>Returns the list of the Ceg table.</returns>
        List<CEG> ReadCeg();

        /// <summary>
        /// This Logic method use VasarlasRepository to List all element in VASARLAS table.
        /// </summary>
        /// <returns>Returns the List of the Vasarlas table.</returns>
        List<VASARLAS> ReadVasarlas();

        /// <summary>
        /// This Logic method use BerletRepository to Update an existing element in BERLET table.
        /// </summary>
        /// <param name="berlet">Berlet object.</param>
        void UpdateBerlet(BERLET berlet);

        /// <summary>
        /// This Logic method use DolgozoRepository to update an existing element in DOLGOZO table.
        /// </summary>
        /// <param name="dolgozo">Dolgozo object.</param>
        void UpdateDolgozo(DOLGOZO dolgozo);

        /// <summary>
        /// This Logic method use CegRepository to update an existing element in CEG table.
        /// </summary>
        /// <param name="ceg">Ceg object.</param>
        void UpdateCeg(CEG ceg);

        /// <summary>
        /// This Logic method use VasarlasRepository to update an existing element in VASARLAS table.
        /// </summary>
        /// <param name="vasarlas">Vasarlas object.</param>
        void UpdateVasarlas(VASARLAS vasarlas);

        /// <summary>
        /// This Logic method use DolgozoRepository to Delete an existing element from DOLGOZO table.
        /// </summary>
        /// <param name="d">Dolgozo object.</param>
        void DeleteDolgozo(DOLGOZO d);

        /// <summary>
        /// This Logic method use BerletRepository to Delete an existing element from BERLET table.
        /// </summary>
        /// <param name="b">Berlet object.</param>
        void DeleteBerlet(BERLET b);

        /// <summary>
        /// This Logic method use CegRepository to Delete an existing element from CEG table.
        /// </summary>
        /// <param name="c">Ceg object.</param>
        void DeleteCeg(CEG c);

        /// <summary>
        /// This Logic method use VasarlasRepository to Delete an existing element from VASARLAS table.
        /// </summary>
        /// <param name="v">Vasarlas object.</param>
        void DeleteVasarlas(VASARLAS v);

        // NEM CRUD

        /// <summary>
        /// This Logic method will return a List containing the DOLGOZO names who bought a pass of the given name.
        /// </summary>
        /// <param name="nev">The name of the pass we are looking for.</param>
        void GivenName(string nev);

        /// <summary>
        /// This Logic method will return a List containing the name of the passes, that was bought at least twice.
        /// </summary>
        void AtLeast2();

        /// <summary>
        /// This Logic method will return a List containing the name and birth year of a DOLGOZO who bought a BERLET without any discount.
        /// </summary>
        void NoSale();
    }
}

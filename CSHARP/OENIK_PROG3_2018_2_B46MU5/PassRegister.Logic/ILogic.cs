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

    public interface ILogic
    {
        void CreateBerlet();

        void CreateDolgozo();

        void CreateCeg();

        void CreateVasarlas();

        void ReadDolgozo();

        void ReadBerlet();

        void ReadCeg();

        void ReadVasarlas();

        void UpdateBerlet();

        void UpdateDolgozo();

        void UpdateCeg();

        void UpdateVasarlas();

        void DeleteDolgozo();

        void DeleteBerlet();

        void DeleteCeg();

        void DeleteVasarlas();

        // NEM CRUD
        void GivenName();

        void AtLeast2();

        void NoSale();
    }
}

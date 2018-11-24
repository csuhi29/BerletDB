// <copyright file="ICegRepository.cs" company="CsuhajCompany">
// Copyright (c) CsuhajCompany. All rights reserved.
// </copyright>

namespace PassRegister.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICegRepository : IRepository
    {
        void Add(int ceg_id, string cegnev, string szekhely, int adoszam, DateTime alapitas_datuma, int jegyzett_toke);
    }
}

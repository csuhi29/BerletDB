// <copyright file="IDolgozoRepository.cs" company="CsuhajCompany">
// Copyright (c) CsuhajCompany. All rights reserved.
// </copyright>

namespace PassRegister.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IDolgozoRepository : IRepository
    {
        void Add(int dolgozo_id, int ceg_id, string nev, string nem, string szuletesi_hely, int szuletesi_ev, int igazolvany_szam);
    }
}

// <copyright file="IVasarlasRepository.cs" company="CsuhajCompany">
// Copyright (c) CsuhajCompany. All rights reserved.
// </copyright>

namespace PassRegister.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IVasarlasRepository : IRepository
    {
        void Add(int vasarlas_id, int dolgozo_id, int berlet_id, string berlet_megnevezes, int igazolvany_szam, DateTime ervenyesseg_kezdete);
    }
}

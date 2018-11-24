// <copyright file="IBerletRepository.cs" company="CsuhajCompany">
// Copyright (c) CsuhajCompany. All rights reserved.
// </copyright>

namespace PassRegister.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IBerletRepository : IRepository
    {
        void Add(int berlet_id, string megnevezes, int ar, int ervenyessegi_ido, string kedvezmeny_tipus, string berlet_formatum);
    }
}

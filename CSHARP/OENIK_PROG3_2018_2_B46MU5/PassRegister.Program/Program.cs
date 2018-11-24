// <copyright file="Program.cs" company="CsuhajCompany">
// Copyright (c) CsuhajCompany. All rights reserved.
// </copyright>

namespace PassRegister.Program
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using PassRegister.Logic;

    public class Program
    {
        public static void Main(string[] args)
        {
            Logic l = new Logic();
            l.ReadBerlet();
        }
    }
}

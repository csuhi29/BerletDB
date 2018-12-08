// <copyright file="IRepository.cs" company="CsuhajCompany">
// Copyright (c) CsuhajCompany. All rights reserved.
// </copyright>

namespace PassRegister.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This is the Main Interface that is given to other Interfaces.
    /// </summary>
    /// <typeparam name="TEntity">This is a reference of the class that will be used.</typeparam>
    public interface IRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// This method will Delete the entity.
        /// </summary>
        /// <param name="entity">Entity of the given type.</param>
        void Delete(TEntity entity);

        /// <summary>
        /// It will modify an item form a table.
        /// </summary>
        /// <param name="id"> The ID of the element we want to Modify.</param>
        /// <param name="property">The name of the parameter of the ID given element.</param>
        void Modify(int id, TEntity property);

        /// <summary>
        /// Returns the elements to a List where TEntity = the Table type.
        /// </summary>
        /// <returns>Returns table elements as a List.</returns>
        List<TEntity> Read();

        /// <summary>
        /// Adda new Entity to the database.
        /// </summary>
        /// <param name="entity">Entity of the given type</param>
        void Add(TEntity entity);
    }
}

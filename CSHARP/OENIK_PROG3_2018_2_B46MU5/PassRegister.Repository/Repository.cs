// <copyright file="Repository.cs" company="CsuhajCompany">
// Copyright (c) CsuhajCompany. All rights reserved.
// </copyright>

namespace PassRegister.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using PassRegister.Data;

    /// <summary>
    /// Repository class that implements IRepository interface.
    /// </summary>
    /// <typeparam name="TEntity">A database class.</typeparam>
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly PassRegisterDatabaseEntities dbe;

        private readonly DbSet<TEntity> entities;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// The constructor of the Repository class.
        /// </summary>
        public Repository()
        {
            this.dbe = new PassRegisterDatabaseEntities();
            this.entities = (DbSet<TEntity>)typeof(PassRegisterDatabaseEntities).GetProperty(typeof(TEntity).Name).GetValue(this.dbe);
        }

        /// <summary>
        /// Adds a new element to the table.
        /// </summary>
        /// <param name="entity">The generic element of a table.</param>
        public void Add(TEntity entity)
        {
            this.entities.Add(entity);
            this.dbe.SaveChanges();
        }

        /// <summary>
        /// Deletes the element from the table.
        /// </summary>
        /// <param name="entity">The generic element of a table.</param>
        public void Delete(TEntity entity)
        {
            if (entity != null)
            {
                this.entities.Remove(entity);
                this.dbe.SaveChanges();
            }
        }

        /// <summary>
        /// Modify the given element from a given table.
        /// </summary>
        /// <param name="id">The key ID of the element.</param>
        /// <param name="property">The element itself.</param>
        public void Modify(int id, TEntity property)
        {
            TEntity temp = this.dbe.Set<TEntity>().Find(id);
            this.dbe.Entry(temp).CurrentValues.SetValues(property);
            this.dbe.SaveChanges();
        }

        /// <summary>
        /// Reads all element from a given Table.
        /// </summary>
        /// <returns>The elements as a list.</returns>
        public List<TEntity> Read()
        {
            return this.entities.ToList();
        }
    }
}

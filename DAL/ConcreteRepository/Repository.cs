﻿using DAL.AbstractRepositories;
using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ConcreteRepository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _entities;

        public Repository(AppDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }
        public async Task<Guid> AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                entity.DeletedDate = DateTime.Now;
                _entities.Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _entities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task UpdateAsync(T entity)
        {

            //entity.CreatedDate = _entities.AsNoTracking().FirstOrDefault(e => e.Id == entity.Id).CreatedDate;

            if (!entity.IsDeleted)
            {

                entity.ModifiedDate = DateTime.Now;
            }

            var existingEntity = _entities.Local.FirstOrDefault(e => e.Id == entity.Id);

            if (existingEntity != null)
            {
                // If the entity is already tracked, update its properties
                _entities.Entry(existingEntity).CurrentValues.SetValues(entity);
            }
            else
            {
                _entities.Update(entity);
            }

            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<T>> GetAllWithIncludes(params string[] includes)
        {
            IQueryable<T> query = _entities;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.Where(x => !x.IsDeleted).ToListAsync();
        }

    }
}

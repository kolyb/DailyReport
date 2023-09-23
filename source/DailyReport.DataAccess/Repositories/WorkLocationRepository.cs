﻿using DailyReport.DataAccess.EntityFrameworkCore;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DailyReport.DataAccess.Repositories
{
    public class WorkLocationRepository : IRepository<WorkLocation>
    {
        private readonly DailyReportContext _db;

        public WorkLocationRepository(DailyReportContext db)
        {
            _db = db;
            _db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task CreateAsync(WorkLocation item)
        {
            _db.WorkLocations.Add(item);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(WorkLocation item)
        {
            _db.WorkLocations.Remove(item);
            await _db.SaveChangesAsync();
        }

        public IEnumerable<WorkLocation> GetAll()
        {
            return _db.WorkLocations.AsQueryable();
        }

        public async Task<WorkLocation> GetByIdAsync(int id)
        {
            var result = await _db.WorkLocations.FindAsync(id);
            if (result == null)
            {
                //
                throw new Exception();
            }
            return result;
        }

        public async Task UpdateAsync(WorkLocation item)
        {
            _db.Entry(item).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
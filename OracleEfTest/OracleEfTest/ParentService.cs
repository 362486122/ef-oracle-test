using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleEfTest
{
    public class ParentService
    {
        private readonly MyDbContext _dbcontext;
        public ParentService(MyDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<List<string>> Get1()
        { 
            var startDate = DateTime.Now;
            var endDate = startDate.AddDays(1);
            return await _dbcontext.Parents.Where(o =>o.C>= startDate && o.C < endDate&&o.A=="1").Select(o=>o.Id).ToListAsync();
        }

        public async Task<List<string>> Get2()
        { 
            return await _dbcontext.Parents.Where(o => o.C >= DateTime.Today.AddDays(1)&& o.A=="1").Select(o => o.Id).ToListAsync();
        }
        public async Task<List<string>> Get3()
        {
           
            var startDate = DateTime.Now;
            var endDate = startDate.AddDays(1);
            return await _dbcontext.Parents.Where(o => o.C >= DateTime.Today && o.C < DateTime.Today.AddDays(1)).Select(o => o.Id).ToListAsync();
        }
    }
}

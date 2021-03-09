using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace MimoBackendChallenge.Database
{
    public class MimoContextFactory : IDesignTimeDbContextFactory<MimoContext>
    {
        public MimoContext CreateDbContext(string[] args)
        {
            var context = new MimoContext(new DbContextOptionsBuilder<MimoContext>().UseSqlite("Data Source=mimo.db").Options);

            return context;
        }
    }
}

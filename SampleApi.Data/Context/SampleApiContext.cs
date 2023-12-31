﻿using Microsoft.EntityFrameworkCore;
using SampleApi.Data.Models.SampleEntity;

namespace SampleApi.Data.Context
{
    public class SampleApiContext : DbContext
    {
        public SampleApiContext(DbContextOptions<SampleApiContext> options)
            : base(options)
        {
        }

        public DbSet<SampleEntity> SampleEntities { get; set; } = null!;
    }
}

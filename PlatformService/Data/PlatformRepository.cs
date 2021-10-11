﻿using PlatformService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlatformService.Data
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly AppDbContext _context;

        public PlatformRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreatePlatform(Platform platform)
        {
            if (platform == null)
                throw new ArgumentNullException(nameof(platform));

            _context.Platforms.Add(platform);
        }

        public IEnumerable<Platform> GetAllPlatforms() => _context.Platforms.ToList();

        public Platform GetPlatformById(int id) => _context.Platforms.FirstOrDefault(p => p.Id == id);

        public bool SaveChanges() => _context.SaveChanges() >= 0;
    }
}
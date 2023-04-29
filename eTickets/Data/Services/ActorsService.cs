﻿using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _context;
        public ActorsService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Actor actor)
        {
           await _context.Actors.AddAsync(actor);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(m => m.Id == id);
             _context.Actors.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task< Actor> UpdateAsync(int id, Actor newactor)
        {
            _context.Update(newactor);
            await _context.SaveChangesAsync();
            return newactor;
        }
    }
}

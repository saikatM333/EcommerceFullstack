using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class PromotionServices : IPromotionServices
    {
       
        
            private readonly EcommerceDBContext _context;

            public PromotionServices(EcommerceDBContext context)
            {
                _context = context;
            }

           
            public async Task<IEnumerable<Promotion>> GetPromotions()
            {
                return await _context.Promotions.ToListAsync();
            }

            
            public async Task<Promotion> GetPromotion(int id)
            {
                var promotion = await _context.Promotions.FindAsync(id);

                if (promotion == null)
                {
                    return null;
                }

                return promotion;
            }

          
            public async Task<Promotion> PostPromotion(Promotion promotion)
            {
                _context.Promotions.Add(promotion);
                await _context.SaveChangesAsync();
                return promotion;
                //return CreatedAtAction("GetPromotion", new { id = promotion.Id }, promotion);
            }

            
            public async Task<Promotion> PutPromotion(int id, Promotion promotion)
            {
                if (id != promotion.Id)
                {
                    return null;
                }

                _context.Entry(promotion).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromotionExists(id))
                    {
                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }

                return promotion;
            }

            
            public async Task<Promotion> DeletePromotion(int id)
            {
                var promotion = await _context.Promotions.FindAsync(id);
                if (promotion == null)
                {
                    return null;
                }

                _context.Promotions.Remove(promotion);
                await _context.SaveChangesAsync();

                return null;
            }

            private bool PromotionExists(int id)
            {
                return _context.Promotions.Any(e => e.Id == id);
            }
        
}
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class ReviewServices : IReviewServices
    {
        
            private readonly EcommerceDBContext _context;

            public ReviewServices(EcommerceDBContext context)
            {
                _context = context;
            }

            
            public async Task<IEnumerable<Review>> GetReviewsByProduct(int productId)
            {
                var reviews = await _context.Reviews
                    .Where(r => r.ProductId == productId)
                    .ToListAsync();

                return reviews;
            }

          
            public async Task<Review> PostReview(int userId, int productId, int rating, string comment)
            {
            Review review = new Review
            {
                ProductId = productId,
                Rating = rating,
                Comment = comment,
                Date = DateTime.Now,
                CustomerId = userId
            };
                _context.Reviews.Add(review);
                await _context.SaveChangesAsync();

            return review;  
            }

        public async Task<double> GetAverageRating(int productId)
        {
            var rating = await _context.Reviews.Where(r => r.ProductId == productId).ToListAsync();
            var avgRating = rating.Average(r => r.Rating);
            return avgRating;
        }
        
    

}
}

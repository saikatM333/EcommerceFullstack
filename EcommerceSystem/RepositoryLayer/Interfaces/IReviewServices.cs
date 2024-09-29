using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IReviewServices
    {
        public Task<IEnumerable<Review>> GetReviewsByProduct(int productId);
        public Task<Review> PostReview(int userId, int productId, int rating, string comment);
        public Task<double> GetAverageRating(int productId);
}
}

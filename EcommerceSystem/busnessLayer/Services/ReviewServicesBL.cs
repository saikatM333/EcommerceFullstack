using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using busnessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busnessLayer.Services
{
    public class ReviewServicesBL : IReviewServicesBL
    {       
            private readonly IReviewServices _reviewServices;

            public ReviewServicesBL(IReviewServices reviewServices)
            {
                _reviewServices = reviewServices;
            }           
            public async Task<IEnumerable<Review>> GetReviewsByProduct(int productId)
            {               
                return await  _reviewServices.GetReviewsByProduct(productId);
            }
         
            public async Task<Review> PostReview(int userId, int productId, int rating, string comment)
            {
            return await _reviewServices.PostReview(userId ,  productId, rating, comment);
            }

            public async Task<double> GetAverageRating(int productId)
        {
            return await _reviewServices.GetAverageRating(productId);
        }
}
}

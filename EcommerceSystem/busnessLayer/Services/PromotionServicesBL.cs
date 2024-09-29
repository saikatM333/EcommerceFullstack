using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Interfaces;
using busnessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer.Entity;

namespace busnessLayer.Services
{
    public class PromotionServicesBL : IPromotionServicesBL
    {       
            private readonly IPromotionServices _promotionServices;

            public PromotionServicesBL(IPromotionServices promotionServices)
            {
                _promotionServices = promotionServices; 
            }         
            public async Task<IEnumerable<Promotion>> GetPromotions()
            {
                return await _promotionServices.GetPromotions();
            }          
            public async Task<Promotion> GetPromotion(int id)
            {
                return await _promotionServices.GetPromotion(id);
            }         
            public async Task<Promotion> PostPromotion(Promotion promotion)
            {
                return await _promotionServices.PostPromotion(promotion);
            }           
            public async Task<Promotion> PutPromotion(int id, Promotion promotion)
            {
               return await _promotionServices.PutPromotion(id, promotion); 
            }           
            public async Task<Promotion> DeletePromotion(int id)
            {
                return await _promotionServices.DeletePromotion(id);  
            }
        
}
}

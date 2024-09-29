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
    public interface IPromotionServices
    {
        public  Task<IEnumerable<Promotion>> GetPromotions();
        public  Task<Promotion> GetPromotion(int id);
        public Task<Promotion> PostPromotion(Promotion promotion);
        public Task<Promotion> PutPromotion(int id, Promotion promotion);
        public  Task<Promotion> DeletePromotion(int id);                      
}
}

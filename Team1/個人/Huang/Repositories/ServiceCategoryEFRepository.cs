using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team1.Models.EFModels;
using Team1.個人.Huang.Entities;
using Team1.個人.Huang.Exts;
using Team1.個人.Huang.Interfaces;

namespace Team1.個人.Huang.Repositories
{
    public class ServiceCategoryEFRepository : IServiceCategoryRepository
    {
        private AppDbContext db = new AppDbContext();
        public void Create(ServiceCategoryEntity entity)
        {
            var model = new ServiceCategory
            {
                Id = entity.Id,
                Name = entity.Name,
            };
            db.ServiceCategories.Add(model);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = db.ServiceCategories.Find(id);

            db.ServiceCategories.Remove(model);
            db.SaveChanges();
        }
        public void DeleteCateId(int categoryId)
        {
            //todo 刪除QAs的CategoryId
        }

        public ServiceCategoryEntity Get(int id)
        {
            var model = db.ServiceCategories.Find(id);
            var entity = new ServiceCategoryEntity
            {
                Id = model.Id,
                Name = model.Name,
            };
            return entity;
        }

        public List<ServiceCategoryEntity> GetAll()
        {
            return ServiceCategoryExts.DbToEntity();
        }

        public IEnumerable<ServiceCategoryEntity> Search()
        {
            return db.ServiceCategories.AsNoTracking().Select(x => new ServiceCategoryEntity { Id = x.Id, Name = x.Name }).ToList();
        }


        public void Update(ServiceCategoryEntity entity)
        {
            var model = db.ServiceCategories.Find(entity.Id);
            model.Id = entity.Id;
            model.Name = entity.Name;
            db.SaveChanges();
        }
    }
}
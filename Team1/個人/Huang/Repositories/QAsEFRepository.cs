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
    public class QAsEFRepository : IQAsRepository
    {
        private AppDbContext db = new AppDbContext();

        public void Create(QAsEntity entity)
        {
            var model = new QA
            {
                Id = entity.Id,
                ServiceCategoryId = entity.ServiceCategoryId,
                QName = entity.QName,
                AnsText = entity.AnsText,
            };
            db.QAs.Add(model);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = db.QAs.Find(id);

            db.QAs.Remove(model);
            db.SaveChanges();
        }

        public QAsEntity Get(int id)
        {
            var entity = db.QAs.Find(id);
            var model = new QAsEntity
            {
                Id = entity.Id,
                ServiceCategoryId = entity.ServiceCategoryId,
                QName = entity.QName,
                AnsText = entity.AnsText,
            };
            return model;
        }

        public List<QAsEntity> GetAll()
        {
            return QAsExts.DbToEntity();
        }

        public void Update(QAsEntity entity)
        {
            var model = db.QAs.Find(entity.Id);
            model.Id = entity.Id;
            model.ServiceCategoryId = entity.ServiceCategoryId;
            model.QName = entity.QName;
            model.AnsText = entity.AnsText;
            db.SaveChanges();
        }
    }
}
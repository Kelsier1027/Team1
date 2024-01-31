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
    public class CommentEFRepository : ICommentRepository
    {
        private AppDbContext db = new AppDbContext();
        public void Create(CommentEntity entity)
        {
            var model = new Comment
            {
                Id = entity.Id,
                MemberId = entity.MemberId,
                Rating = entity.Rating,
                Text = entity.Text,
                CommentDateTime = entity.CommentDateTime,
                ServiceCategoryId = entity.ServiceCategoryId,
            };
            db.Comments.Add(model);
            db.SaveChanges();
        }

        public void Delete(int id)
        {

            var model = db.Comments.Find(id);
            db.Comments.Remove(model);
            db.SaveChanges();
        }

        public CommentEntity Get(int id)
        {
            var entity = db.Comments.Find(id);
            var model = new CommentEntity
            {
                Id = entity.Id,
                ServiceCategoryId = entity.ServiceCategoryId,
                MemberId = entity.MemberId,
                Rating = entity.Rating,
                Text = entity.Text,
                CommentDateTime = entity.CommentDateTime,
            };
            return model;
        }

        public List<CommentEntity> GetAll()
        {
            return CommentExt.DbToEntity();
        }

        public void Update(CommentEntity entity)
        {
            var model = db.Comments.Find(entity.Id);
            model.Id = entity.Id;
            model.ServiceCategoryId = entity.ServiceCategoryId;
            model.MemberId = entity.MemberId;
            model.Rating = entity.Rating;
            model.Text = entity.Text;
            model.CommentDateTime = entity.CommentDateTime;
            db.SaveChanges();
        }
    }
}
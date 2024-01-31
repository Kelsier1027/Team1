using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team1.個人.Huang.Dtos;
using Team1.個人.Huang.Exts;
using Team1.個人.Huang.Interfaces;

namespace Team1.個人.Huang.Services
{
    public class CommentService
    {
        private readonly ICommentRepository _repo;
        public CommentService(ICommentRepository repo)
        {
            _repo = repo;
        }
        public List<CommentDto> GetAll()
        {
            var entity = _repo.GetAll();
            return CommentExt.EntityToDto(entity);
        }
        public void Create(CommentDto dto)
        {
            _repo.Create(CommentExt.DtoToEntity(dto));
        }
        public void Update(CommentDto dto)
        {
            _repo.Update(CommentExt.DtoToEntity(dto));
        }
        public void Delete(int id)
        {
            _repo.Delete(id);
        }
        public CommentDto Get(int id)
        {
            var entity = _repo.Get(id);
            var dto = new CommentDto
            {
                Id = entity.Id,
                ServiceCategoryId = entity.ServiceCategoryId,
                MemberId = entity.MemberId,
                MemberName = entity.MemberName,
                ServiceCategoryName = entity.ServiceCategoryName,
                Rating = entity.Rating,
                Text = entity.Text,
                CommentDateTime = entity.CommentDateTime,
            };
            return dto;
        } 
    }
}
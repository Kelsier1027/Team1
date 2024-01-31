using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team1.個人.Huang.Dtos;
using Team1.個人.Huang.Exts;
using Team1.個人.Huang.Interfaces;

namespace Team1.個人.Huang.Services
{
    public class QAsService
    {
        private readonly IQAsRepository _repo;
        public QAsService(IQAsRepository repo)
        {
            _repo = repo;
        }
        public List<QAsDto> GetAll()
        {
            var entity = _repo.GetAll();
            return entity.EntityToDto();
        }
        public void Create(QAsDto dto)
        {
            _repo.Create(dto.DtoToEntity());
        }
        public void Update(QAsDto dto)
        {
            _repo.Update(dto.DtoToEntity());
        }
        public void Delete(int id)
        {
            _repo.Delete(id);
        }
        public QAsDto Get(int id)
        {
            var entity = _repo.Get(id);
            var dto = new QAsDto
            {
                Id = entity.Id,
                ServiceCategoryId = entity.ServiceCategoryId,
                QName = entity.QName,
                AnsText = entity.AnsText,
            };
            return dto;
        }

        public List<QAsDto> SerchByCategoryId(int id)
        {
            var entity = _repo.SerchByCategoryId(id);
            return entity.EntityToDto();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team1.個人.Huang.Dtos;
using Team1.個人.Huang.Exts;
using Team1.個人.Huang.Interfaces;

namespace Team1.個人.Huang.Services
{
    public class ServiceCategoryService
    {
        private readonly IServiceCategoryRepository _repo;
        public ServiceCategoryService(IServiceCategoryRepository repo)
        {
            _repo = repo;
        }

        public List<ServiceCategoryDto> GetAll()
        {
            var enetity = _repo.GetAll();
            return ServiceCategoryExts.EntityToDto(enetity);
        }
        public void Create(ServiceCategoryDto dto)
        {
            bool isExists = _repo.GetAll().Any(x => x.Name == dto.Name);
            if (isExists) throw new Exception($"{dto.Name}名稱已存在");
            _repo.Create(ServiceCategoryExts.DtoToEntity(dto));
        }
        public void Update(ServiceCategoryDto dto)
        {
            bool isExists = _repo.GetAll().Any(x => x.Name == dto.Name && x.Id != dto.Id);
            if (isExists) throw new Exception($"{dto.Name}名稱已存在");
            _repo.Update(ServiceCategoryExts.DtoToEntity(dto));
        }
        public void Delete(int id)
        {
            //todo 刪除QAs的CategoryId
            _repo.Delete(id);
        }
        public ServiceCategoryDto Get(int id)
        {
            var entity = _repo.Get(id);
            var dto = new ServiceCategoryDto
            {
                Id = entity.Id,
                Name = entity.Name,
            };
            return dto;
        }
        public IEnumerable<ISelectListItem> SearchAll()
        {
            var entity = _repo.Search();
            return (IEnumerable<ISelectListItem>)entity;
        }
    }
}
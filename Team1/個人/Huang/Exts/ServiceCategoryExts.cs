using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team1.Models.EFModels;
using Team1.個人.Huang.Dtos;
using Team1.個人.Huang.Entities;
using Team1.個人.Huang.Repositories;
using System.Data.Entity;
using Team1.個人.Huang.ViewModels;
using Team1.個人.Huang.Services;

namespace Team1.個人.Huang.Exts
{
    public static class ServiceCategoryExts
    {
        public static List<ServiceCategoryVm> DisplayGetAll()
        {
            var repo = new ServiceCategoryEFRepository();
            var service = new ServiceCategoryService(repo);
            var vm = service.GetAll();

            return DtoToVm(vm);
        }

        public static List<ServiceCategoryEntity> DbToEntity()
        {
            var db = new AppDbContext();

            var entity = db.ServiceCategories.AsNoTracking().
                OrderByDescending(x => x.Id).
                Select(x => new ServiceCategoryEntity
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList();
            return entity;
        }
        public static List<ServiceCategoryDto> EntityToDto(this List<ServiceCategoryEntity> entities)
        {
            var listDto = new List<ServiceCategoryDto>();
            foreach (var entity in entities)
            {
                var dto = new ServiceCategoryDto
                {
                    Id = entity.Id,
                    Name = entity.Name,
                };
                listDto.Add(dto);
            }
            return listDto;
        }
        public static ServiceCategoryEntity DtoToEntity(this ServiceCategoryDto dtos)
        {
            var ent = new ServiceCategoryEntity
            {
                Id = dtos.Id,
                Name = dtos.Name,
            };
            return ent;
        }

        public static ServiceCategoryDto VmToDto(this ServiceCategoryVm vm)
        {
            var dto = new ServiceCategoryDto
            {
                Id = vm.Id,
                Name = vm.Name,
            };
            return dto;
        }
        public static List<ServiceCategoryVm> DtoToVm(this List<ServiceCategoryDto> dto)
        {
            var listVm = new List<ServiceCategoryVm>();
            foreach (var entity in dto)
            {
                var vm = new ServiceCategoryVm
                {
                    Id = entity.Id,
                    Name = entity.Name,
                };
                listVm.Add(vm);
            }
            return listVm;
        }
    }
}
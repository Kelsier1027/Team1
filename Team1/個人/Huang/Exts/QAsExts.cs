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
    public static class QAsExts
    {
        public static List<QAsVm> DisplayGetAll()
        {
            var repo = new QAsEFRepository();
            var service = new QAsService(repo);
            var vm = service.GetAll();

            return DtoToVm(vm);
        }
        public static List<QAsVm> DtoToVm(this List<QAsDto> dto)
        {
            var listVm = new List<QAsVm>();
            foreach (var entity in dto)
            {
                var vm = new QAsVm
                {
                    Id = entity.Id,
                    ServiceCategoryId = entity.ServiceCategoryId,
                    ServiceCategoryName = entity.ServiceCategoryName,
                    QName = entity.QName,
                    AnsText = entity.AnsText,
                };
                listVm.Add(vm);
            }
            return listVm;
        }
        public static List<QAsEntity> DbToEntity()
        {
            var db = new AppDbContext();

            var entity = db.QAs.AsNoTracking().
                Include(x => x.ServiceCategory).
                OrderByDescending(x => x.ServiceCategoryId).
                Select(x => new QAsEntity
                {
                    Id = x.Id,
                    ServiceCategoryId = x.ServiceCategoryId,
                    ServiceCategoryName = x.ServiceCategory.Name,
                    QName = x.QName,
                    AnsText = x.AnsText,
                }).ToList();
            return entity;
        }
        public static List<QAsDto> EntityToDto(this List<QAsEntity> entities)
        {
            var listDto = new List<QAsDto>();
            foreach (var entity in entities)
            {
                var dto = new QAsDto
                {
                    Id = entity.Id,
                    ServiceCategoryId = entity.ServiceCategoryId,
                    ServiceCategoryName = entity.ServiceCategoryName,
                    QName = entity.QName,
                    AnsText = entity.AnsText,
                };
                listDto.Add(dto);
            }
            return listDto;
        }
        public static QAsEntity DtoToEntity(this QAsDto dtos)
        {
            var ent = new QAsEntity
            {
                Id = dtos.Id,
                ServiceCategoryId = dtos.ServiceCategoryId,
                QName = dtos.QName,
                AnsText = dtos.AnsText,
            };
            return ent;
        }
        public static QAsDto VmToDto(this QAsVm vm)
        {
            var dto = new QAsDto
            {
                Id = vm.Id,
                ServiceCategoryId = vm.ServiceCategoryId,
                QName = vm.QName,
                AnsText = vm.AnsText,
            };
            return dto;
        }
    }
}
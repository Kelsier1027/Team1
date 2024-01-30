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
    public static class CommentExt
    {
        public static List<CommentVm> DisplayGetAll()
        {
            var repo = new CommentEFRepository();
            var service = new CommentService(repo);
            var vm = service.GetAll();
            return DtoToVm(vm);
        }

        public static List<CommentVm> DtoToVm(this List<CommentDto> dto)
        {
            var listVm = new List<CommentVm>();
            foreach (var entity in dto)
            {
                var vm = new CommentVm
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
                listVm.Add(vm);
            }
            return listVm;
        }
        public static List<CommentEntity> DbToEntity()
        {
            var db = new AppDbContext();

            var entity = db.Comments.AsNoTracking().
                Include(x => x.Member).
                Include(x => x.ServiceCategory).
                Select(x => new CommentEntity
                {
                    Id = x.Id,
                    ServiceCategoryId = x.ServiceCategoryId,
                    MemberId = x.MemberId,
                    MemberName = x.Member.Account,
                    ServiceCategoryName = x.ServiceCategory.Name,
                    Rating = x.Rating,
                    Text = x.Text,
                    CommentDateTime = x.CommentDateTime,
                }).ToList();
            return entity;
        }
        public static List<CommentDto> EntityToDto(this List<CommentEntity> entities)
        {
            var listDto = new List<CommentDto>();
            foreach (var entity in entities)
            {
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
                listDto.Add(dto);
            }
            return listDto;
        }
        public static CommentEntity DtoToEntity(this CommentDto dtos)
        {
            var ent = new CommentEntity
            {
                Id = dtos.Id,
                ServiceCategoryId = dtos.ServiceCategoryId,
                ServiceCategoryName = dtos.ServiceCategoryName,
                MemberId = dtos.MemberId,
                MemberName = dtos.MemberName,
                Rating = dtos.Rating,
                Text = dtos.Text,
                CommentDateTime = dtos.CommentDateTime,
            };
            return ent;
        }
        public static CommentDto VmToDto(this CommentVm vm)
        {
            var dto = new CommentDto
            {
                Id = vm.Id,
                ServiceCategoryId = vm.ServiceCategoryId,
                ServiceCategoryName = vm.ServiceCategoryName,
                MemberId = vm.MemberId,
                MemberName = vm.MemberName,
                Rating = vm.Rating,
                Text = vm.Text,
                CommentDateTime = vm.CommentDateTime,
            };
            return dto;
        }
    }
}
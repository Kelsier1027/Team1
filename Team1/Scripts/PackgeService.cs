using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using Team1.Models.EFModels;
using Team1.ViewModels;

namespace Team1.Scripts
{
    public class PackgeService
    {
        public List<PackageVM> Search(int? packageId)
        {
            using (var db = new AppDbContext())
            {
                var query = db.Packages.AsQueryable();

                if (packageId > 0)
                {
                    query = query.Where(p => p.Id == packageId);
                }

                // Materialize the query before projecting to PackageVM
                var result = query.ToList().Select(p => new PackageVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    LowestGo = p.LowestGo,
                    ApplyEndDate = p.ApplyEndDate,
                    ApplyBeginDate = p.ApplyBeginDate,
                    CanSold = p.CanSold,
                    TotalNum = p.TotalNum,
                    Image = "/File/Pinyue/Image/"+p.Image,
                    Description = "/File/Pinyue/PackageDescription/" + p.Description,
                    Alert = p.Alert,
                    PriceDescription = p.PriceDescription,
                }).ToList();

                return result;
            }
        }
        public void Create(PackageVM data)
        {
            using (var db = new AppDbContext())
            {

                Package packages = new Package();
                packages.Name = data.Name;
                packages.Price = data.Price;
                packages.LowestGo = data.LowestGo;
                packages.ApplyEndDate = data.ApplyEndDate;  
                packages.ApplyBeginDate = data.ApplyBeginDate;
                packages.CanSold = data.TotalNum;
                packages.TotalNum = data.TotalNum;
                packages.Image = data.Image;
                packages.Description = data.Description;
                db.Packages.Add(packages);
                db.SaveChanges();
            }
        }
        public void Edit(PackageVM data)
        {
            using (var db = new AppDbContext())
            {
                Package packages = db.Packages.Where(x => x.Id == data.Id).FirstOrDefault();
                packages.Name = data.Name;
                packages.Price = data.Price;
                packages.LowestGo = data.LowestGo;
                packages.ApplyEndDate = data.ApplyEndDate;
                packages.ApplyBeginDate = data.ApplyBeginDate;
                packages.TotalNum = data.TotalNum;
                if (data.Image != null)
                {
                    // 刪除舊檔

                    DeleteFile("~/File/Pinyue/Image/"+packages.Image);
                    packages.Image = data.Image;
                
                }
                if (data.Description != null)
                {    // 刪除舊檔
                    DeleteFile("~/File/Pinyue/PackageDescription/" + packages.Description);
                    packages.Description = data.Description;
                }
                db.SaveChanges();
            }
        }
        public void DeleteFile(string filePath)
        {
            try
            {
                var fullPath = HostingEnvironment.MapPath(filePath);
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void Delete(int id)
        {
            using (var db = new AppDbContext())
            {
                db.Packages.Remove(db.Packages.Where(x => x.Id == id).FirstOrDefault());
                db.SaveChanges();
            }
        }

        // 檢查 RoomId 是否已存在的方法
        public bool IsPackageIdExist(int id)
        {
            using (var db = new AppDbContext())
            {
                return db.Packages.Where(x => x.Id == id).Any();
            }
        }
        public List<PackageVM> Search_Cond(int? id ,string name, DateTime? date)
        {
            using (var db = new AppDbContext())
            {
                var query = db.Packages.AsQueryable();

                if (id > 0)
                {
                    query = query.Where(p => p.Id == id);
                }
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(p => p.Name.Contains(name));
                }
                if (date != null)
                {
                    query = query.Where(p => p.ApplyBeginDate<= date && p.ApplyEndDate>= date);
                }
                // Materialize the query before projecting to PackageVM
                var result = query.ToList().Select(p => new PackageVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    LowestGo = p.LowestGo,
                    ApplyEndDate = p.ApplyEndDate,
                    ApplyBeginDate = p.ApplyBeginDate,
                    CanSold = p.CanSold,
                    TotalNum = p.TotalNum,
                    Image = "/File/Pinyue/Image/" + p.Image,
                    Description = "/File/Pinyue/PackageDescription/" + p.Description,
                    Alert = p.Alert,
                    PriceDescription = p.PriceDescription,
                }).ToList();

                return result;
            }
        }
    }
}
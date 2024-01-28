using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
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
                    Image = p.Image,
                    Description = p.Description,
                    Alert = p.Alert,
                    PriceDescription = p.PriceDescription,
                }).ToList();

                return result;
            }
        }
        public void Create(PackageInsertVM data)
        {
            using (var db = new AppDbContext())
            {
                Package packages = new Package();
                packages.Id = data.Id;
                packages.Name = data.Name;
                packages.Price = data.Price;
                packages.LowestGo = data.LowestGo;
                packages.ApplyEndDate = data.ApplyEndDate;  
                packages.ApplyBeginDate = data.ApplyBeginDate;
                packages.CanSold = data.CanSold;
                packages.TotalNum = data.TotalNum;
                packages.Image = data.Image;
                packages.Description = data.Description;
                packages.Alert = data.Alert;
                packages.PriceDescription = data.PriceDescription;
                
                db.Packages.Add(packages);
                db.SaveChanges();
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
    }
}
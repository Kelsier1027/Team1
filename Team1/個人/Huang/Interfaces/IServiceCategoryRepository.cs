using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team1.個人.Huang.Entities;

namespace Team1.個人.Huang.Interfaces
{
    public interface IServiceCategoryRepository
    {
        List<ServiceCategoryEntity> GetAll();
        void Create(ServiceCategoryEntity entity);
        void Update(ServiceCategoryEntity entity);
        void Delete(int id);
        ServiceCategoryEntity Get(int id);
        IEnumerable<ServiceCategoryEntity> Search();
    }
}

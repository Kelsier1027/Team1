using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team1.個人.Huang.Entities;

namespace Team1.個人.Huang.Interfaces
{
    public interface IQAsRepository
    {
        List<QAsEntity> GetAll();
        void Create(QAsEntity entity);
        void Update(QAsEntity entity);
        void Delete(int id);
        QAsEntity Get(int id);
    }
}

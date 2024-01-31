using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team1.個人.Huang.Entities;

namespace Team1.個人.Huang.Interfaces
{
    public interface ICommentRepository
    {
        List<CommentEntity> GetAll();
        void Create(CommentEntity entity);
        void Update(CommentEntity entity);
        void Delete(int id);
        CommentEntity Get(int id);
    }
}

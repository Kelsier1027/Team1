using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team1.個人.Huang.Interfaces
{
    public interface ISelectListService
    {
        IEnumerable<ISelectListItem> SearchAll();
    }
}

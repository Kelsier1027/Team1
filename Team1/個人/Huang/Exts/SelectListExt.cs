using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team1.個人.Huang.Interfaces;

namespace Team1.個人.Huang.Exts
{
    public static class SelectListExt
    {
        public static IEnumerable<SelectListItem> GetSelectListItems(this ISelectListService service)
        {
            var list = service.SearchAll();

            var result = new List<SelectListItem>();

            foreach (var item in list)
            {
                result.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name });
            }

            return result.Prepend(new SelectListItem { Value = "", Text = "請選擇..." });
        }

        public static SelectList GetSelectList(this ISelectListService service, int selectId)
        {
            return new SelectList(service.SearchAll(), "Id", "Name", selectId);
        }
    }
}
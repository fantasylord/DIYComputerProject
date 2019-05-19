using DIYComputer.Entity.ComputerWareEntity;
using DIYComputer.Util.CommonModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DIYComputer.WebFrontend.ViewComponents
{
    [ViewComponent(Name = "CGroupList")]
    public class CGroupListViewComponent:ViewComponent
    {
       // private VierificationCodeServices _codeServices;

        public CGroupListViewComponent()
        {
            ;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="models"></param>
        /// <param name="index"></param>
        /// <param name="order">1 ID 2 名称 3 价格 4时间 -1,-2,-3,-4 倒序</param>
        
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync(PageSplitModel<CGroutBaseEntity> models,int index,int order= 1)
        {
            switch (order)
            {
                case 1:
                    models.Items = models.Items.OrderBy(o => o.ID).ToList();
                    break;
                case 2:
                    models.Items = models.Items.OrderBy(o => o.Name).ToList();
                    break;
                case 3:
                    models.Items = models.Items.OrderBy(o => o.Value).ToList();
                    break;
                case -1:
                    models.Items = models.Items.OrderByDescending(o => o.ID).ToList();
                    break;
                case -2:
                    models.Items = models.Items.OrderByDescending(o => o.Name).ToList();
                    break;
                case -3:
                    models.Items = models.Items.OrderByDescending(o => o.Value).ToList();
                    break;
                default:
                    break;
            }
            ViewBag["order"] = order;
            ViewBag["index"] = index;
            return View(models);
        }
    }
}

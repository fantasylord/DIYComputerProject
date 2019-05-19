using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIYComputer.Util.CommonModel
{
    public class PageSplitModel<T> 
    {

        /// <summary>
        /// 请求路径
        /// </summary>
        public string ActionUrl { get; set; }
        /// <summary>
        /// 总条目
        /// </summary>
        public ICollection<T> Items { get; set; }
        /// <summary>
        /// 页面大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总条目数
        /// </summary>
        public int TotalItems { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPage { get; set; }
        /// <summary>
        /// 当前页面
        /// </summary>
        public int IndexPage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_item"></param>
        /// <param name="_indexPage"></param>
        /// <param name="_pagesize"></param>
        public PageSplitModel(List<T>  _item,  int _indexPage,int _pagesize,int _count)
        {
            _pagesize = _pagesize <= 0 ? 100 : _pagesize;
            _indexPage = _indexPage <= 0 ? 100 : _indexPage;
            
            Items = _item;
            PageSize = _pagesize;
            TotalItems = _count;
          //  PageSize = Items.Count;///限制 取消客户端分页

            TotalPage = _count / PageSize + (_item.Count % PageSize) > 0 ? 1 : 0;
            IndexPage =TotalPage>0? _indexPage%TotalPage==0?1: _indexPage % TotalPage:0;
        }

        

    }
}

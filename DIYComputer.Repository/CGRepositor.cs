using DIYComputer.Config.StaticSource;
using DIYComputer.Entity.ComputerWareEntity;
using DIYComputer.Entity.DBContext;
using DIYComputer.Repository.IRepository;
using DIYComputer.Util.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DIYComputer.Repository
{
    public class CGRepositor<T> : ICGRepositor<T> where T : CGroutBaseEntity
    {
        private readonly EFDBContext _dbContenxt;

        public CGRepositor(EFDBContext dbContenxt)
        {
            _dbContenxt = dbContenxt;
        }

        public PageSplitModel<T> GetByAll(string brand, decimal value1, decimal value2, HardWareEnum hardWareEnum, string name, int indexPage = -1, int size = -1, int id = -1)
        {
            if (id > 0)
            {
                var result = _dbContenxt.Set<T>().Where(o => o.ID == id).AsEnumerable();
                return GetListOnSplitPage(result, indexPage, size);
            }
            else
            {
                var result = _dbContenxt.Set<T>().Where(o =>
                        (
                           o.Brand.Contains(brand) &&
                           o.Value >= value1 && (value2 > 0 ? o.Value <= value2 : true) &&
                           o.HardWareEnum == hardWareEnum &&
                           o.Name.Contains(name)
                        )).AsEnumerable();
                return GetListOnSplitPage(result, indexPage, size);

            }
        }
        public PageSplitModel<T> GetByAny(string brand, decimal value1, decimal value2, HardWareEnum hardWareEnum, string name, int indexPage = -1, int size = -1)
        {
            var result = _dbContenxt.Set<T>().Where(o =>
                (
                    o.Brand.Contains(brand) ||
                    o.Value >= value1 && (value2 > 0 ? o.Value <= value2 : true) ||
                    o.HardWareEnum == hardWareEnum ||
                    o.Name.Contains(name)
                )).AsEnumerable();
            return GetListOnSplitPage(result, indexPage, size);

        }

        public PageSplitModel<T> GetByBrand(string brand, int indexPage = -1, int size = -1)
        {
            //  string type = Type.GetType(typeof(TCGroutBaseClass).AssemblyQualifiedName).ToString();

            var result = _dbContenxt.Set<T>().Where(o => o.Brand.Contains(brand)).AsEnumerable();
            return GetListOnSplitPage(result, indexPage, size);
        }

        public PageSplitModel<T> GetByCustom(Expression<Func<T, bool>> whereLambda, int indexPage = -1, int size = -1)
        {
            var result = _dbContenxt.Set<T>().Where(whereLambda).AsEnumerable();
            return GetListOnSplitPage(result, indexPage, size);
        }

        public PageSplitModel<T> GetByHardWareEnum(HardWareEnum hardWareEnum, int indexPage = -1, int size = -1)
        {
            var result = _dbContenxt.Set<T>().Where(o => o.HardWareEnum == hardWareEnum).AsEnumerable();

            return GetListOnSplitPage(result, indexPage, size);
        }

        public T GetById(int id)
        {
            return _dbContenxt.Set<T>().Find(id);
        }

        public PageSplitModel<T> GetByName(string name, int indexPage = -1, int size = -1)
        {

            var result = _dbContenxt.Set<T>().Where(o => o.Name.Contains(name)).AsEnumerable();
            return GetListOnSplitPage(result, indexPage, size);
        }

        public PageSplitModel<T> GetByValue(decimal value1, decimal value2, int indexPage = -1, int size = -1)
        {
            var result = _dbContenxt.Set<T>().Where(o => (o.Value >= value1 && (value2 > 0 ? o.Value <= value2 : true)))
                .AsEnumerable();
            return GetListOnSplitPage(result, indexPage, size);
        }

        public PageSplitModel<T> List(int indexPage = -1, int size = -1)
        {
            var result = _dbContenxt.Set<T>().AsEnumerable();
            return GetListOnSplitPage(result, indexPage, size);
        }

        public PageSplitModel<T> List(Expression<Func<T, bool>> predicate, int indexPage = -1, int size = -1)
        {
            var result = _dbContenxt.Set<T>().Where(predicate).AsEnumerable();
            return GetListOnSplitPage(result, indexPage, size);
        }

        public PageSplitModel<T> GetForMounthCount(int MounthCount, int indexPage = -1, int size = -1)
        {
            var result = _dbContenxt.Set<T>().AsEnumerable();
            return GetListOnSplitPage(result, indexPage, size);
        }
        public PageSplitModel<T> GetForAddCount(int AddCount, int indexPage = -1, int size = -1)
        {
            var result = _dbContenxt.Set<T>().AsEnumerable();
            return GetListOnSplitPage(result, indexPage, size);
        }

        public bool IsExists(Expression<Func<T, bool>> predicate)
        {
            return _dbContenxt.Set<T>().Where(predicate).Count() > 0 ? true : false;
        }
        private PageSplitModel<T> GetListOnSplitPage(IEnumerable<T> list, int indexPage = -1, int size = -1)
        {
            int totalItems = list.Count();

            if (totalItems <= 0)
            {
                return new PageSplitModel<T>(new List<T>(), indexPage, size, totalItems);
            }
            if (indexPage >= 1 && size > 0)
            {
                list = list.Skip((indexPage - 1) * size).Take(size).AsEnumerable();

            }

            return new PageSplitModel<T>(list.ToList(), indexPage, size, totalItems);


        }


    }
}

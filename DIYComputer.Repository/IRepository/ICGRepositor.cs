using DIYComputer.Config.StaticSource;
using DIYComputer.Util.CommonModel;
using System;
using System.Linq.Expressions;

namespace DIYComputer.Repository.IRepository
{
    /// <summary>
    /// 电脑组件仓储   用于API
    /// </summary>
    public interface ICGRepositor<CGroutBaseEntity>  
    {
        //Brand Value HardWareEnum  
        CGroutBaseEntity GetById(int id);
         PageSplitModel<CGroutBaseEntity> GetByBrand(string brand, int indexPage = -1, int size = -1);
         PageSplitModel<CGroutBaseEntity> GetByValue(decimal value1, decimal value2,int indexPage=-1, int size=-1);
         PageSplitModel<CGroutBaseEntity> GetByHardWareEnum(HardWareEnum hardWareEnumint, int indexPage = -1, int size = -1);
         PageSplitModel<CGroutBaseEntity> GetByName(string name, int indexPage = -1, int size = -1);
         PageSplitModel<CGroutBaseEntity> GetByCustom(Expression<Func<CGroutBaseEntity, bool>> whereLambda, int indexPage = -1, int size = -1);
         PageSplitModel<CGroutBaseEntity> GetByAll(string brand, decimal value1, decimal value2,HardWareEnum hardWareEnum, string name, int indexPage = -1, int size = -1, int id = -1);
         PageSplitModel<CGroutBaseEntity> GetByAny(string brand, decimal value1, decimal value2, HardWareEnum hardWareEnum, string name, int indexPage = -1, int size = -1);
         PageSplitModel<CGroutBaseEntity> List(int indexPage = -1, int size = -1);
         PageSplitModel<CGroutBaseEntity> List(Expression<Func<CGroutBaseEntity, bool>> predicate, int indexPage = -1, int size = -1);

         PageSplitModel<CGroutBaseEntity> GetForMounthCount(int MounthCount, int indexPage = -1, int size = -1);
         PageSplitModel<CGroutBaseEntity> GetForAddCount(int AddCount, int indexPage = -1, int size = -1);
        bool IsExists(Expression<Func<CGroutBaseEntity,bool>> predicate);


    }
}

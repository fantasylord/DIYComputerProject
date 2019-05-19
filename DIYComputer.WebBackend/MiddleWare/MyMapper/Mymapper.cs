using AutoMapper;
using DIYComputer.Service.IServices;
using DIYComputer.Service.Services;
using System;
using System.Linq;
using System.Reflection;

namespace DIYComputer.WebBackend.MiddleWare.MyMapper
{
    public class Mymapper
    {
        public static void RegisterMappings()
        {
            var allType=Assembly
                .GetEntryAssembly()//获取默认程序集
               .GetReferencedAssemblies()//获取所有引用程序集
               .Select(Assembly.Load)
               .SelectMany(y => y.DefinedTypes)
               .Where(type => typeof(IProfile).GetTypeInfo().IsAssignableFrom(type.AsType()));

            foreach (var typeInfo in allType)
            {
                var type = typeInfo.AsType();
                if (type.Equals(typeof(IProfile)))
                {
                    //注册映射
                    Mapper.Initialize(y =>
                    {
                        y.AddProfiles(type); // Initialise each Profile classe
                    });
                }
            }
        }
    }
}

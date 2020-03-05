using System;
using System.Linq;
using Yerel.Core.CrossCuttingConcern.Caching.Microsoft;
using PostSharp.Aspects;

namespace Yerel.Core.Aspects.CacheAspects
{
    [Serializable]
    public class CacheAspect : MethodInterceptionAspect
    {
        private readonly int _dakika;

        /// <param name="bitisSuresi">Cache işleminin dakika olarak ömrü (standart 60 dakikadır)</param>
        public CacheAspect(int bitisSuresi = 60)
        {
            _dakika = bitisSuresi;
        }
       
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            //cache manager türetiliyor
            var cacheManager = new MemoryCacheManager();

            //metod ismi alınıyor
            var methodName = string.Format("{0}.{1}.{2}",
                                     args.Method.ReflectedType.Namespace,
                                     args.Method.ReflectedType.Name,
                                     args.Method.Name);

            //metod parametreleri alınıyor
            var arguments = args.Arguments.ToList();

            //cache key oluşturuluyor {MetodAdı.Parametreler}
            var key = string.Format("{0}({1})", methodName, string.Join(",", arguments.Select(x => x != null ? x.ToString() : "<Null>")));

            //metod cache de var ise oradan çağrılıyor
            if (cacheManager.IsAdd(key))
            {
                args.ReturnValue = cacheManager.Get<object>(key);
                return;
            }

            //metod çalıştırılıyor
            base.OnInvoke(args);

            //metod cache ekleniyor
            cacheManager.Add(key, args.ReturnValue, _dakika);
        }
    }
}

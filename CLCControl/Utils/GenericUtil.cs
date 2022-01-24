using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLCControls.Utils
{
    /// <summary>
    /// 泛型工具类
    /// </summary>
    public class GenericUtil
    {
        public static IList CreateList(Type myType)
        {
            Type genericListType = typeof(List<>).MakeGenericType(myType);
            return (IList)Activator.CreateInstance(genericListType);
        }
    }
}

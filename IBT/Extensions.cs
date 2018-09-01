using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;

namespace IBT
{
    public static class Extensions
    {
        public static MemoryStream GetMemoryStream(this ResourceManager resourceManager, String name)
        {
            object resource = resourceManager.GetObject(name);

            if (resource is byte[])
            {
                return new MemoryStream((byte[])resource);
            }
            else
            {
                throw new System.InvalidCastException("The specified resource is not a binary resource.");
            }
        }
    }
}

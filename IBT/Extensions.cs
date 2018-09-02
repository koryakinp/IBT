using System;
using System.IO;
using System.Resources;

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
                throw new InvalidCastException("The specified resource is not a binary resource.");
            }
        }
    }
}

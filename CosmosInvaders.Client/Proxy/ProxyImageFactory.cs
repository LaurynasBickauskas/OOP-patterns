using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosInvaders.Client.Proxy
{
    public static class ProxyImageFactory
    {
        public static IImage GetProxyImage(string path)
        {
            if (System.IO.File.Exists(path))
            {
                return new ProxyImage(path);
            }
            else
            {
                return new NullImage(path);
            }
        }
    }
}
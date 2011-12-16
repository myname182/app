using System;
using System.Net.NetworkInformation;
using app.infrastructure.containers.simple;

namespace app.tasks.startup
{
    public static class Start
    {
        static Start()
        {
            
        }

        public static ICreateASingleDependency by<T>()
        {
            throw new NotImplementedException();
        }

        public static ICreateASingleDependency followed_by<T>()
        {
            throw new NotImplementedException();
        }

        public static void finish_by<T>()
        {
            throw new NotImplementedException();
        }
    }
}
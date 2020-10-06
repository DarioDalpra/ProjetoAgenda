using Agenda_WPF.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda_WPF.DAL
{
    class SingletonContext
    {
        private static Context ctx;
        private SingletonContext() { }
        public static Context GetInstance()
        {
            if (ctx == null)
            {
                ctx = new Context();
            }
            return ctx;
        }
    }
}

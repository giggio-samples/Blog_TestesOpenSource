using NHibernate;

namespace ClassLibrary1
{
    public class Contexto
    {
        public static ISessionFactory SessionFactory { get; set; }
    }
}
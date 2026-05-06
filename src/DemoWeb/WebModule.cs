using Autofac;

namespace DemoWeb
{
    public class WebModule : Module
    {
        private readonly string _connectionString;

        public WebModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            //containerBuilder.RegisterType<Membership>().Keyed<IMembership>("Setup 1").InstancePerLifetimeScope().WithParameter("name", "Ariful");
            base.Load(builder);
        }

    }
}

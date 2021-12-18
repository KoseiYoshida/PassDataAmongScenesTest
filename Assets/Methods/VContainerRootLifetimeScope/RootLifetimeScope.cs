using VContainer;
using VContainer.Unity;

namespace Methods.VContainerRootLifetimeScope
{
    public class RootLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            builder.Register<ScoreHolderRoot>(Lifetime.Singleton);
        }
    }
}
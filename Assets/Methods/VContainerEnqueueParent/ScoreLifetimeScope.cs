using VContainer;
using VContainer.Unity;

namespace Methods.VContainerEnqueueParent
{
    public sealed class ScoreLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            builder.Register<ScoreHolderEnqueueParent>(Lifetime.Singleton);
        }
    }
}
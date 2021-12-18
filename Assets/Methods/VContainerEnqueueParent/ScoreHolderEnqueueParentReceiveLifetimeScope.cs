using Config;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Methods.VContainerEnqueueParent
{
    public sealed class ScoreHolderEnqueueParentReceiveLifetimeScope : LifetimeScope
    {
        [SerializeField] private ProvideTypeConfig config = default;


        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            if (config.ProvideType != ProvideType.VContainer_EnqueueParent)
            {
                builder.Register<ScoreHolderEnqueueParent>(Lifetime.Singleton);
            }
        }
    }
}
using PufferSoftware.EventSystem;

namespace PufferSoftware.Scripts.Core.BehaviorTree
{
    public abstract class Tree : Actor
    {
        private Node _root;

        protected virtual void Start()
        {
            _root = SetupTree();
        }

        private void Update()
        {
            _root?.Evaluate();
        }

        protected abstract Node SetupTree();
    }
}
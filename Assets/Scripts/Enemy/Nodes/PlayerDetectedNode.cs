using PufferSoftware.Scribtables;
using UnityEngine;

namespace PufferSoftware.Scripts.Core.BehaviorTree.Enemy
{
    public class PlayerDetectedNode : Node
    {
        private Transform _transform;
        private Transform _playerTransform;
        private EnemyConfig _config;

        public PlayerDetectedNode(Transform transform, Transform playerTransform, EnemyConfig config)
        {
            _transform = transform;
            _playerTransform = playerTransform;
            _config = config;
        }

        public override NodeState Evaluate()
        {
            if (Vector3.Distance(_transform.position, _playerTransform.position) <= _config.detectionRange)
            {
                state = NodeState.SUCCESS;
                return state;
            }

            state = NodeState.FAILURE;
            return state;
        }
    }
}
using PufferSoftware.Scribtables;
using UnityEngine;

namespace PufferSoftware.Scripts.Core.BehaviorTree.Enemy
{
    public class AttackPlayerNode : Node
    {
        private Transform _transform;
        private Transform _playerTransform;
        private EnemyConfig _config;

        public AttackPlayerNode(Transform transform, Transform playerTransform, EnemyConfig config)
        {
            _transform = transform;
            _playerTransform = playerTransform;
            _config = config;
        }

        public override NodeState Evaluate()
        {
            if (Vector3.Distance(_transform.position, _playerTransform.position) <= _config.attackRange)
            {
                Debug.Log("Player takes damage!");
                state = NodeState.SUCCESS;
                return state;
            }

            state = NodeState.FAILURE;
            return state;
        }
    }
}
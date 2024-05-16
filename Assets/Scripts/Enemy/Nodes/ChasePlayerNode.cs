using PufferSoftware.Scribtables;
using UnityEngine;
using UnityEngine.AI;

namespace PufferSoftware.Scripts.Core.BehaviorTree.Enemy
{
    public class ChasePlayerNode : Node
    {
        private Transform _transform;
        private Transform _player;
        private NavMeshAgent _agent;
        private EnemyConfig _enemyConfig;

        public ChasePlayerNode(EnemyConfig enemyConfig, Transform transform, Transform player, NavMeshAgent agent)
        {
            _transform = transform;
            _player = player;
            _agent = agent;
            _enemyConfig = enemyConfig;
        }

        public override NodeState Evaluate()
        {
            if (_player == null)
            {
                return NodeState.FAILURE;
            }


            _agent.SetDestination(_player.position);


            Vector3 direction = _agent.velocity.normalized;
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                _transform.rotation =
                    Quaternion.Slerp(_transform.rotation, targetRotation, Time.deltaTime * _enemyConfig.rotationSpeed);
            }

            return NodeState.RUNNING;
        }
    }
}
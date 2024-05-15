using PufferSoftware.Scribtables;
using UnityEngine;
using UnityEngine.AI;

namespace PufferSoftware.Scripts.Core.BehaviorTree.Enemy
{
    public class ChasePlayerNode : Node
    {
        private NavMeshAgent _agent;
        private Transform _playerTransform;
        private EnemyConfig _config;

        public ChasePlayerNode(NavMeshAgent agent, Transform playerTransform, EnemyConfig config)
        {
            _agent = agent;
            _playerTransform = playerTransform;
            _config = config;
        }

        public override NodeState Evaluate()
        {
            _agent.speed = _config.chaseSpeed;
            _agent.SetDestination(_playerTransform.position);
            state = NodeState.RUNNING;
            return state;
        }
    }
}
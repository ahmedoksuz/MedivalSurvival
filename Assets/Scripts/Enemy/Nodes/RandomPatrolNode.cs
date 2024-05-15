using UnityEngine;
using System.Collections.Generic;
using PufferSoftware.Scribtables;
using UnityEngine;
using UnityEngine.AI;

namespace PufferSoftware.Scripts.Core.BehaviorTree.Enemy
{
    public class RandomPatrolNode : Node
    {
        private NavMeshAgent _agent;
        private EnemyConfig _config;
        private Vector3 _nextPosition;

        public RandomPatrolNode(NavMeshAgent agent, EnemyConfig config)
        {
            _agent = agent;
            _config = config;
        }

        public override NodeState Evaluate()
        {
            if (!_agent.hasPath || _agent.remainingDistance < 0.5f)
            {
                _nextPosition = GetRandomPosition();
                _agent.speed = _config.patrolSpeed;
                _agent.SetDestination(_nextPosition);
            }

            state = NodeState.RUNNING;
            return state;
        }

        private Vector3 GetRandomPosition()
        {
            float randomX = Random.Range(-10.0f, 10.0f);
            float randomZ = Random.Range(-10.0f, 10.0f);
            return new Vector3(randomX, _agent.transform.position.y, randomZ);
        }
    }
}
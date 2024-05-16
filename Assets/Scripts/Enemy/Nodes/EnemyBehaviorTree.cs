using UnityEngine;
using System.Collections.Generic;
using PufferSoftware.EventSystem;
using PufferSoftware.Scribtables;
using UnityEngine.AI;

namespace PufferSoftware.Scripts.Core.BehaviorTree.Enemy
{
    public class EnemyBehaviorTree : Tree
    {
        public Transform playerTransform;
        public EnemyConfig config;
        public EnemyAttackConfig enemyAttackConfig;
        private NavMeshAgent _agent;

        protected void Awake()
        {
            base.Start();
            _agent = GetComponent<NavMeshAgent>();
        }

        protected override Node SetupTree()
        {
            Node randomPatrol = new RandomPatrolNode(_agent, config);
            Node playerDetected = new PlayerDetectedNode(transform, playerTransform, config);
            Node chasePlayer = new ChasePlayerNode(config, transform, playerTransform, _agent);
            Node attackPlayer = new AttackPlayerNode(config, enemyAttackConfig, transform, playerTransform);

            Sequence chaseSequence = new Sequence(new List<Node> { playerDetected, chasePlayer });
            Sequence attackSequence = new Sequence(new List<Node> { playerDetected, attackPlayer });

            Selector root = new Selector(new List<Node> { attackSequence, chaseSequence, randomPatrol });

            return root;
        }
    }
}
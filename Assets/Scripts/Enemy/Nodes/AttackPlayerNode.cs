using PufferSoftware.Scribtables;
using UnityEngine;

namespace PufferSoftware.Scripts.Core.BehaviorTree.Enemy
{
    public class AttackPlayerNode : Node
    {
        private Transform _transform;
        private Transform _player;
        private float _lastAttackTime = 0f;
        private EnemyAttackConfig _enemyAttackConfig;
        private EnemyConfig _enemyConfig;

        public AttackPlayerNode(EnemyConfig enemyConfig, EnemyAttackConfig enemyAttackConfig, Transform transform,
            Transform player)
        {
            _transform = transform;
            _player = player;
            _enemyAttackConfig = enemyAttackConfig;
            _enemyConfig = enemyConfig;
        }

        public override NodeState Evaluate()
        {
            if (_player == null)
            {
                return NodeState.FAILURE;
            }

            float distance = Vector3.Distance(_transform.position, _player.position);
            if (distance <= _enemyAttackConfig.attackRange)
            {
                if (Time.time - _lastAttackTime >= _enemyAttackConfig.attackCooldown)
                {
                    _lastAttackTime = Time.time;
                    Debug.Log("Player Took " + _enemyAttackConfig.attackDamage + " Damage!");
                }

                Vector3 direction = (_player.position - _transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                _transform.rotation =
                    Quaternion.Slerp(_transform.rotation, lookRotation,
                        Time.deltaTime * _enemyConfig.rotationSpeed);

                return NodeState.RUNNING;
            }

            return NodeState.FAILURE;
        }
    }
}
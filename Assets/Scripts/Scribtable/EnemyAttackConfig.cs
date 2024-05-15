using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAttackConfig", menuName = "Puffer Games/EnemyAttackConfig", order = 1)]
public class EnemyAttackConfig : ScriptableObject
{
    public float attackRange;
    public float attackDamage;
    public float attackCooldown;
}
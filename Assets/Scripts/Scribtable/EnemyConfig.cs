using UnityEngine;

namespace PufferSoftware.Scribtables
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Puffer Games/EnemyConfig", order = 1)]
    public class EnemyConfig : ScriptableObject
    {
        [Range(0, 30)] public float patrolSpeed = 2.0f;
        [Range(0, 30)] public float chaseSpeed = 3.5f;
        [Range(0, 30)] public float detectionRange = 5.0f;
        [Range(0, 5)] public float attackRange = 1.5f;
    }
}
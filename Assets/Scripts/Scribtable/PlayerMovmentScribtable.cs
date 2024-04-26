using UnityEngine;

namespace PufferSoftware.Scribtables
{
    [CreateAssetMenu(fileName = "Player Movement Data", menuName = "Puffer Games/Player Movement Data", order = 1)]
    public class PlayerMovmentScribtable : ScriptableObject
    {
        [Range(0, 20)] public float speed;
        [Range(0, 1000)] public float turnSpeed;
        [Range(0, 50)] public float mouseSensitivity;
    }
}
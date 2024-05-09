using UnityEngine;

namespace PufferSoftware.Scribtables
{
    [CreateAssetMenu(fileName = "Player Movement Data", menuName = "Puffer Games/Player Movement Data", order = 1)]
    public class PlayerMovementScriptable : ScriptableObject
    {
        [Range(0, 100)] public float speed;
        [Range(0, 5)] public float smooth;
        [Range(0, 1000)] public float turnSpeed;
    }
}
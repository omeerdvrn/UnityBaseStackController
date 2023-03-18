using UnityEngine;

namespace BaseStackController
{
    public static class VoidDelegates
    {
        public delegate void IntEvent(int num);
        public delegate void FloatEvent(float num);
        public delegate void GameObjectEvent(GameObject go);
        public delegate void ColliderEvent(Collider col);
        public delegate void RigidBodyEvent(Rigidbody rb);
    }
}
using UnityEngine;

namespace BaseStackController.StackController
{
    public class MonoBehaviourStackUnit: MonoBehaviour
    {
        private int _id;
        public int ID
        {
            get => _id;
            set => _id = value;
        }
    }
}
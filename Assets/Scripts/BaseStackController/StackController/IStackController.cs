using UnityEngine;

namespace BaseStackController.StackController
{
    public interface IStackController
    {
        public GameObject AddStack();
        public void RemoveStack();
        public void RemoveStackWithId(int id);
        public StackUnit GetLastActive();

    }
}
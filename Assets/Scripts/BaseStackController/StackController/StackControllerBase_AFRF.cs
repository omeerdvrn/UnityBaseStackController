using System.Collections.Generic;
using UnityEngine;

namespace BaseStackController.StackController
{
    public class StackControllerBase_AFRF: MonoBehaviour, IStackController//Add to Front, Remove from Front
    {
        [SerializeField] private GameObject _stackPrefab;
        [SerializeField] private Transform _stackTransform;
        private Pool<StackUnit> _stackPool = new Pool<StackUnit>();
        private List<GameObject> _activeStacks = new List<GameObject>();
        [SerializeField] private int _maxStackLimit;
        [SerializeField] private int _poolSize;
        public VoidDelegates.IntEvent onStackCountChanged;
        public VoidDelegates.GameObjectEvent onInitializedPoolObject;
        private void Awake()
        {
            var nextIndexForPoolInit = 0;
            _stackPool.Initialize(_poolSize, _stackPrefab, go =>
            {
                var stackUnit = go.GetComponent<StackUnit>();
                stackUnit.ID = nextIndexForPoolInit;
                onInitializedPoolObject?.Invoke(go);
                nextIndexForPoolInit++;
            });
        }

        public int StackCount
        {
            get => _activeStacks.Count;
        }
        
        public GameObject AddStack()
        {
            if (StackCount == _maxStackLimit)
                return null;
            
            var stack = _stackPool.GetNext();
            if (_activeStacks.Contains(stack.gameObject))
            {
                _stackPool.ExpandPool(10);
                _stackPool.UpdateNextIndex(StackCount);
                stack = _stackPool.GetNext();
            }
            _activeStacks.Add(stack.gameObject);
            
            stack.gameObject.SetActive(true);
            stack.transform.parent = _stackTransform;
            onStackCountChanged?.Invoke(StackCount);
            return stack.gameObject;
        }
        
        public void AddNumberOfStacks(int number)
        {
            for (var i = 0; i < number; i++)
            {
                AddStack();
            }
        }
        
        public void RemoveStack()
        {
            if (StackCount <= 0)
                return;
            var lastStack = GetLastActive();
           
            _activeStacks.Remove(lastStack.gameObject);
            lastStack.gameObject.SetActive(false);
            _stackPool.UpdateNextIndex(lastStack.ID);
            onStackCountChanged?.Invoke(StackCount);
        }

        public void RemoveNumberOfStacks(int number)
        {
            for (var i = 0; i < number; i++)
            {
                RemoveStack();
            }
        }

        public StackUnit GetLastActive()
        {
            return _activeStacks[StackCount - 1].GetComponent<StackUnit>();
        }
        
        public void RemoveStackWithId(int id)
        {
            var stackToRemove = _activeStacks.Find(g => g.GetComponent<StackUnit>().ID == id);
            if (stackToRemove == null) return;
            stackToRemove.SetActive(false);
            _activeStacks.Remove(stackToRemove);
        }
    }
}
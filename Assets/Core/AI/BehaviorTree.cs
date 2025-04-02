using System.Collections.Generic;
using UnityEngine;

namespace Core.AI
{
    /// <summary>
    /// This class handle a behavior tree by update it and allow to read and write on the blackboard
    /// </summary>
    public class BehaviorTree : MonoBehaviour
    {
        public TreeNode Root { get; set; }

        private bool _isLaunched;
        private Dictionary<string, float> _values = new();
        
        public void StartBehavior()
        {
            ResetTree();
            LaunchTree();
        }

        private void ResetTree()
        {
            _values.Clear();
            Root.Reset();
        }

        private void LaunchTree()
        {
            _isLaunched = true;
        }

        private void Update()
        {
            if (_isLaunched == false) return;

            TreeNodeState state = Root.Update(this, gameObject);
            if (state == TreeNodeState.Success || state == TreeNodeState.Failed)
            {
                _isLaunched = false;
            }
        }

        public void WriteBlackboard(string valueName , float value)
        {
            if (_values.TryAdd(valueName, value) == false)
            {
                _values[valueName] = value;
            }
        }

        public float ReadBlackboard(string valueName)
        {
            if (_values.TryGetValue(valueName, out float value))
            {
                return value;
            }
            
            return 0;
        }
        
        internal void SetRepeater(Repeater repeater)
        {
        }
    }
}

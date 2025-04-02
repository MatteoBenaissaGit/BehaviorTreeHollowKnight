using System.Collections.Generic;
using UnityEngine;

namespace Core.AI
{
    /// <summary>
    /// This <see cref="TreeNode"/> repeat the children until the repeat count is reached
    /// </summary>
    public class Repeater : TreeNode
    {
        public int RepeatCount { get; set; } = -1;

        private TreeNode Node => Children[0]; 
        private bool RepeatForever => RepeatCount == -1;
        
        private int _currentRepeatCount = 0;

        public Repeater()
        {
            Children = new List<TreeNode>();
        }

        protected override void ResetInternal()
        {
            _currentRepeatCount = RepeatCount;

            if (Children.Count > 1)
            {
                Debug.LogError("Repeater can only have one child, other won't be updated");
            }
        }

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            TreeNodeState state = Node.Update(tree, owner);
            if (state == TreeNodeState.Success || state == TreeNodeState.Failed)
            {
                Node.Reset();
                
                if (RepeatForever)
                {
                    return TreeNodeState.Running;
                }
                
                _currentRepeatCount--;
                if (_currentRepeatCount <= 0)
                {
                    return TreeNodeState.Success;
                }
            }
            
            return TreeNodeState.Running;
        }
    }
}

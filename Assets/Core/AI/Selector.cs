using System.Collections.Generic;
using UnityEngine;

namespace Core.AI
{
    /// <summary>
    /// This <see cref="TreeNode"/> play the children in order until one succeed or all fail
    /// </summary>
    public class Selector : TreeNode
    {
        private int _currentChildIndex;

        public Selector()
        {
            Children = new List<TreeNode>();
        }

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            if (_currentChildIndex >= Children.Count) 
            {
                return TreeNodeState.Failed; //if all children have failed, return failed
            }
            
            TreeNode childToUpdate = Children[_currentChildIndex];
            TreeNodeState childState = childToUpdate.Update(tree, owner);
            switch (childState)
            {
                case TreeNodeState.Success:
                    return TreeNodeState.Success;
                case TreeNodeState.Failed:
                    _currentChildIndex++;
                    return TreeNodeState.Running;
            }
            
            return TreeNodeState.Running;
        }

        protected override void ResetInternal()
        {
            _currentChildIndex = 0;
        }
    }
}

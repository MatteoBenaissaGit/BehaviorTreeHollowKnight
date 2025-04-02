using System.Collections.Generic;
using UnityEngine;

namespace Core.AI
{
    /// <summary>
    /// This <see cref="TreeNode"/> is a sequencer that play the children in order until one fails or all succeed 
    /// </summary>
    public class Sequence : TreeNode
    {
        private int _currentChildIndex;

        public Sequence()
        {
            Children = new List<TreeNode>();
        }

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            if (_currentChildIndex >= Children.Count) 
            {
                return TreeNodeState.Success; //if all children have succeeded, return success
            }
            
            TreeNode childToUpdate = Children[_currentChildIndex];
            TreeNodeState childState = childToUpdate.Update(tree, owner);
            
            switch (childState)
            {
                case TreeNodeState.Success:
                    _currentChildIndex++;
                    return TreeNodeState.Running;
                case TreeNodeState.Failed:
                    return TreeNodeState.Failed;
            }
            
            return TreeNodeState.Running;
        }

        protected override void ResetInternal()
        {
            _currentChildIndex = 0;
        }


    }
}

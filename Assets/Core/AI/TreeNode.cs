
using System.Collections.Generic;
using UnityEngine;

namespace Core.AI
{
    /// <summary>
    /// This class represents a node in the behavior tree
    /// </summary>
    public class TreeNode
    {
        public List<TreeNode> Children { get; set; } = new();

        public void Add(TreeNode node)
        {
            Children.Add(node);
        }


        public virtual TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            return Children[0].Update(tree, owner);
        }

        public void Reset()
        {
            ResetInternal();

            if (Children != null)
            {
                foreach (var item in Children)
                {
                    item.Reset();
                }
            }
        }

        protected virtual void ResetInternal()
        {

        }
    }

    public enum TreeNodeState
    {
        Idle,
        Success,
        Failed,
        Running
    }

}

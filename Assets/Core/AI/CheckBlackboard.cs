using UnityEngine;

namespace Core.AI
{
    /// <summary>
    /// This <see cref="TreeNode"/> allow to check a value in the blackboard
    /// </summary>
    public class CheckBlackboard : TreeNode
    {
        public int Value { get; set; }
        public string Name { get; set; }

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            if ((int)tree.ReadBlackboard(Name) == Value)
            {
                return TreeNodeState.Success;
            }
            
            return TreeNodeState.Failed;
        }
    }
}
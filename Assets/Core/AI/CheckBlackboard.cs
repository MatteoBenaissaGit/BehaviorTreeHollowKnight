using UnityEngine;

namespace Core.AI
{
    /// <summary>
    /// This <see cref="TreeNode"/> allow to check a value in the blackboard
    /// </summary>
    public class CheckBlackboard : TreeNode
    {
        public int Value ;
        public string Name;

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            if ((int)tree.ReadBlackboard(Name) == Value)
            {
                return TreeNodeState.Success;
            }
            else
            {
                return TreeNodeState.Failed;
            }
        }


    }
}
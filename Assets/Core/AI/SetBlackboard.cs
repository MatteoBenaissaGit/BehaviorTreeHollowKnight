using UnityEngine;

namespace Core.AI
{
    /// <summary>
    /// This <see cref="TreeNode"/> allow to set a value in the blackboard
    /// </summary>
    public class SetBlackboard : TreeNode
    {
        public string ValueName;
        public float Value;

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            tree.WriteBlackboard(ValueName, Value);

            return TreeNodeState.Success;
        }
    }
}
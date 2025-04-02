
using UnityEngine;

namespace Core.AI
{
    /// <summary>
    /// This <see cref="TreeNode"/> display a message in the console
    /// </summary>
    public class Log : TreeNode
    {
        public string Text { get; set; }

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            Debug.Log(Text);

            return TreeNodeState.Success;
        }
    }
}

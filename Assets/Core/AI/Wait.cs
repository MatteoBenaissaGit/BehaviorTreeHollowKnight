
using UnityEngine;

namespace Core.AI
{
    /// <summary>
    /// This <see cref="TreeNode"/> allow to wait a certain amount of time before continuing
    /// </summary>
    class Wait : TreeNode
    {
        public float Timer { get; set; }

        private float _currentTimer;

        protected override void ResetInternal()
        {
            _currentTimer = Timer;
        }

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            _currentTimer -= Time.deltaTime;
            if (_currentTimer > 0)
            {
                return TreeNodeState.Running;
            }
            return TreeNodeState.Success;
        }
    }
}

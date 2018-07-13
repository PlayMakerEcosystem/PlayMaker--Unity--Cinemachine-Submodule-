// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using Cinemachine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    [ActionCategory("Cinemachine")]
	[Tooltip("Sets the priority of a Virtual Camera")]
    public class VirtualCameraSetPriority : CinemachineActionBase<CinemachineVirtualCameraBase>
    {
        [RequiredField]
		[Tooltip("The Cinemachine virtual Camera")]
		[CheckForComponent(typeof(CinemachineVirtualCameraBase))]
        public FsmOwnerDefault gameObject;

		[Tooltip("Set the Priority of the virtual camera.\n" +
			"This determines its placement in the CinemachineCore's queue of eligible shots.")]
        public FsmInt priority;

		[Tooltip("repeat every frame, useful for animation")]
		public bool everyFrame;

        public override void Reset()
        {
            gameObject = null;
			priority = 10;
			everyFrame = false;
        }

		public override void OnEnter()
		{
			Execute();

			if (!everyFrame)
			{
				Finish();
			}
		}

		public override void OnUpdate()
		{
			Execute();
		}


        void Execute()
        {
            if (!UpdateCache(Fsm.GetOwnerDefaultTarget(gameObject)))
            {
                return;
            }

			if (!priority.IsNone)
            {
				this.cachedComponent.Priority = priority.Value;
            }
        }
    }
}
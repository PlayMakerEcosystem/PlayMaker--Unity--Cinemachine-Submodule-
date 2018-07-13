// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using Cinemachine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    [ActionCategory("Cinemachine")]
	[Tooltip("Gets the look at target of a Virtual Camera")]
    public class VirtualCameraGetLookAtTarget : CinemachineActionBase<CinemachineVirtualCameraBase>
    {
        [RequiredField]
		[Tooltip("The Cinemachine virtual Camera")]
		[CheckForComponent(typeof(CinemachineVirtualCameraBase))]
        public FsmOwnerDefault gameObject;

		[Tooltip("The Look at target")]
		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmGameObject lookat;

        public override void Reset()
        {
            gameObject = null;
			lookat = null;
        }

		public override void OnEnter()
		{
			Execute();

			Finish();

		}

        void Execute()
        {
            if (!UpdateCache(Fsm.GetOwnerDefaultTarget(gameObject)))
            {
                return;
            }
				
			lookat.Value = this.cachedComponent.LookAt ? this.cachedComponent.Follow.gameObject : null;
            
        }
    }
}
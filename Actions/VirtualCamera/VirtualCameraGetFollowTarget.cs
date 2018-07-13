// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using Cinemachine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    [ActionCategory("Cinemachine")]
	[Tooltip("Gets the follow target of a Virtual Camera")]
    public class VirtualCameraGetFollowTarget : CinemachineActionBase<CinemachineVirtualCameraBase>
    {
        [RequiredField]
		[Tooltip("The Cinemachine virtual Camera")]
		[CheckForComponent(typeof(CinemachineVirtualCameraBase))]
        public FsmOwnerDefault gameObject;

		[Tooltip("The Follow target")]
		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmGameObject follow;

        public override void Reset()
        {
            gameObject = null;
			follow = null;
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
  
			follow.Value = this.cachedComponent.Follow?this.cachedComponent.Follow.gameObject:null;
            
        }
    }
}
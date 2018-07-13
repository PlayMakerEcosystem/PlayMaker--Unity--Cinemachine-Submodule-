// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using UnityEngine;
using Cinemachine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    [ActionCategory("Cinemachine")]
	[Tooltip("Sets the follow target of a Virtual Camera")]
	public class VirtualCameraSetFollowTarget : ComponentAction<CinemachineVirtualCameraBase>
    {
        [RequiredField]
		[Tooltip("The Cinemachine virtual Camera")]
		[CheckForComponent(typeof(CinemachineVirtualCameraBase))]
        public FsmOwnerDefault gameObject;

		[Tooltip("The Follow target")]
		public FsmOwnerDefault follow;

		GameObject _target;

        public override void Reset()
        {
            gameObject = null;
			follow = new FsmOwnerDefault(){OwnerOption= OwnerDefaultOption.SpecifyGameObject};
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
				
			_target = Fsm.GetOwnerDefaultTarget (follow);

			this.cachedComponent.Follow = _target?_target.transform:null;
            
        }
    }
}
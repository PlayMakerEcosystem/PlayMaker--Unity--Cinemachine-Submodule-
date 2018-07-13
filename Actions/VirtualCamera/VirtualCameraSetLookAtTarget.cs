// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using UnityEngine;
using Cinemachine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    [ActionCategory("Cinemachine")]
	[Tooltip("Sets the look at target of a Virtual Camera")]
    public class VirtualCameraSetLookAtTarget : CinemachineActionBase<CinemachineVirtualCameraBase>
    {
        [RequiredField]
		[Tooltip("The Cinemachine virtual Camera")]
		[CheckForComponent(typeof(CinemachineVirtualCameraBase))]
        public FsmOwnerDefault gameObject;

		[Tooltip("The Look at target")]
		public FsmOwnerDefault lookat;

		GameObject _target;

        public override void Reset()
        {
            gameObject = null;
			lookat = new FsmOwnerDefault(){OwnerOption= OwnerDefaultOption.SpecifyGameObject};
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
				
			_target = Fsm.GetOwnerDefaultTarget (lookat);

			this.cachedComponent.LookAt = _target?_target.transform:null;
            
        }
    }
}
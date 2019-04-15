// (c) Copyright HutongGames, LLC 2010-2019. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using Cinemachine;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    [ActionCategory("Cinemachine")]
	[Tooltip("Invalidate the PathCache of a Confiner Virtual Camera extension")]
    public class ConfinerInvalidatePathCache : CinemachineActionBase<CinemachineConfiner>
    {
        [RequiredField]
		[Tooltip("The Cinemachine Confiner Extension")]
        [CheckForComponent(typeof(CinemachineConfiner))]
        public FsmOwnerDefault gameObject;


        public override void Reset()
        {
            gameObject = null;
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

   
            this.cachedComponent.InvalidatePathCache();
        }
    }
}
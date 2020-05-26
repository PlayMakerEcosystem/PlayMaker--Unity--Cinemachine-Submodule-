// (c) Copyright HutongGames, LLC 2010-2020. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using Cinemachine;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    [ActionCategory("Cinemachine")]
	[Tooltip("Sets the horizontal axis settings of the POV aimed component of a virtual Camera")]
    public class VirtualCameraAimPovSetXaxisSettings : CinemachineActionSetAxisSettingsBase<CinemachineVirtualCamera,CinemachinePOV>
    {
        [RequiredField]
		[Tooltip("The Cinemachine Virtual Camera")]
        [CheckForComponent(typeof(CinemachineVirtualCamera))]
        public FsmOwnerDefault gameObject;
        
		[Tooltip("repeat every frame, useful for animation")]
		public bool everyFrame;

		
		public VirtualCameraAimPovSetXaxisSettings()
		{
			this.FeaturesRecentering = true;
		}

		public override void Reset()
        {   
            base.Reset();
            
            gameObject = null;
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
            
            if (!UpdateCinemachineComponent(Fsm.GetOwnerDefaultTarget(gameObject)))
            {
	            return;
            }
            
            this.SetAxisSettings(ref cachedCinemachineComponent.m_HorizontalAxis);
            
            if (!RecenteringEnabled.IsNone)
            {
	            cachedCinemachineComponent.m_HorizontalRecentering.m_enabled = RecenteringEnabled.Value;
            }   
            
            
            if (!RecenteringWaitTime.IsNone)
            {
	            cachedCinemachineComponent.m_HorizontalRecentering.m_WaitTime = RecenteringWaitTime.Value;
            }  
            
            if (!RecenteringTime.IsNone)
            {
	            cachedCinemachineComponent.m_HorizontalRecentering.m_RecenteringTime = RecenteringTime.Value;
            }
        }
    }
}
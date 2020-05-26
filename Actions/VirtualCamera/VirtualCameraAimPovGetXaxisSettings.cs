// (c) Copyright HutongGames, LLC 2010-2020. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using Cinemachine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    [ActionCategory("Cinemachine")]
    [Tooltip("Gets the horizontal axis settings of the POV aimed component of a virtual Camera")]
    public class VirtualCameraAimPovGetXaxisSettings : CinemachineActionGetAxisSettingsBase<CinemachineVirtualCamera,CinemachinePOV>
    {
        [RequiredField]
		[Tooltip("The Cinemachine FreeLook Camera")]
        [CheckForComponent(typeof(CinemachineVirtualCamera))]
        public FsmOwnerDefault gameObject;

		[Tooltip("repeat every frame, useful for animation")]
		public bool everyFrame;

		public VirtualCameraAimPovGetXaxisSettings()
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
            
	        this.GetAxisSettings(ref cachedCinemachineComponent.m_HorizontalAxis);
	        
	        if (!RecenteringEnabled.IsNone)
	        {
		        RecenteringEnabled.Value = cachedCinemachineComponent.m_HorizontalRecentering.m_enabled;
	        }   
            
	        if (!RecenteringWaitTime.IsNone)
	        {
		        RecenteringWaitTime.Value = cachedCinemachineComponent.m_HorizontalRecentering.m_WaitTime;
	        }  
            
	        if (!RecenteringTime.IsNone)
	        {
		        RecenteringTime.Value = cachedCinemachineComponent.m_HorizontalRecentering.m_RecenteringTime;
	        }
        }
    }
}
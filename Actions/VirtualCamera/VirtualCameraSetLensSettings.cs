// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using Cinemachine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    [ActionCategory("Cinemachine")]
	[Tooltip("Sets the lens settings of a Virtual Camera")]
    public class VirtualCameraSetLensSettings : CinemachineActionSetLensSettingsBase<CinemachineVirtualCamera>
    {
        [RequiredField]
		[Tooltip("The Cinemachine virtual Camera")]
        [CheckForComponent(typeof(CinemachineVirtualCamera))]
        public FsmOwnerDefault gameObject;


		[Tooltip("repeat every frame, useful for animation")]
		public bool everyFrame;

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

            this.SetLensSettings(ref this.cachedComponent.m_Lens);

        }
    }
}
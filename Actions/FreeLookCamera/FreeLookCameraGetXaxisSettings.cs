// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using Cinemachine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    [ActionCategory("Cinemachine")]
    [Tooltip("Gets the X Axis settings of a FreeLook Camera")]
    public class FreeLookCameraGetXaxisSettings : CinemachineActionGetAxisSettingsBase<CinemachineFreeLook>
    {
        [RequiredField]
		[Tooltip("The Cinemachine FreeLook Camera")]
        [CheckForComponent(typeof(CinemachineFreeLook))]
        public FsmOwnerDefault gameObject;

		[Tooltip("repeat every frame, useful for animation")]
		public bool everyFrame;


		public FreeLookCameraGetXaxisSettings()
		{
			this.FeaturesRecentering = false;
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

            this.GetAxisSettings(ref this.cachedComponent.m_XAxis);

        }
    }
}
// (c) Copyright HutongGames, LLC 2010-2019. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    [ActionCategory("Cinemachine")]
    [Tooltip("Sets enable flag for Core Input of a CinemachineCoreGetInputTouchAxis Component")]
    public class EnableCoreInput : CinemachineActionBase<CinemachineCoreGetInputTouchAxis>
    {
        [RequiredField]
		[Tooltip("The Cinemachine core Input touch axis")]
        [CheckForComponent(typeof(CinemachineCoreGetInputTouchAxis))]
        public FsmOwnerDefault gameObject;

        [Tooltip("Flag to allow core Input processing")]
        public FsmBool inputEnabled;
        
		[Tooltip("repeat every frame, useful for animation")]
		public bool everyFrame;

        public override void Reset()
        {
            gameObject = null;

            inputEnabled = null;

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
            this.cachedComponent.InputEnabled = inputEnabled.Value;
        }
    }
}
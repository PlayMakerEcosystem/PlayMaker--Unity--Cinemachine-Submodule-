// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using Cinemachine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    [ActionCategory("Cinemachine")]
	[Tooltip("Sets the properties of a ImpulseListener Virtual Camera extension")]
    public class ImpulseListenerSetProperties : CinemachineActionBase<CinemachineImpulseListener>
    {
        [RequiredField]
		[Tooltip("The Cinemachine Impulse Listener Extension")]
        [CheckForComponent(typeof(CinemachineImpulseListener))]
        public FsmOwnerDefault gameObject;

		[Tooltip("Gain to apply to the Impulse signal.  1 is normal strength.  Setting this to 0 completely mutes the signal.")]
        public FsmFloat gain;

        [Tooltip("Enable this to perform distance calculation in 2D (ignore Z)")]
        public FsmBool use2dDistance;

        [Tooltip("repeat every frame, useful for animation")]
        public bool everyFrame;

        public override void Reset()
        {
            gameObject = null;
            gain = new FsmFloat() {UseVariable = true,Value = 1f};
            use2dDistance = null;

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

            if (!gain.IsNone)
            {
                this.cachedComponent.m_Gain = gain.Value;
            }

            if (!use2dDistance.IsNone)
            {
                this.cachedComponent.m_Use2DDistance = use2dDistance.Value;
            }
        }
    }
}
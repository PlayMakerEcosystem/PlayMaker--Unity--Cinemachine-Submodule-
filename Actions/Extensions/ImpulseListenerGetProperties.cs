// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using Cinemachine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    [ActionCategory("Cinemachine")]
	[Tooltip("Gets the properties of a ImpulseListener Virtual Camera extension")]
    public class ImpulseListenerGetProperties : CinemachineActionBase<CinemachineImpulseListener>
    {
        [RequiredField]
		[Tooltip("The Cinemachine Impulse Listener Extension")]
        [CheckForComponent(typeof(CinemachineImpulseListener))]
        public FsmOwnerDefault gameObject;

        [UIHint(UIHint.Variable)]
        [Tooltip("Gain to apply to the Impulse signal")]
        public FsmFloat gain;

        [UIHint(UIHint.Variable)]
        [Tooltip("If true, perform distance calculation in 2D (ignore Z)")]
        public FsmBool use2dDistance;

        [Tooltip("Repeat every frame")]
        public bool everyFrame;

        public override void Reset()
        {
            gameObject = null;
            gain = null;
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
                gain.Value = this.cachedComponent.m_Gain;
            }

            if (!use2dDistance.IsNone)
            {
                use2dDistance.Value = this.cachedComponent.m_Use2DDistance;
            }
        }
    }
}
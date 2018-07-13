// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using Cinemachine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    [ActionCategory("Cinemachine")]
	[Tooltip("Gets the properties of a FollowZoom Virtual Camera extension")]
    public class FollowZoomGetProperties : CinemachineActionBase<CinemachineFollowZoom>
    {
        [RequiredField]
        [CheckForComponent(typeof(CinemachineFollowZoom))]
		[Tooltip("The Cinemachine Follow zoom Extension")]
        public FsmOwnerDefault gameObject;

		[UIHint(UIHint.Variable)]
		[Tooltip("The shot width to maintain, in world units, at target distance.\n" +
                 "FOV will be adusted as far as possible to maintain this width at the" +
                 "target distance from the camera.")]
        public FsmFloat width;

		[UIHint(UIHint.Variable)]
		[Tooltip("Increase this value to soften the aggressiveness of the follow-zoom.\n" +
                 "Small numbers are more responsive, larger numbers give a more heavy slowly responding camera. ")]
        public FsmFloat damping;

		[UIHint(UIHint.Variable)]
        [Tooltip("Will not generate an FOV smaller than this. Range from 1 to 179 degrees")]
        public FsmFloat minFOV;

		[UIHint(UIHint.Variable)]
        [Tooltip("Will not generate an FOV larget than this.Range from 1 to 179 degrees")]
        public FsmFloat maxFOV;

       
        [Tooltip("repeat every frame, useful for animation")]
        public bool everyFrame;

        public override void Reset()
        {
            gameObject = null;
			width = null;
			minFOV = null;
			maxFOV = null;
            damping = null;
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

            if (!width.IsNone)
            {
				width.Value = this.cachedComponent.m_Width;
            }

            if (!minFOV.IsNone)
            {
				minFOV.Value = this.cachedComponent.m_MinFOV;
            }

            if (!maxFOV.IsNone)
            {
				maxFOV.Value = this.cachedComponent.m_MaxFOV;
            }

            if (!damping.IsNone)
            {
				damping.Value = this.cachedComponent.m_Damping;
            }


        }
    }
}
// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using Cinemachine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    [ActionCategory("Cinemachine")]
	[Tooltip("Sets the properties of a FollowZoom Virtual Camera extension")]
    public class FollowZoomSetProperties : CinemachineActionBase<CinemachineFollowZoom>
    {
        [RequiredField]
		[Tooltip("The Cinemachine Follow Zoom Extension")]
        [CheckForComponent(typeof(CinemachineFollowZoom))]
        public FsmOwnerDefault gameObject;

		[Tooltip("The shot width to maintain, in world units, at target distance.\n" +
                 "FOV will be adusted as far as possible to maintain this width at the" +
                 "target distance from the camera.")]
        public FsmFloat width;

		[Tooltip("Increase this value to soften the aggressiveness of the follow-zoom.\n" +
                 "Small numbers are more responsive, larger numbers give a more heavy slowly responding camera. ")]
        public FsmFloat damping;

        [Tooltip("Will not generate an FOV smaller than this. Range from 1 to 179 degrees")]
        public FsmFloat minFOV;

        [Tooltip("Will not generate an FOV larget than this.Range from 1 to 179 degrees")]
        public FsmFloat maxFOV;

       
        [Tooltip("repeat every frame, useful for animation")]
        public bool everyFrame;

        public override void Reset()
        {
            gameObject = null;
            width = new FsmFloat() {UseVariable = true,Value = 2f};
            minFOV = new FsmFloat() {Value = 1f, UseVariable = true };
            maxFOV = new FsmFloat() {Value = 179f, UseVariable = true };
            damping = new FsmFloat() {Value = 1f, UseVariable = true };
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
                this.cachedComponent.m_Width = width.Value;
            }

            if (!minFOV.IsNone)
            {
                this.cachedComponent.m_MinFOV = minFOV.Value;
            }

            if (!maxFOV.IsNone)
            {
                this.cachedComponent.m_MaxFOV = maxFOV.Value;
            }

            if (!damping.IsNone)
            {
                this.cachedComponent.m_Damping = damping.Value;
            }


        }
    }
}
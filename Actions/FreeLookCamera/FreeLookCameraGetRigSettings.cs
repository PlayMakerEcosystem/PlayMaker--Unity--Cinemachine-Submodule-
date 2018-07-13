// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using System;
using Cinemachine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    [ActionCategory("Cinemachine")]
	[Tooltip("Gets the rig properties of a FreeLook Camera")]
	public class FreeLookCameraGetRigSettings : CinemachineActionBase<CinemachineFreeLook>
    {
        [RequiredField]
		[Tooltip("The Cinemachine FreeLook Camera")]
        [CheckForComponent(typeof(CinemachineFreeLook))]
        public FsmOwnerDefault gameObject;

		[Tooltip("the Spline Curvature between the three rigs")]
		[UIHint(UIHint.Variable)]
		public FsmFloat SplineCurvature;
	
		[Tooltip("The Top Rig")]
		public RigDataGetter TopRig;

		[Tooltip("The Middle Rig")]
		public RigDataGetter MiddleRig;

		[Tooltip("The Bottom Rig")]
		public RigDataGetter BottomRig;

		[Tooltip("repeat every frame, useful for animation")]
		public bool everyFrame;

        public override void Reset()
        {   
            base.Reset();

			gameObject = null;

			SplineCurvature = new FsmFloat(){UseVariable=true};

			TopRig = new RigDataGetter ();
			MiddleRig = new RigDataGetter ();
			BottomRig = new RigDataGetter ();

            
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

			if (!SplineCurvature.IsNone) {
				SplineCurvature.Value = this.cachedComponent.m_SplineCurvature;
			}


			if (!TopRig.Height.IsNone) {
				TopRig.Height.Value = this.cachedComponent.m_Orbits [0].m_Height;
			}
			if (!TopRig.Radius.IsNone) {
				TopRig.Radius.Value = this.cachedComponent.m_Orbits [0].m_Radius;
			}

			if (!MiddleRig.Height.IsNone) {
				MiddleRig.Height.Value = this.cachedComponent.m_Orbits [1].m_Height;
			}
			if (!MiddleRig.Radius.IsNone) {
				MiddleRig.Radius.Value = this.cachedComponent.m_Orbits [1].m_Radius;
			}

			if (!BottomRig.Height.IsNone) {
				BottomRig.Height.Value = this.cachedComponent.m_Orbits [2].m_Height;
			}
			if (!BottomRig.Radius.IsNone) {
				BottomRig.Radius.Value = this.cachedComponent.m_Orbits [2].m_Radius;
			}

        }
    }


	[Serializable]
	public class RigDataGetter{

		[Tooltip("The height of the rig")]
		[UIHint(UIHint.Variable)]
		public FsmFloat Height = null;

		[Tooltip("The Radius of the rig")]
		[UIHint(UIHint.Variable)]
		public FsmFloat Radius = null;
	}
}
// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using System;
using Cinemachine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    [ActionCategory("Cinemachine")]
	[Tooltip("Sets the rig properties of a FreeLook Camera")]
	public class FreeLookCameraSetRigSettings : CinemachineActionBase<CinemachineFreeLook>
    {
        [RequiredField]
		[Tooltip("The Cinemachine FreeLook Camera")]
        [CheckForComponent(typeof(CinemachineFreeLook))]
        public FsmOwnerDefault gameObject;

		[Tooltip("the Spline Curvature between the three rigs")]
		public FsmFloat SplineCurvature;
	
		[Tooltip("The Top Rig")]
		public RigData TopRig;

		[Tooltip("The Middle Rig")]
		public RigData MiddleRig;

		[Tooltip("The Bottom Rig")]
		public RigData BottomRig;

		[Tooltip("repeat every frame, useful for animation")]
		public bool everyFrame;

        public override void Reset()
        {   
            base.Reset();

			gameObject = null;

			SplineCurvature = new FsmFloat(){UseVariable=true};

			TopRig = new RigData ();
			MiddleRig = new RigData ();
			BottomRig = new RigData ();

            
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
				this.cachedComponent.m_SplineCurvature = SplineCurvature.Value;
			}


			if (!TopRig.Height.IsNone) {
				this.cachedComponent.m_Orbits [0].m_Height = TopRig.Height.Value;
			}
			if (!TopRig.Radius.IsNone) {
				this.cachedComponent.m_Orbits [0].m_Radius = TopRig.Radius.Value;
			}

			if (!MiddleRig.Height.IsNone) {
				this.cachedComponent.m_Orbits [1].m_Height = MiddleRig.Height.Value;
			}
			if (!MiddleRig.Radius.IsNone) {
				this.cachedComponent.m_Orbits [1].m_Radius = MiddleRig.Radius.Value;
			}

			if (!BottomRig.Height.IsNone) {
				this.cachedComponent.m_Orbits [2].m_Height = BottomRig.Height.Value;
			}
			if (!BottomRig.Radius.IsNone) {
				this.cachedComponent.m_Orbits [2].m_Radius = BottomRig.Radius.Value;
			}

        }
    }


	[Serializable]
	public class RigData{

		[Tooltip("The height of the rig")]
		public FsmFloat Height = new FsmFloat(){UseVariable=true};

		[Tooltip("The Radius of the rig")]
		public FsmFloat Radius = new FsmFloat(){UseVariable=true};
	}
}
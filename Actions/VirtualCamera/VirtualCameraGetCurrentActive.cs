// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using Cinemachine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    [ActionCategory("Cinemachine")]
	[Tooltip("Gets the current active Virtual Camera. Requires CinemachineBrainProxy component to be in the scene")]
    public class VirtualCameraGetCurrentActive : CinemachineActionBase<CinemachineVirtualCameraBase>
    {

	    [Tooltip("The current Active Virtual Camera")]
		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmGameObject activeVirtualCamera;

		[Tooltip("Repeat every frame")]
		public bool everyFrame;
		
		public override void Reset()
		{
			everyFrame = false;
	        activeVirtualCamera = null;
        }

		public override void OnEnter()
		{
			if (CinemachineBrainProxy.Brain == null)
			{
				LogError("VirtualCameraGetCurrentActive action requires a CinemachineBrainProxy component in scene, or missing Cinemachine Brain in Scene");	
			}
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
	        if (CinemachineBrainProxy.Brain != null && CinemachineBrainProxy.Brain.ActiveVirtualCamera != null)
	        {
		        activeVirtualCamera.Value = CinemachineBrainProxy.Brain.ActiveVirtualCamera.VirtualCameraGameObject;
	        }
	        else
	        {
		        activeVirtualCamera.Value = null;
	        }
        }
    }
}
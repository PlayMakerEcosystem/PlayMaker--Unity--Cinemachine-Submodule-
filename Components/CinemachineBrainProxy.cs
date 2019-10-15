// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using UnityEngine;
using Cinemachine;

using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions.ecosystem.cinemachine;

/// <summary>
/// This Component listen to m_CameraActivatedEvent and m_CameraCutEvent CinemachineBrain unity events and broadcast PlayMaker Events
/// 
/// CINEMACHINE / ON CAMERA ACTIVATED
/// Event data GameObject will reference the ICinemachineCamera.VirtualCameraGameObject
/// 
/// CINEMACHINE / ON CAMERA CUT
/// Event data GameObject will reference the CinemachineBrain.gameObject
/// 
/// </summary>
[RequireComponent(typeof(CinemachineBrain))]
public class CinemachineBrainProxy : MonoBehaviour {

	public static CinemachineBrain Brain;

	// Use this for initialization
	void Start () {
		
		Brain = this.GetComponent<CinemachineBrain> ();
		if (Brain != null) {
			Brain.m_CameraActivatedEvent.AddListener(HandleCameraActivatedAction);
			Brain.m_CameraCutEvent.AddListener(HandleCameraCutEventAction);
		}
	}


    void HandleCameraActivatedAction(ICinemachineCamera arg0, ICinemachineCamera arg1)
    {
        Fsm.EventData.GameObjectData = arg0.VirtualCameraGameObject ;
        CinemachineGetCameraActivateEventInfo.ActivatedCamera = arg0.VirtualCameraGameObject;
        CinemachineGetCameraActivateEventInfo.PreviousCamera = arg1!=null?arg1.VirtualCameraGameObject:null;

        PlayMakerFSM.BroadcastEvent("CINEMACHINE / ON CAMERA ACTIVATED");
    }

    void HandleCameraCutEventAction(CinemachineBrain arg0)
    {
        Fsm.EventData.GameObjectData = arg0.gameObject;

        PlayMakerFSM.BroadcastEvent("CINEMACHINE / ON CAMERA CUT");
    }
}

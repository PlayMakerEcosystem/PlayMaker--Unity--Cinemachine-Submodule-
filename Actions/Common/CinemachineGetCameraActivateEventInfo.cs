// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using UnityEngine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    [ActionCategory("Cinemachine")]
    [Tooltip("Gets info on the last Camera Activate event that caused a state change.")]
    public class CinemachineGetCameraActivateEventInfo : FsmStateAction
    {

        public static GameObject ActivatedCamera,PreviousCamera;

        [UIHint(UIHint.Variable)]
        [Tooltip("The new activated Camera")]
        public FsmGameObject activatedCamera;

        [UIHint(UIHint.Variable)]
        [Tooltip("The previously activated Camera")]
        public FsmGameObject previousCamera;

        public override void Reset()
        {
            activatedCamera = null;
            previousCamera = null;
        }

        public override void OnEnter()
        {

            activatedCamera.Value = ActivatedCamera;
            activatedCamera.Value = PreviousCamera;

            Finish();
        }
    }
}
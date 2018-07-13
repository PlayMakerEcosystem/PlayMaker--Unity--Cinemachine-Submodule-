// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License


using Cinemachine;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    // Base class for cinemachine actions which gets cameras with lens settings
    public abstract class CinemachineActionGetLensSettingsBase<T>: CinemachineActionBase<T> where T : Component
    {
        [Tooltip("This is the camera view in vertical degrees. For cinematic people, a 50mm lens on a super-35mm sensor would equal a 19.6 degree FOV\n" +
                 "Leave to none for no effect")]
        [DisplayOrder(1)]
        [UIHint(UIHint.Variable)]
        public FsmFloat FieldOfView;

        [Tooltip("When using an orthographic camera, this defines the half-height, in world coordinates, of the camera view.\n" +
                 "Leave to none for no effect")]
        [DisplayOrder(2)]
        [UIHint(UIHint.Variable)]
        public FsmFloat OrthographicSize;

        [Tooltip("This defines the near region in the renderable range of the camera frustum. Raising this value will stop the game from drawing things near the camera, which can sometimes come in handy.  Larger values will also increase your shadow resolution.\n" +
                 "Leave to none for no effect")]
        [DisplayOrder(3)]
        [UIHint(UIHint.Variable)]
        public FsmFloat NearClipPlane;

        [Tooltip("This defines the far region of the renderable range of the camera frustum. Typically you want to set this value as low as possible without cutting off desired distant objects\n" +
                 "Leave to none for no effect")]
        [DisplayOrder(4)]
        [UIHint(UIHint.Variable)]
        public FsmFloat FarClipPlane;

        [Range(-180f, 180f)]
        [Tooltip("Camera Z roll, or tilt, in degrees.\n" +
                 "Leave to none for no effect")]
        [DisplayOrder(5)]
        [UIHint(UIHint.Variable)]
        public FsmFloat Dutch;


        public override void Reset()
        {
            base.Reset();
            FieldOfView = null;
            OrthographicSize = null;
            NearClipPlane = null;
            FarClipPlane = null;
            Dutch = null;
        }

        protected void GetLensSettings(ref LensSettings lensSettings)
        {
            if (!FieldOfView.IsNone)
            {
                FieldOfView.Value = lensSettings.FieldOfView;
            }

            if (!OrthographicSize.IsNone)
            {
                OrthographicSize.Value = lensSettings.OrthographicSize;
            }

            if (!NearClipPlane.IsNone)
            {
                NearClipPlane.Value = lensSettings.NearClipPlane;
            }

            if (!FarClipPlane.IsNone)
            {
                FarClipPlane.Value = lensSettings.FarClipPlane;
            }

            if (!Dutch.IsNone)
            {
                Dutch.Value = lensSettings.Dutch;
            }

        }
    }
}
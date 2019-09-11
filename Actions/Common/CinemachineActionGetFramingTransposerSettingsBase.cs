// (c) Copyright HutongGames, LLC 2010-2019. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using Cinemachine;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    // Base class for cinemachine actions which sets cameras with Framing Transposer settings
    public abstract class CinemachineActionGetFramingTransposerSettingsBase<T>: CinemachineActionBase<T> where T : Component
    {
        [DisplayOrder(1)]
        [UIHint(UIHint.Variable)]
        [Tooltip("This setting will instruct the composer to adjust its target offset based on the motion of the target.  The composer will look at a point where it estimates the target will be this many seconds into the future.  Note that this setting is sensitive to noisy animation, and can amplify the noise, resulting in undesirable camera jitter.  If the camera jitters unacceptably when the target is in motion, turn down this setting, or animate the target more smoothly.")]
        public FsmFloat LookAheadTime;

        [DisplayOrder(1)]
        [UIHint(UIHint.Variable)]
        [Tooltip("Controls the smoothness of the lookahead algorithm.  Larger values smooth out jittery predictions and also increase prediction lag")]
        public FsmFloat LookAheadSmoothing;

        [DisplayOrder(1)]
        [UIHint(UIHint.Variable)]
        [Tooltip("Sets the Look Ahead Ignore Y flag")]
        public FsmBool LookaheadIgnoreY;
        
        
        [DisplayOrder(1)]
        [UIHint(UIHint.Variable)]
        [Tooltip("How aggressively the camera tries to maintain the offset in the X-axis.  Small numbers are more responsive, rapidly translating the camera to keep the target's x-axis offset.  Larger numbers give a more heavy slowly responding camera. Using different settings per axis can yield a wide range of camera behaviors.")]
        public FsmFloat xDamping;
        
        [DisplayOrder(1)]
        [UIHint(UIHint.Variable)]
        [Tooltip("How aggressively the camera tries to maintain the offset in the Y-axis.  Small numbers are more responsive, rapidly translating the camera to keep the target's y-axis offset.  Larger numbers give a more heavy slowly responding camera. Using different settings per axis can yield a wide range of camera behaviors.")]
        public FsmFloat yDamping;
        
        [DisplayOrder(1)]
        [UIHint(UIHint.Variable)]
        [Tooltip("How aggressively the camera tries to maintain the offset in the Z-axis.  Small numbers are more responsive, rapidly translating the camera to keep the target's z-axis offset.  Larger numbers give a more heavy slowly responding camera. Using different settings per axis can yield a wide range of camera behaviors.")]
        public FsmFloat zDamping;
        
        [DisplayOrder(1)]
        [UIHint(UIHint.Variable)]
        [Tooltip("Horizontal screen position for target. The camera will move to position the tracked object here.")]
        public FsmFloat ScreenX;
        
        [DisplayOrder(1)]
        [UIHint(UIHint.Variable)]
        [Tooltip("Vertical screen position for target, The camera will move to position the tracked object here.")]
        public FsmFloat ScreenY;
        
        [DisplayOrder(1)]
        [UIHint(UIHint.Variable)]
        [Tooltip("The distance along the camera axis that will be maintained from the Follow target")]
        public FsmFloat CameraDistance;
        
        [DisplayOrder(1)]
        [UIHint(UIHint.Variable)]
        [Tooltip("Camera will not move horizontally if the target is within this range of the position.")]
        public FsmFloat DeadZoneWidth;
        
        [DisplayOrder(1)]
        [UIHint(UIHint.Variable)]
        [Tooltip("Camera will not move vertically if the target is within this range of the position.")]
        public FsmFloat DeadZoneHeight;
        
        [DisplayOrder(1)]
        [UIHint(UIHint.Variable)]
        [Tooltip("The camera will not move along its z-axis if the Follow target is within this distance of the specified camera distance")]
        public FsmFloat DeadZoneDepth;
 
        [DisplayOrder(1)]
        [UIHint(UIHint.Variable)]
        [Tooltip("If checked, then then soft zone will be unlimited in size.")]
        public FsmBool UnlimitedSoftZone;
        
        [DisplayOrder(1)]
        [UIHint(UIHint.Variable)]
        [Tooltip("When target is within this region, camera will gradually move horizontally to re-align towards the desired position, depending on the damping speed.")]
        public FsmFloat SoftZoneWidth;
        
        [DisplayOrder(1)]
        [UIHint(UIHint.Variable)]
        [Tooltip("When target is within this region, camera will gradually move vertically to re-align towards the desired position, depending on the damping speed.")]
        public FsmFloat SoftZoneHeight;
        
        [DisplayOrder(1)]
        [UIHint(UIHint.Variable)]
        [Tooltip("A non-zero bias will move the target position horizontally away from the center of the soft zone.")]
        public FsmFloat BiasX;
        
        [DisplayOrder(1)]
        [UIHint(UIHint.Variable)]
        [Tooltip("A non-zero bias will move the target position vertically away from the center of the soft zone.")]
        public FsmFloat BiasY;
        
        [DisplayOrder(1)]
        [UIHint(UIHint.Variable)]
        [Tooltip("Force target to center of screen when this camera activates.  If false, will clamp target to the edges of the dead zone")]
        public FsmBool CenterOnActivate;
        
        protected CinemachineFramingTransposer CachedCinemachineComponent;
        
        public override void Reset()
        {
            base.Reset();

            LookAheadTime = null;
            LookAheadSmoothing = null;
            LookaheadIgnoreY = null;
            
            xDamping = null;
            yDamping = null;
            zDamping = null;
            
            ScreenX = null;
            ScreenY = null;
            
            CameraDistance = null;
            
            DeadZoneWidth = null;
            DeadZoneHeight = null;
            DeadZoneDepth = null;
            
            UnlimitedSoftZone = null;
            SoftZoneWidth = null;
            SoftZoneHeight = null;
            BiasX = null;
            BiasY = null;
            CenterOnActivate = null;
            
        }

        protected void GetFramingTransposerSettings(ref CinemachineFramingTransposer target)
        {
            if (!LookAheadTime.IsNone) LookAheadTime.Value = target.m_LookaheadTime;
            if (!LookAheadSmoothing.IsNone) LookAheadSmoothing.Value = target.m_LookaheadSmoothing;
            if (!LookaheadIgnoreY.IsNone) LookaheadIgnoreY.Value = target.m_LookaheadIgnoreY;
            
            if (!xDamping.IsNone) xDamping.Value = target.m_XDamping;
            if (!yDamping.IsNone) xDamping.Value = target.m_XDamping;
            if (!zDamping.IsNone) xDamping.Value = target.m_XDamping;
            
            if (!ScreenX.IsNone) ScreenX.Value = target.m_ScreenX;
            if (!ScreenY.IsNone) ScreenY.Value = target.m_ScreenY;
            
            if (!CameraDistance.IsNone) CameraDistance.Value = target.m_CameraDistance;
            
            if (!DeadZoneWidth.IsNone) DeadZoneWidth.Value = target.m_DeadZoneWidth;
            if (!DeadZoneHeight.IsNone) DeadZoneHeight.Value = target.m_DeadZoneHeight;
            if (!DeadZoneDepth.IsNone) DeadZoneDepth.Value = target.m_DeadZoneDepth;
            
            if (!UnlimitedSoftZone.IsNone) UnlimitedSoftZone.Value = target.m_UnlimitedSoftZone;
            if (!SoftZoneWidth.IsNone) SoftZoneWidth.Value = target.m_SoftZoneWidth;
            if (!SoftZoneHeight.IsNone) SoftZoneHeight.Value = target.m_SoftZoneHeight;
            if (!BiasX.IsNone) BiasX.Value = target.m_BiasX;
            if (!BiasX.IsNone) BiasX.Value = target.m_BiasY;
            
            if (!CenterOnActivate.IsNone) CenterOnActivate.Value = target.m_CenterOnActivate;
        }
        
        public bool UpdateCinemachineComponentCache(GameObject go)
        {
            if (! UpdateCache(go)) return false;
            
            if (CachedCinemachineComponent == null || cachedGameObject != go)
            {
                CachedCinemachineComponent = (cachedComponent as CinemachineVirtualCamera).GetCinemachineComponent<CinemachineFramingTransposer>();

                if (CachedCinemachineComponent == null)
                {
                    LogWarning("Missing component: " + typeof(CinemachineFramingTransposer).FullName + " on: " + go.name);
                }
            }

            return CachedCinemachineComponent != null;
        }

        
    }
}
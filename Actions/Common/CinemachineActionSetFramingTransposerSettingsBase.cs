// (c) Copyright HutongGames, LLC 2010-2019. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using Cinemachine;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    // Base class for cinemachine actions which sets cameras with Framing Transposer settings
    public abstract class CinemachineActionSetFramingTransposerSettingsBase<T>: CinemachineActionBase<T> where T : Component
    {
        [DisplayOrder(1)]
        [HasFloatSlider(0f,1f)]
        [Tooltip("This setting will instruct the composer to adjust its target offset based on the motion of the target.  The composer will look at a point where it estimates the target will be this many seconds into the future.  Note that this setting is sensitive to noisy animation, and can amplify the noise, resulting in undesirable camera jitter.  If the camera jitters unacceptably when the target is in motion, turn down this setting, or animate the target more smoothly.")]
        public FsmFloat LookAheadTime;

        [DisplayOrder(1)]
        [HasFloatSlider(3f,30f)]
        [Tooltip("Controls the smoothness of the lookahead algorithm.  Larger values smooth out jittery predictions and also increase prediction lag")]
        public FsmFloat LookAheadSmoothing;

        [DisplayOrder(1)]
        [Tooltip("Sets the Look Ahead Ignore Y flag")]
        public FsmBool LookaheadIgnoreY;
        
        
        [DisplayOrder(1)]
        [HasFloatSlider(1f,20f)]
        [Tooltip("How aggressively the camera tries to maintain the offset in the X-axis.  Small numbers are more responsive, rapidly translating the camera to keep the target's x-axis offset.  Larger numbers give a more heavy slowly responding camera. Using different settings per axis can yield a wide range of camera behaviors.")]
        public FsmFloat xDamping;
        
        [DisplayOrder(1)]
        [HasFloatSlider(1f,20f)]
        [Tooltip("How aggressively the camera tries to maintain the offset in the Y-axis.  Small numbers are more responsive, rapidly translating the camera to keep the target's y-axis offset.  Larger numbers give a more heavy slowly responding camera. Using different settings per axis can yield a wide range of camera behaviors.")]
        public FsmFloat yDamping;
        
        [DisplayOrder(1)]
        [HasFloatSlider(1f,20f)]
        [Tooltip("How aggressively the camera tries to maintain the offset in the Z-axis.  Small numbers are more responsive, rapidly translating the camera to keep the target's z-axis offset.  Larger numbers give a more heavy slowly responding camera. Using different settings per axis can yield a wide range of camera behaviors.")]
        public FsmFloat zDamping;
        
        [DisplayOrder(1)]
        [HasFloatSlider(0f,1f)]
        [Tooltip("Horizontal screen position for target. The camera will move to position the tracked object here.")]
        public FsmFloat ScreenX;
        
        [DisplayOrder(1)]
        [HasFloatSlider(0f,1f)]
        [Tooltip("Vertical screen position for target, The camera will move to position the tracked object here.")]
        public FsmFloat ScreenY;
        
        [DisplayOrder(1)]
        [Tooltip("The distance along the camera axis that will be maintained from the Follow target")]
        public FsmFloat CameraDistance;
        
        [DisplayOrder(1)]
        [HasFloatSlider(0.0f, 1f)]
        [Tooltip("Camera will not move horizontally if the target is within this range of the position.")]
        public FsmFloat DeadZoneWidth;
        
        [DisplayOrder(1)]
        [HasFloatSlider(0.0f, 1f)]
        [Tooltip("Camera will not move vertically if the target is within this range of the position.")]
        public FsmFloat DeadZoneHeight;
        
        [DisplayOrder(1)]
        [Tooltip("The camera will not move along its z-axis if the Follow target is within this distance of the specified camera distance")]
        public FsmFloat DeadZoneDepth;
 
        [DisplayOrder(1)]
        [Tooltip("If checked, then then soft zone will be unlimited in size.")]
        public FsmBool UnlimitedSoftZone;
        
        [DisplayOrder(1)]
        [HasFloatSlider(0.0f, 2f)]
        [Tooltip("When target is within this region, camera will gradually move horizontally to re-align towards the desired position, depending on the damping speed.")]
        public FsmFloat SoftZoneWidth;
        
        [DisplayOrder(1)]
        [HasFloatSlider(0.0f, 2f)]
        [Tooltip("When target is within this region, camera will gradually move vertically to re-align towards the desired position, depending on the damping speed.")]
        public FsmFloat SoftZoneHeight;
        
        [DisplayOrder(1)]
        [HasFloatSlider(-0.5f, 0.5f)]
        [Tooltip("A non-zero bias will move the target position horizontally away from the center of the soft zone.")]
        public FsmFloat BiasX;
        
        [DisplayOrder(1)]
        [HasFloatSlider(-0.5f, 0.5f)]
        [Tooltip("A non-zero bias will move the target position vertically away from the center of the soft zone.")]
        public FsmFloat BiasY;
        
        [DisplayOrder(1)]
        [Tooltip("Force target to center of screen when this camera activates.  If false, will clamp target to the edges of the dead zone")]
        public FsmBool CenterOnActivate;
        
        public CinemachineFramingTransposer CachedCinemachineComponent;
        
        public override void Reset()
        {
            base.Reset();

            LookAheadTime = new FsmFloat() { UseVariable = true };
            LookAheadSmoothing = new FsmFloat() { UseVariable = true };
            LookaheadIgnoreY = new FsmBool() { UseVariable = true };
            
            xDamping = new FsmFloat() { UseVariable = true };
            yDamping = new FsmFloat() { UseVariable = true };
            zDamping = new FsmFloat() { UseVariable = true };
            
            ScreenX = new FsmFloat() { UseVariable = true };
            ScreenY = new FsmFloat() { UseVariable = true };
            
            CameraDistance = new FsmFloat() { UseVariable = true };
            
            DeadZoneWidth  = new FsmFloat() { UseVariable = true };
            DeadZoneHeight  = new FsmFloat() { UseVariable = true };
            DeadZoneDepth  = new FsmFloat() { UseVariable = true };
            
            UnlimitedSoftZone = new FsmBool() { UseVariable = true };
            SoftZoneWidth = new FsmFloat() { UseVariable = true };
            SoftZoneHeight = new FsmFloat() { UseVariable = true };
            BiasX = new FsmFloat() { UseVariable = true };
            BiasY = new FsmFloat() { UseVariable = true };
            CenterOnActivate = new FsmBool() { UseVariable = true };
            
        }

        protected void SetFramingTransposerSettings(ref CinemachineFramingTransposer target)
        {
            if (!LookAheadTime.IsNone) target.m_LookaheadTime = LookAheadTime.Value;
            if (!LookAheadSmoothing.IsNone) target.m_LookaheadSmoothing = LookAheadSmoothing.Value;
            if (!LookaheadIgnoreY.IsNone) target.m_LookaheadIgnoreY = LookaheadIgnoreY.Value;
            
            if (!xDamping.IsNone) target.m_XDamping = xDamping.Value;
            if (!yDamping.IsNone) target.m_XDamping = xDamping.Value;
            if (!zDamping.IsNone) target.m_XDamping = xDamping.Value;
            
            if (!ScreenX.IsNone) target.m_ScreenX = ScreenX.Value;
            if (!ScreenY.IsNone) target.m_ScreenY = ScreenY.Value;
            
            if (!CameraDistance.IsNone) target.m_CameraDistance = CameraDistance.Value;
            
            if (!DeadZoneWidth.IsNone) target.m_DeadZoneWidth = DeadZoneWidth.Value;
            if (!DeadZoneHeight.IsNone) target.m_DeadZoneHeight = DeadZoneHeight.Value;
            if (!DeadZoneDepth.IsNone) target.m_DeadZoneDepth = DeadZoneDepth.Value;
            
            if (!UnlimitedSoftZone.IsNone) target.m_UnlimitedSoftZone = UnlimitedSoftZone.Value;
            if (!SoftZoneWidth.IsNone) target.m_SoftZoneWidth = SoftZoneWidth.Value;
            if (!SoftZoneHeight.IsNone) target.m_SoftZoneHeight = SoftZoneHeight.Value;
            if (!BiasX.IsNone) target.m_BiasX = BiasX.Value;
            if (!BiasX.IsNone) target.m_BiasY = BiasX.Value;
            
            if (!CenterOnActivate.IsNone) target.m_CenterOnActivate = CenterOnActivate.Value;
            
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
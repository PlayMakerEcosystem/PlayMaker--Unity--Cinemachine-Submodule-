// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License


using Cinemachine;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    public abstract class CinemachineActionGetAxisSettingsBase<T,C> : CinemachineActionGetAxisSettingsBase<T> where T : CinemachineVirtualCamera where C : CinemachineComponentBase
    {
        /// <summary>
        /// The cached component. Call UpdateCache() first
        /// </summary>
        protected C cachedCinemachineComponent;

        private GameObject cachedCinemachineGameObject;
        
        protected bool UpdateCinemachineComponent(GameObject go)
        {
            if (cachedComponent == null) return false;

            if (cachedCinemachineComponent == null || cachedCinemachineGameObject != go)
            {
                cachedCinemachineComponent = cachedComponent.GetCinemachineComponent<C>();
                cachedCinemachineGameObject = go;

                if (cachedCinemachineComponent == null)
                {
                    LogWarning("Missing Cinemachine component: " + typeof(C).FullName + " on: " + go.name);
                }
            }
            return cachedCinemachineComponent != null;
        }
    }
    
    // Base class for cinemachine actions which gets cameras with axis settings
    public abstract class CinemachineActionGetAxisSettingsBase<T> : CinemachineActionBase<T> where T : Component
    {
        [Tooltip("The name of this axis as specified in Unity Input manager. Setting to an empty string will disable the automatic updating of this axis")]
        [DisplayOrder(1)]
        [UIHint(UIHint.Variable)]
        public FsmString InputAxisName;

        [Tooltip("The value of the axis")]
        [DisplayOrder(2)]
        [UIHint(UIHint.Variable)]
        public FsmFloat Value;
        
        [Tooltip("The input value of the axis")]
        [DisplayOrder(3)]
        [UIHint(UIHint.Variable)]
        public FsmFloat InputValue;
        
        [Tooltip("The maximum speed of this axis in units/second. Increasing this number makes the behaviour more responsive to joystick input.")]
        [DisplayOrder(4)]
        [UIHint(UIHint.Variable)]
        public FsmFloat MaxSpeed;

        [Tooltip("The amount of time in seconds it takes to accelerate to MaxSpeed with the supplied Axis at its maximum value.")]
        [DisplayOrder(5)]
        [UIHint(UIHint.Variable)]
        public FsmFloat AccelTime;

        [Tooltip("The amount of time in seconds it takes to decelerate the axis to zero if the supplied axis is in a neutral position.")]
        [DisplayOrder(6)]
        [UIHint(UIHint.Variable)]
        public FsmFloat DecelTime;

        [Tooltip("If checked, then the raw value of the input axis will be inverted before it is used.")]
        [DisplayOrder(7)]
        [UIHint(UIHint.Variable)]
        public FsmBool InvertAxis;

        [Tooltip("If checked, will Automatically recenters to at-rest position")]
        [DisplayOrder(8)]
        [ActionSection("Recentering")]
        [Title("Enabled")]  
        [UIHint(UIHint.Variable)]
        [HideIf("IsRecenteringHidden")]
        public FsmBool RecenteringEnabled;

        [Tooltip("If no user input has been detected on the axis, the axis will wait this long in seconds before recentering.")]
        [DisplayOrder(9)]
        [Title("Wait Time")]  
        [UIHint(UIHint.Variable)]
        [HideIf("IsRecenteringHidden")]
        public FsmFloat RecenteringWaitTime;
        
        [Tooltip("How long it takes to reach destination once recentering has started.")]
        [DisplayOrder(10)]
        [Title("Time")] 
        [UIHint(UIHint.Variable)]
        [HideIf("IsRecenteringHidden")]
        public FsmFloat RecenteringTime;
        
        protected bool FeaturesRecentering = true;

        public bool IsRecenteringHidden()
        {
            return !FeaturesRecentering;
        }
        
        public override void Reset()
        {
            base.Reset();
            Value = null;
            InputValue = null;
            MaxSpeed = null;
            AccelTime = null;
            DecelTime = null;
            InputAxisName = null;
            InvertAxis = null;
            RecenteringEnabled = null;
            RecenteringWaitTime = null;
            RecenteringTime = null;
        }

        protected void GetAxisSettings(ref AxisState axisSettings)
        {
            if (!Value.IsNone)
            {
                Value.Value = axisSettings.Value;
            }
            
            if (!InputValue.IsNone)
            {
                InputValue.Value = axisSettings.m_InputAxisValue;
            }
            if (!MaxSpeed.IsNone)
            {
                MaxSpeed.Value = axisSettings.m_MaxSpeed;
            }

            if (!AccelTime.IsNone)
            {
                AccelTime.Value = axisSettings.m_AccelTime;
            }

            if (!DecelTime.IsNone)
            {
                DecelTime.Value = axisSettings.m_DecelTime;
            }

            if (!InputAxisName.IsNone)
            {
                InputAxisName.Value = axisSettings.m_InputAxisName;
            }

            if (!InvertAxis.IsNone)
            {
#if UNITY_2018_1_OR_NEWER
                InvertAxis.Value = axisSettings.m_InvertInput;
#else
                InvertAxis.Value = axisSettings.m_InvertAxis;
#endif
            }

        }
    }
}
// (c) Copyright HutongGames, LLC 2010-2020. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License


using Cinemachine;
using UnityEngine;
using Component = UnityEngine.Component;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    public abstract class CinemachineActionSetAxisSettingsBase<T,C> : CinemachineActionSetAxisSettingsBase<T> where T : CinemachineVirtualCamera where C : CinemachineComponentBase
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

    // Base class for cinemachine actions which sets cameras with axis settings
    public abstract class CinemachineActionSetAxisSettingsBase<T>: CinemachineActionBase<T> where T : Component
    {
        [Tooltip("The name of this axis as specified in Unity Input manager. Setting to an empty string will disable the automatic updating of this axis")]
        [DisplayOrder(1)]
        public FsmString InputAxisName;

        [Tooltip("The value of the axis")]
        [DisplayOrder(2)]
        public FsmFloat Value;
        
        [Tooltip("The input value of the axis")]
        [DisplayOrder(3)]
        public FsmFloat InputValue;
        
        [Tooltip("The maximum speed of this axis in units/second. Increasing this number makes the behaviour more responsive to joystick input.\n" +
                 "Leave to none for no effect")]
        [DisplayOrder(4)]
        public FsmFloat MaxSpeed;

        [Tooltip("The amount of time in seconds it takes to accelerate to MaxSpeed with the supplied Axis at its maximum value.\n" +
                 "Leave to none for no effect")]
        [DisplayOrder(5)]
        public FsmFloat AccelTime;

        [Tooltip("The amount of time in seconds it takes to decelerate the axis to zero if the supplied axis is in a neutral position.\n" +
                 "Leave to none for no effect")]
        [DisplayOrder(6)]
        public FsmFloat DecelTime;

        [Tooltip("If checked, then the raw value of the input axis will be inverted before it is used.\n" +
                 "Leave to none for no effect")]
        [DisplayOrder(7)]
        public FsmBool InvertAxis;
        
        [Tooltip("If checked, will Automatically recenters to at-rest position")]
        [DisplayOrder(8)]
        [ActionSection("Recentering")]
        [Title("Enabled")]  
        [HideIf("IsRecenteringHidden")]
        public FsmBool RecenteringEnabled;

        [Tooltip("If no user input has been detected on the axis, the axis will wait this long in seconds before recentering.")]
        [DisplayOrder(9)]
        [Title("Wait Time")]  
        [HideIf("IsRecenteringHidden")]
        public FsmFloat RecenteringWaitTime;
        
        [Tooltip("How long it takes to reach destination once recentering has started.")]
        [DisplayOrder(10)]
        [Title("Time")] 
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
            
            Value = new FsmFloat(){UseVariable =true};
            InputValue = new FsmFloat(){UseVariable =true};
            
            MaxSpeed = new FsmFloat(){UseVariable =true};
            AccelTime =new FsmFloat() { UseVariable = true };
            DecelTime = new FsmFloat() { UseVariable = true };
            InputAxisName =new FsmString() { UseVariable = true };
            InvertAxis = new FsmBool() { UseVariable = true };

            RecenteringEnabled = new FsmBool() { UseVariable = true };
            RecenteringWaitTime = new FsmFloat() { UseVariable = true };
            RecenteringTime = new FsmFloat() { UseVariable = true };
            
        }

        protected void SetAxisSettings(ref AxisState axisSettings)
        {
            if (!Value.IsNone)
            {
                axisSettings.Value = Value.Value;
            }
            
            if (!InputValue.IsNone)
            {
                axisSettings.m_InputAxisValue = InputValue.Value;
            }
            
            if (!MaxSpeed.IsNone)
            {
                axisSettings.m_MaxSpeed = MaxSpeed.Value;
            }
            
            if (!AccelTime.IsNone)
            {
                axisSettings.m_AccelTime = AccelTime.Value;
            }

            if (!DecelTime.IsNone)
            {
                axisSettings.m_DecelTime = DecelTime.Value;
            }

            if (!InputAxisName.IsNone)
            {
                axisSettings.m_InputAxisName = InputAxisName.Value;
            }

            if (!InvertAxis.IsNone)
            {
#if UNITY_2018_1_OR_NEWER
                axisSettings.m_InvertInput = InvertAxis.Value;
#else
                axisSettings.m_InvertAxis = InvertAxis.Value;
#endif
            }
            
            if (!RecenteringEnabled.IsNone)
            {
                axisSettings.m_Recentering.m_enabled = RecenteringEnabled.Value;
            }   
            
            if (!RecenteringWaitTime.IsNone)
            {
                axisSettings.m_Recentering.m_WaitTime = RecenteringWaitTime.Value;
            }  
            
            if (!RecenteringTime.IsNone)
            {
                axisSettings.m_Recentering.m_RecenteringTime = RecenteringTime.Value;
            }
        }
    }
}
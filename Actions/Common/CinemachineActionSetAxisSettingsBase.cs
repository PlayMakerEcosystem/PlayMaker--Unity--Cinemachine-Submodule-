// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License


using Cinemachine;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    // Base class for cinemachine actions which sets cameras with axis settings
    public abstract class CinemachineActionSetAxisSettingsBase<T>: CinemachineActionBase<T> where T : Component
    {
        [Tooltip("The name of this axis as specified in Unity Input manager. Setting to an empty string will disable the automatic updating of this axis")]
        [DisplayOrder(1)]
        public FsmString InputAxisName;

        [Tooltip("The maximum speed of this axis in units/second. Increasing this number makes the behaviour more responsive to joystick input.\n" +
                 "Leave to none for no effect")]
        [DisplayOrder(2)]
        public FsmFloat MaxSpeed;

        [Tooltip("The amount of time in seconds it takes to accelerate to MaxSpeed with the supplied Axis at its maximum value.\n" +
                 "Leave to none for no effect")]
        [DisplayOrder(3)]
        public FsmFloat AccelTime;

        [Tooltip("The amount of time in seconds it takes to decelerate the axis to zero if the supplied axis is in a neutral position.\n" +
                 "Leave to none for no effect")]
        [DisplayOrder(4)]
        public FsmFloat DecelTime;

        [Tooltip("If checked, then the raw value of the input axis will be inverted before it is used.\n" +
                 "Leave to none for no effect")]
        [DisplayOrder(5)]
        public FsmBool InvertAxis;


        public override void Reset()
        {
            base.Reset();
            MaxSpeed = new FsmFloat(){UseVariable =true};
            AccelTime =new FsmFloat() { UseVariable = true };
            DecelTime = new FsmFloat() { UseVariable = true };
            InputAxisName =new FsmString() { UseVariable = true };
            InvertAxis = new FsmBool() { UseVariable = true };
        }

        protected void SetAxisSettings(ref AxisState axisSettings)
        {
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

        }
    }
}
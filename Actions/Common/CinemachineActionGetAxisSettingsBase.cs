// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License


using Cinemachine;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    // Base class for cinemachine actions which gets cameras with axis settings
    public abstract class CinemachineActionGetAxisSettingsBase<T> : CinemachineActionBase<T> where T : Component
    {
        [Tooltip("The name of this axis as specified in Unity Input manager. Setting to an empty string will disable the automatic updating of this axis")]
        [DisplayOrder(1)]
        [UIHint(UIHint.Variable)]
        public FsmString InputAxisName;

        [Tooltip("The maximum speed of this axis in units/second. Increasing this number makes the behaviour more responsive to joystick input.")]
        [DisplayOrder(2)]
        [UIHint(UIHint.Variable)]
        public FsmFloat MaxSpeed;

        [Tooltip("The amount of time in seconds it takes to accelerate to MaxSpeed with the supplied Axis at its maximum value.")]
        [DisplayOrder(3)]
        [UIHint(UIHint.Variable)]
        public FsmFloat AccelTime;

        [Tooltip("The amount of time in seconds it takes to decelerate the axis to zero if the supplied axis is in a neutral position.")]
        [DisplayOrder(4)]
        [UIHint(UIHint.Variable)]
        public FsmFloat DecelTime;

        [Tooltip("If checked, then the raw value of the input axis will be inverted before it is used.")]
        [DisplayOrder(5)]
        [UIHint(UIHint.Variable)]
        public FsmBool InvertAxis;


        public override void Reset()
        {
            base.Reset();
            MaxSpeed = null;
            AccelTime = null;
            DecelTime = null;
            InputAxisName = null;
            InvertAxis = null;
        }

        protected void GetAxisSettings(ref AxisState axisSettings)
        {
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
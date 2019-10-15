// (c) Copyright HutongGames, LLC 2010-2019. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using Cinemachine;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    [ActionCategory("Cinemachine")]
	[Tooltip("Gets the properties of a Camera Offset Virtual Camera extension")]
    public class CameraOffsetGetProperties : CinemachineActionBase<CinemachineCameraOffset>
    {
        [RequiredField]
		[Tooltip("The Cinemachine Camera Offset Extension")]
        [CheckForComponent(typeof(CinemachineCameraOffset))]
        public FsmOwnerDefault gameObject;

        [UIHint(UIHint.Variable)]
        [Tooltip("A offset vector. NOTE: You can override individual axis below.")]
        public FsmVector3 offset;
		
        [UIHint(UIHint.Variable)]
        [Tooltip("Offset along x axis.")]
        public FsmFloat x;

        [UIHint(UIHint.Variable)]
        [Tooltip("Offset along y axis.")]
        public FsmFloat y;

        [UIHint(UIHint.Variable)]
        [Tooltip("Offset along z axis.")]
        public FsmFloat z;

        [UIHint(UIHint.Variable)]
        [Tooltip("Defines when to apply offset")]
        [ObjectType(typeof(CinemachineCore.Stage))]
        public FsmEnum applyAfter;
        
        [Tooltip("repeat every frame, useful for animation")]
        public bool everyFrame;


        public override void Reset()
        {
            gameObject = null;
            
            offset = null;
            x = null;
            y = null;
            z = null;
            applyAfter = null;

            everyFrame = false;
        }

        public override void OnEnter()
        {
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
            if (!UpdateCache(Fsm.GetOwnerDefaultTarget(gameObject)))
            {
                return;
            }

            if (!offset.IsNone) offset.Value = this.cachedComponent.m_Offset;
            if (!x.IsNone) x.Value = this.cachedComponent.m_Offset.x;
            if (!y.IsNone) y.Value = this.cachedComponent.m_Offset.y;
            if (!z.IsNone) z.Value = this.cachedComponent.m_Offset.z;

            if (!applyAfter.IsNone) applyAfter.Value = this.cachedComponent.m_ApplyAfter;

        }
    }
}
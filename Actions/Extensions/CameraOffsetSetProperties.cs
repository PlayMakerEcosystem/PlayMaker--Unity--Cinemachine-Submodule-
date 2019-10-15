// (c) Copyright HutongGames, LLC 2010-2019. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using Cinemachine;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    [ActionCategory("Cinemachine")]
	[Tooltip("Sets the properties of a Camera Offset Virtual Camera extension")]
    public class CameraOffsetSetProperties : CinemachineActionBase<CinemachineCameraOffset>
    {
        [RequiredField]
		[Tooltip("The Cinemachine Camera Offset Extension")]
        [CheckForComponent(typeof(CinemachineCameraOffset))]
        public FsmOwnerDefault gameObject;

        [UIHint(UIHint.Variable), Readonly]
        [Tooltip("A offset vector. NOTE: You can override individual axis below.")]
        public FsmVector3 offset;
		
        [Tooltip("Offset along x axis.")]
        public FsmFloat x;

        [Tooltip("Offset along y axis.")]
        public FsmFloat y;

        [Tooltip("Offset along z axis.")]
        public FsmFloat z;

        [Tooltip("Define when to apply offset")]
        [ObjectType(typeof(CinemachineCore.Stage))]
        public FsmEnum applyAfter;
        
        [Tooltip("repeat every frame, useful for animation")]
        public bool everyFrame;

        private Vector3 _offset;

        public override void Reset()
        {
            gameObject = null;
            
            offset = null;
            // default axis to variable dropdown with None selected.
            x = new FsmFloat { UseVariable = true };
            y = new FsmFloat { UseVariable = true };
            z = new FsmFloat { UseVariable = true };
            
            applyAfter = new FsmEnum() { UseVariable = true };

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

            _offset = offset.IsNone ? this.cachedComponent.m_Offset : offset.Value;

            // override any axis
            if (!x.IsNone) _offset.x = x.Value;
            if (!y.IsNone) _offset.y = y.Value;
            if (!z.IsNone) _offset.z = z.Value;

            this.cachedComponent.m_Offset = _offset;

            if (!applyAfter.IsNone)
            {
                this.cachedComponent.m_ApplyAfter = (CinemachineCore.Stage)applyAfter.Value;
            }

        }
    }
}
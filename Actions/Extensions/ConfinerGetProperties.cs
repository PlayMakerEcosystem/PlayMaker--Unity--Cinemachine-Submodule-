// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using Cinemachine;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    [ActionCategory("Cinemachine")]
	[Tooltip("Gets the properties of a Confiner Virtual Camera extension")]
    public class ConfinerGetProperties : CinemachineActionBase<CinemachineConfiner>
    {
        [RequiredField]
		[Tooltip("The Cinemachine Confiner Extension")]
        [CheckForComponent(typeof(CinemachineConfiner))]
        public FsmOwnerDefault gameObject;

        [Tooltip("The confiner can operate using a 2D bounding shape or a 3D bounding volume.\n" +
                 "Leave to none for no effect")]
        [UIHint(UIHint.Variable)]
        [ObjectType(typeof(CinemachineConfiner.Mode))]
        public FsmEnum confineMode;

        [Tooltip("The 3d volume within which the camera is to be contained if ConfineMode is set to Confine3D.\n" +
                 "Leave to none for no effect")]
        [CheckForComponent(typeof(Collider))]
        [UIHint(UIHint.Variable)]
        [HideIf("UsesConfine2d")]
        public FsmGameObject boundingVolume3d;

        [Tooltip("The 2D shape within which the camera is to be contained.\n" +
                 "Leave to none for no effect")]
        [CheckForComponent(typeof(Collider2D))]
        [UIHint(UIHint.Variable)]
        [HideIf("UsesConfine3d")]
        public FsmGameObject boundingVolume2d;

        [Tooltip("If camera is orthographic, screen edges will be confined to the volume.  If not checked, then only the camera center will be confined.\n" +
                "Leave to none for no effect")]
        [UIHint(UIHint.Variable)]
        public FsmBool confineScreenEdges;


        [Tooltip("Upper limit on how many obstacle hits to process.  Higher numbers may impact performance.  In most environments, 4 is enough.\n" +
                 "Leave to none for no effect")]
        [UIHint(UIHint.Variable)]
        public FsmFloat damping;

        [Tooltip("repeat every frame, useful for animation")]
        public bool everyFrame;


        public override void Reset()
        {
            gameObject = null;
            confineMode = null;

            boundingVolume3d = null;

            boundingVolume2d = null;

            confineScreenEdges = null;
            damping = null;

            everyFrame = false;
        }

        public bool UsesConfine2d()
        {
            return (CinemachineConfiner.Mode)confineMode.Value == CinemachineConfiner.Mode.Confine2D;
        }

        public bool UsesConfine3d()
        {
            return (CinemachineConfiner.Mode)confineMode.Value == CinemachineConfiner.Mode.Confine3D;
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

            if (!confineMode.IsNone)
            {
                confineMode.Value = this.cachedComponent.m_ConfineMode;
            }

            if (!boundingVolume3d.IsNone)
            {
                boundingVolume3d.Value = this.cachedComponent.m_BoundingVolume?this.cachedComponent.m_BoundingVolume.gameObject:null;

            }

            if (!boundingVolume2d.IsNone)
            {
                boundingVolume2d.Value = this.cachedComponent.m_BoundingShape2D ? this.cachedComponent.m_BoundingShape2D.gameObject : null;

            }

            if (!confineScreenEdges.IsNone)
            {
                confineScreenEdges.Value = this.cachedComponent.m_ConfineScreenEdges;
            }

            if (!damping.IsNone)
            {
                damping.Value = this.cachedComponent.m_Damping;
            }


        }
    }
}
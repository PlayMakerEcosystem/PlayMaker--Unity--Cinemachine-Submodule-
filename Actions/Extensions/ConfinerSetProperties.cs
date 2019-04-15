// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using Cinemachine;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    [ActionCategory("Cinemachine")]
	[Tooltip("Sets the properties of a Confiner Virtual Camera extension")]
    public class ConfinerSetProperties : CinemachineActionBase<CinemachineConfiner>
    {
        [RequiredField]
		[Tooltip("The Cinemachine Confiner Extension")]
        [CheckForComponent(typeof(CinemachineConfiner))]
        public FsmOwnerDefault gameObject;

        [Tooltip("The confiner can operate using a 2D bounding shape or a 3D bounding volume.\n" +
                 "Leave to none for no effect")]
        [ObjectType(typeof(CinemachineConfiner.Mode))]
        public FsmEnum confineMode;

        [Tooltip("The 3d volume within which the camera is to be contained if ConfineMode is set to Confine3D.\n" +
                 "Leave to none for no effect")]
        [CheckForComponent(typeof(Collider))]
        [HideIf("UsesConfine2d")]
        public FsmOwnerDefault boundingVolume3d;

        [Tooltip("The 2D shape within which the camera is to be contained.\n" +
                 "Leave to none for no effect")]
        [CheckForComponent(typeof(Collider2D))]
        [HideIf("UsesConfine3d")]
        public FsmOwnerDefault boundingVolume2d;

        [Tooltip("If camera is orthographic, screen edges will be confined to the volume.  If not checked, then only the camera center will be confined.\n" +
                "Leave to none for no effect")]
        public FsmBool confineScreenEdges;


        [Tooltip("Upper limit on how many obstacle hits to process.  Higher numbers may impact performance.  In most environments, 4 is enough.\n" +
                 "Leave to none for no effect")]
        [HasFloatSlider(0f,10f)]
        public FsmFloat damping;

        [Tooltip("repeat every frame, useful for animation")]
        public bool everyFrame;


        GameObject _goCol3d;
        GameObject _goCol2d;

        public override void Reset()
        {
            gameObject = null;
            confineMode = new FsmEnum() { UseVariable = true };

            boundingVolume3d = new FsmOwnerDefault() {OwnerOption= OwnerDefaultOption.SpecifyGameObject};
            boundingVolume3d.GameObject = new FsmGameObject() { UseVariable = true };

            boundingVolume2d = new FsmOwnerDefault() { OwnerOption = OwnerDefaultOption.SpecifyGameObject };
            boundingVolume2d.GameObject = new FsmGameObject() { UseVariable = true };

            confineScreenEdges = new FsmBool() {UseVariable = true };
            damping = new FsmFloat() { UseVariable = true };

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
                this.cachedComponent.m_ConfineMode = (CinemachineConfiner.Mode)confineMode.Value;
            }

            if (boundingVolume3d.OwnerOption == OwnerDefaultOption.UseOwner ||
                !boundingVolume3d.GameObject.IsNone
               )
            {
                _goCol3d = Fsm.GetOwnerDefaultTarget(boundingVolume3d);

                this.cachedComponent.m_BoundingVolume = _goCol3d?_goCol3d.GetComponent<Collider>():null ;
            }

            if (boundingVolume2d.OwnerOption == OwnerDefaultOption.UseOwner ||
                !boundingVolume2d.GameObject.IsNone
               )
            {
                _goCol2d = Fsm.GetOwnerDefaultTarget(boundingVolume2d);
                this.cachedComponent.m_BoundingShape2D = _goCol2d?_goCol2d.GetComponent<Collider2D>() : null;

                this.cachedComponent.InvalidatePathCache();
            }

            if (!confineScreenEdges.IsNone)
            {
                this.cachedComponent.m_ConfineScreenEdges = confineScreenEdges.Value;
            }

            if (!damping.IsNone)
            {
                this.cachedComponent.m_Damping = damping.Value;
            }


        }
    }
}
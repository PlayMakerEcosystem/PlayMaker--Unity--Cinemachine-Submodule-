// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using Cinemachine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    [ActionCategory("Cinemachine")]
	[Tooltip("Sets the properties of a Collider Virtual Camera extension")]
    public class ColliderSetProperties : CinemachineActionBase<CinemachineCollider>
    {
        [RequiredField]
		[Tooltip("The Cinemachine Follow Zoom Extension")]
        [CheckForComponent(typeof(CinemachineCollider))]
        public FsmOwnerDefault gameObject;

        [Tooltip("Obstacles with this tag will be ignored.  It is a good idea to set this field to the target's tag")]
        [UIHint(UIHint.Tag)]
        public FsmString ignoreTag;

        [Tooltip("Obstacles closer to the target than this will be ignored")]
        public FsmFloat minimumDistanceFromTarget;

        [ActionSection("Obstacle")]
        [Tooltip("When enabled, will attempt to resolve situations where the line of sight to the target is blocked by an obstacle")]
        public FsmBool avoidObstacles;

        [Tooltip("The maximum raycast distance when checking if the line of sight to this camera's target is clear.  If the setting is 0 or less, the current actual distance to target will be used.")]
        public FsmFloat distanceLimit;

        [Tooltip("Camera will try to maintain this distance from any obstacle.  Try to keep this value small.  Increase it if you are seeing inside obstacles due to a large FOV on the camera.")]
        public FsmFloat cameraRadius;

        [Tooltip("The way in which the Collider will attempt to preserve sight of the target.")]
        [ObjectType(typeof(CinemachineCollider.ResolutionStrategy))]
        public FsmEnum strategy;

        [Tooltip("The gradualness of collision resolution. Range from 0 to 10. Higher numbers will move the camera more gradually away from obstructions.")]
        public FsmInt maximumEffort;

        [Tooltip("Upper limit on how many obstacle hits to process.  Higher numbers may impact performance.  In most environments, 4 is enough.")]
        [HasFloatSlider(0f,10f)]
        public FsmFloat damping;

        [ActionSection("Shot Evaluation")]
        [Tooltip("If greater than zero, a higher score will be given to shots when the target is closer to this distance.  Set this to zero to disable this feature.")]
        public FsmFloat optimalTargetDistance;

   
        [Tooltip("repeat every frame, useful for animation")]
        public bool everyFrame;

        public override void Reset()
        {
            gameObject = null;
            ignoreTag = new FsmString() { UseVariable = true };
            minimumDistanceFromTarget = new FsmFloat() {UseVariable = true};
            avoidObstacles = new FsmBool() {UseVariable = true };
            distanceLimit = new FsmFloat() {UseVariable = true };
            cameraRadius = new FsmFloat() {UseVariable = true };
            strategy = new FsmEnum() { UseVariable = true };
            maximumEffort = new FsmInt() { UseVariable = true };
            damping = new FsmFloat() { UseVariable = true };
            optimalTargetDistance = new FsmFloat() { UseVariable = true };

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

            if (!ignoreTag.IsNone)
            {
                this.cachedComponent.m_IgnoreTag = ignoreTag.Value;
            }

            if (!minimumDistanceFromTarget.IsNone)
            {
                this.cachedComponent.m_MinimumDistanceFromTarget = minimumDistanceFromTarget.Value;
            }

            if (!avoidObstacles.IsNone)
            {
                this.cachedComponent.m_AvoidObstacles = avoidObstacles.Value;
            }

            if (!distanceLimit.IsNone)
            {
                this.cachedComponent.m_DistanceLimit = distanceLimit.Value;
            }

            if (!cameraRadius.IsNone)
            {
                this.cachedComponent.m_CameraRadius = cameraRadius.Value;
            }

            if (!strategy.IsNone)
            {
                this.cachedComponent.m_Strategy = (CinemachineCollider.ResolutionStrategy)strategy.Value;
            }

            if (!maximumEffort.IsNone)
            {
                this.cachedComponent.m_MaximumEffort = maximumEffort.Value;
            }

            if (!damping.IsNone)
            {
                this.cachedComponent.m_Damping = damping.Value;
            }

            if (!optimalTargetDistance.IsNone)
            {
                this.cachedComponent.m_OptimalTargetDistance = optimalTargetDistance.Value;
            }




        }
    }
}
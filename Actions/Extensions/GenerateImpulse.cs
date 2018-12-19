// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using Cinemachine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    [ActionCategory("Cinemachine")]
    [Tooltip("Generate an Impulse, Requires a CinemachineImpulseSource Component")]
    public class GenerateImpulse : CinemachineActionBase<CinemachineImpulseSource>
    {
        [RequiredField]
        [Tooltip("The GameObject Target with a CinemachineImpulseSource Component")]
        [CheckForComponent(typeof(CinemachineImpulseSource))]
        public FsmOwnerDefault gameObject;

        [Tooltip("Leave to none for default, if Velocity is set, it will use the gameobject target position")]
        public FsmVector3 position;

        [Tooltip("Leave to none for default, if Position not set, will default to down")]
        public FsmVector3 velocity;


        public override void Reset()
        {
            gameObject = null;
        }

        public override void OnEnter()
        {

            Execute();

            Finish();

        }

        void Execute()
        {
            if (!UpdateCache(Fsm.GetOwnerDefaultTarget(gameObject)))
            {
                return;
            }

            if (position.IsNone && !velocity.IsNone)
            {
                this.cachedComponent.GenerateImpulse(velocity.Value);
                return;
            }

            if (!position.IsNone)
            {
                this.cachedComponent.GenerateImpulseAt(position.Value,velocity.Value);
                return;
            }

            this.cachedComponent.GenerateImpulse();
        }
    }
}
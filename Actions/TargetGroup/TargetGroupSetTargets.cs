// (c) Copyright HutongGames, LLC 2010-2019. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using UnityEngine;
using Cinemachine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    [ActionCategory("Cinemachine")]
	[Tooltip("Sets the follow target of a Virtual Camera")]
	public class TargetGroupSetTargets : ComponentAction<CinemachineTargetGroup>
    {
        [RequiredField]
		[Tooltip("The Cinemachine CinemachineTargetGroup")]
		[CheckForComponent(typeof(CinemachineTargetGroup))]
        public FsmOwnerDefault gameObject;

        [RequiredField]
        [UIHint(UIHint.Variable)]
		[Tooltip("The targets Gameobjects")]
        [ArrayEditor(VariableType.GameObject)]
		public FsmArray targets;
		
		[UIHint(UIHint.Variable)]
		[Tooltip("The targets Weights. Leave to none for no effects, it will get assigned the default weight of 1")]
		[ArrayEditor(VariableType.Float)]
		public FsmArray weights;
		
		[UIHint(UIHint.Variable)]
		[Tooltip("The targets radius. Leave to none for no effects, it will get assigned the default radius of 0")]
		[ArrayEditor(VariableType.Float)]
		public FsmArray radius;
		

		private CinemachineTargetGroup.Target[] _targets;

		public override void Reset()
        {
            gameObject = null;
            targets = null;
            weights = new FsmArray(){UseVariable = true};
            radius = new FsmArray(){UseVariable = true};
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

            _targets = new CinemachineTargetGroup.Target[targets.Length];
            int i = 0;
            foreach (object _t in targets.Values)
            {
	            GameObject _go = _t as GameObject;
	            _targets[i].target = _go ==null?null:_go.transform;
	            _targets[i].weight = weights.IsNone ? 1f : (float)weights.Values[i];
	            _targets[i].radius = radius.IsNone ? 0f : (float)radius.Values[i];
	            i++;
            }

            this.cachedComponent.m_Targets = _targets;

        }

        public override string ErrorCheck()
        {
	        base.ErrorCheck();
	        if (!radius.IsNone && radius.Length != targets.Length)
	        {
		        return "Radius array count does not match the target array count";
	        }
	        
	        if (!weights.IsNone && weights.Length != targets.Length)
	        {
		        return "weights array count does not match the target array count";
	        }
	        return "";
        }
    }
}
// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using Cinemachine;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    [ActionCategory("Cinemachine")]
    [Tooltip("Sets the mixing weights of a CinemachineMixingCamera Component")]
    public class MixingCameraSetWeights : CinemachineActionBase<CinemachineMixingCamera>
    {
        [RequiredField]
		[Tooltip("The Cinemachine Mixing Camera")]
        [CheckForComponent(typeof(CinemachineMixingCamera))]
        public FsmOwnerDefault gameObject;

        [HideIf("IsPlaying")]
        public bool UseArray;

        [Tooltip("All weights")]
        [HideIf("HideIfUsingArray")]
        [ArrayEditor(VariableType.Float)]
        public FsmArray weights;

        [Tooltip("The weight of the first tracked camera")]
        [HideIf("HideIfNotUsingArray")]
        public FsmFloat weight_0;

        [Tooltip("The weight of the second tracked camera")]
        [HideIf("HideIfNotUsingArray")]
        public FsmFloat weight_1;

        [Tooltip("The weight of the third tracked camera")]
        [HideIf("HideIfNotUsingArray")]
        public FsmFloat weight_2;

        [Tooltip("The weight of the fourth tracked camera")]
        [Readonly]
        [HideIf("HideIfNotUsingArray")]
        public FsmFloat weight_3;

        [Tooltip("The weight of the fifth tracked camera")]
        [HideIf("HideIfNotUsingArray")]
        public FsmFloat weight_4;

        [Tooltip("The weight of the sixth tracked camera")]
        [HideIf("HideIfNotUsingArray")]
        public FsmFloat weight_5;

        [Tooltip("The weight of the seventh tracked camera")]
        [HideIf("HideIfNotUsingArray")]
        public FsmFloat weight_6;

        [Tooltip("The weight of the eighth tracked camera")]
        [HideIf("HideIfNotUsingArray")]
        public FsmFloat weight_7;



		[Tooltip("repeat every frame, useful for animation")]
		public bool everyFrame;


        public bool IsPlaying()
        {
            return Application.isPlaying;
        }
        public bool HideIfUsingArray()
        {
            return !UseArray;
        }
        public bool HideIfNotUsingArray()
        {
            return UseArray;
        }

        public override void Reset()
        {
            gameObject = null;

            weight_0 = new FsmFloat(){UseVariable =true};
            weight_1 = new FsmFloat() { UseVariable = true };
            weight_2 = new FsmFloat() { UseVariable = true };
            weight_3 = new FsmFloat() { UseVariable = true };
            weight_4 = new FsmFloat() { UseVariable = true };
            weight_5 = new FsmFloat() { UseVariable = true };
            weight_6 = new FsmFloat() { UseVariable = true };
            weight_7 = new FsmFloat() { UseVariable = true };

            weights = null;

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

            if (UseArray)
            {
             
                if (weights.Length >= 8)
                {
                    this.cachedComponent.m_Weight7 = weights.floatValues[7];
                }
                if (weights.Length >= 7)
                {
                    this.cachedComponent.m_Weight6 = weights.floatValues[6];
                }
                if (weights.Length >= 6)
                {
                    this.cachedComponent.m_Weight5 = weights.floatValues[5];
                }
                if (weights.Length >= 5)
                {
                    this.cachedComponent.m_Weight4 = weights.floatValues[4];
                }
                if (weights.Length >= 4)
                {
                    this.cachedComponent.m_Weight3 = weights.floatValues[3];
                }
                if (weights.Length >= 3)
                {
                    this.cachedComponent.m_Weight2 = weights.floatValues[2];
                }
                if (weights.Length >= 2)
                {
                    this.cachedComponent.m_Weight1 = weights.floatValues[1];
                }
                if (weights.Length >= 1)
                {
                    this.cachedComponent.m_Weight0 = weights.floatValues[0];
                }

            }else{
                if (!weight_0.IsNone)
                {
                    this.cachedComponent.m_Weight0 = weight_0.Value;
                }
                if (!weight_1.IsNone)
                {
                    this.cachedComponent.m_Weight1 = weight_1.Value;
                }
                if (!weight_2.IsNone)
                {
                    this.cachedComponent.m_Weight2 = weight_2.Value;
                }
                if (!weight_3.IsNone)
                {
                    this.cachedComponent.m_Weight3 = weight_3.Value;
                }
                if (!weight_4.IsNone)
                {
                    this.cachedComponent.m_Weight4 = weight_4.Value;
                }
                if (!weight_5.IsNone)
                {
                    this.cachedComponent.m_Weight5 = weight_5.Value;
                }
                if (!weight_6.IsNone)
                {
                    this.cachedComponent.m_Weight6 = weight_6.Value;
                }
                if (!weight_7.IsNone)
                {
                    this.cachedComponent.m_Weight7 = weight_7.Value;
                } 
            }
          
        }
    }
}
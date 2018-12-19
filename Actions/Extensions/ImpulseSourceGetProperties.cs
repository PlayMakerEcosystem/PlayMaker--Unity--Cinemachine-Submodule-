// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using Cinemachine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    [ActionCategory("Cinemachine")]
	[Tooltip("Gets the properties of a ImpulseSource component")]
    public class ImpulseSourceGetProperties : CinemachineActionBase<CinemachineImpulseSource>
    {
        [RequiredField]
		[Tooltip("The Cinemachine Impulse Listener Extension")]
        [CheckForComponent(typeof(CinemachineImpulseSource))]
        public FsmOwnerDefault gameObject;

        [Tooltip("The signal that will be generated.")]
        [UIHint(UIHint.Variable)]
        [ObjectType(typeof(SignalSourceAsset))]
        public FsmObject rawSignal;

        [ActionSection("Signal Shape")]
        [Tooltip("Gain to apply to the amplitudes defined in the signal source.  1 is normal.")]
        [UIHint(UIHint.Variable)]
        public FsmFloat amplitudeGain;

        [Tooltip("Scale factor to apply to the time axis.  1 is normal.  Larger magnitudes make the signal progress more rapidly.")]
        [UIHint(UIHint.Variable)]
        public FsmFloat frequencyGain = 1f;

        [Tooltip("How to fit the signal into the envelope time")]
        [UIHint(UIHint.Variable)]
        [ObjectType(typeof(CinemachineImpulseDefinition.RepeatMode))]
        public FsmEnum repeatMode;

        [Tooltip("Randomize the signal start time")]
        [UIHint(UIHint.Variable)]
        public FsmBool randomize = true;

        [ActionSection("Time Envelop")]
        [Tooltip("Duration in seconds of the attack.  Attack curve will be scaled to fit. >= 0.")]
        [UIHint(UIHint.Variable)]
        public FsmFloat attackTime;

        [Tooltip("Duration in seconds of the central fully-scaled part of the envelope. >= 0.")]
        [UIHint(UIHint.Variable)]
        public FsmFloat sustainTime;

        [Tooltip("Duration in seconds of the decay.  Decay curve will be scaled to fit. >= 0.")]
        [UIHint(UIHint.Variable)]
        public FsmFloat decayTime;

        [Tooltip("If checked, signal amplitude scaling will also be applied to the time envelope of the signal.  Stronger signals last longer.")]
        [UIHint(UIHint.Variable)]
        public FsmBool scaleWithImpact;

        [Tooltip("If true, then duration is infinite.")]
        [UIHint(UIHint.Variable)]
        public FsmBool holdForever;

        [ActionSection("Spacial Range")]
        [Tooltip("The signal will have full amplitude in this radius surrounding the impact point.  Beyond that it will dissipate with distance.")]
        [UIHint(UIHint.Variable)]
        public FsmFloat impactRadius;

        /// <summary>How the signal direction behaves as the listener moves away from the origin.</summary>
        [Tooltip("How the signal direction behaves as the listener moves away from the origin.")]
        [ObjectType(typeof(CinemachineImpulseManager.ImpulseEvent.DirectionMode))]
        [UIHint(UIHint.Variable)]
        public FsmEnum directionMode;

        [Tooltip("This defines how the signal will dissipate with distance beyond the impact radius.")]
        [ObjectType(typeof(CinemachineImpulseManager.ImpulseEvent.DissipationMode))]
        [UIHint(UIHint.Variable)]
        public FsmEnum dissipationMode;

        [Tooltip("At this distance beyond the impact radius, the signal will have dissipated to zero.")]
        [UIHint(UIHint.Variable)]
        public FsmFloat dissipationDistance;

        [Tooltip("repeat every frame")]
        public bool everyFrame;


        CinemachineImpulseDefinition _impulseDefinition;
        CinemachineImpulseManager.EnvelopeDefinition _envelopDefinition;

        public override void Reset()
        {
            gameObject = null;
            rawSignal = new FsmObject(){UseVariable=true};

            amplitudeGain = null;
            frequencyGain = null;
            repeatMode = null;
            randomize = null;

            attackTime = null;
            sustainTime = null;
            decayTime = null;
            scaleWithImpact = null;
            holdForever = null;

            impactRadius = null;
            directionMode = null;
            dissipationMode = null;
            dissipationDistance = null;

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

            _impulseDefinition = this.cachedComponent.m_ImpulseDefinition;
            _envelopDefinition = _impulseDefinition.m_TimeEnvelope;

            if (!rawSignal.IsNone)
            {
                rawSignal.Value = _impulseDefinition.m_RawSignal;
            }

            if (!amplitudeGain.IsNone)
            {
                amplitudeGain.Value = _impulseDefinition.m_AmplitudeGain;
            }

            if (!frequencyGain.IsNone)
            {
                frequencyGain.Value = _impulseDefinition.m_FrequencyGain;
            }

            if (!repeatMode.IsNone)
            {
                repeatMode.Value = _impulseDefinition.m_RepeatMode;
            }

            if (!randomize.IsNone)
            {
                randomize.Value = _impulseDefinition.m_Randomize;
            }

            if (!attackTime.IsNone)
            {
                attackTime.Value = _envelopDefinition.m_AttackTime;
            }

            if (!sustainTime.IsNone)
            {
                _envelopDefinition.m_SustainTime = sustainTime.Value;
            }

            if (!decayTime.IsNone)
            {
                decayTime.Value = _envelopDefinition.m_DecayTime;
            }

            if (!scaleWithImpact.IsNone)
            {
                scaleWithImpact.Value = _envelopDefinition.m_ScaleWithImpact;
            }

            if (!holdForever.IsNone)
            {
                holdForever.Value = _envelopDefinition.m_HoldForever;
            }

            if (!impactRadius.IsNone)
            {
                impactRadius.Value = _impulseDefinition.m_ImpactRadius;
            }

            if (!directionMode.IsNone)
            {
                directionMode.Value = _impulseDefinition.m_DirectionMode;
            }

            if (!dissipationMode.IsNone)
            {
                dissipationMode.Value = _impulseDefinition.m_DissipationMode;
            }

            if (!dissipationDistance.IsNone)
            {
                dissipationDistance.Value = _impulseDefinition.m_DissipationDistance;
            }



        }
    }
}
// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using Cinemachine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    [ActionCategory("Cinemachine")]
	[Tooltip("Sets the properties of a ImpulseSource component")]
    public class ImpulseSourceSetProperties : CinemachineActionBase<CinemachineImpulseSource>
    {
        [RequiredField]
		[Tooltip("The Cinemachine Impulse Listener Extension")]
        [CheckForComponent(typeof(CinemachineImpulseSource))]
        public FsmOwnerDefault gameObject;

        [Tooltip("Defines the signal that will be generated.")]
        [ObjectType(typeof(SignalSourceAsset))]
        public FsmObject rawSignal;

        [ActionSection("Signal Shape")]
        [Tooltip("Gain to apply to the amplitudes defined in the signal source.  1 is normal.  Setting this to 0 completely mutes the signal.")]
        public FsmFloat amplitudeGain;

        [Tooltip("Scale factor to apply to the time axis.  1 is normal.  Larger magnitudes will make the signal progress more rapidly.")]
        public FsmFloat frequencyGain = 1f;

        [Tooltip("How to fit the signal into the envelope time")]
        [ObjectType(typeof(CinemachineImpulseDefinition.RepeatMode))]
        public FsmEnum repeatMode;

        [Tooltip("Randomize the signal start time")]
        public FsmBool randomize = true;

        [ActionSection("Time Envelop")]
        [Tooltip("Normalized curve defining the shape of the start of the envelope.  If blank a default curve will be used")]
        public FsmAnimationCurve attackShape;

        [Tooltip("Duration in seconds of the attack.  Attack curve will be scaled to fit.  Must be >= 0.")]
        public FsmFloat attackTime;

        [Tooltip("Duration in seconds of the central fully-scaled part of the envelope.  Must be >= 0.")]
        public FsmFloat sustainTime;

        [Tooltip("Normalized curve defining the shape of the end of the envelope.  If blank a default curve will be used")]
        public FsmAnimationCurve decayShape;

        [Tooltip("Duration in seconds of the decay.  Decay curve will be scaled to fit.  Must be >= 0.")]
        public FsmFloat decayTime;

        [Tooltip("If checked, signal amplitude scaling will also be applied to the time envelope of the signal.  Stronger signals will last longer.")]
        public FsmBool scaleWithImpact;

        [Tooltip("If true, then duration is infinite.")]
        public FsmBool holdForever;

        [ActionSection("Spacial Range")]
        [Tooltip("The signal will have full amplitude in this radius surrounding the impact point.  Beyond that it will dissipate with distance.")]
        public FsmFloat impactRadius;

        /// <summary>How the signal direction behaves as the listener moves away from the origin.</summary>
        [Tooltip("How the signal direction behaves as the listener moves away from the origin.")]
        [ObjectType(typeof(CinemachineImpulseManager.ImpulseEvent.DirectionMode))]
        public FsmEnum directionMode;

        [Tooltip("This defines how the signal will dissipate with distance beyond the impact radius.")]
        [ObjectType(typeof(CinemachineImpulseManager.ImpulseEvent.DissipationMode))]
        public FsmEnum dissipationMode;

        [Tooltip("At this distance beyond the impact radius, the signal will have dissipated to zero.")]
        public FsmFloat dissipationDistance;

        [Tooltip("repeat every frame, useful for animation")]
        public bool everyFrame;


        CinemachineImpulseDefinition _impulseDefinition;
        CinemachineImpulseManager.EnvelopeDefinition _envelopDefinition;

        public override void Reset()
        {
            gameObject = null;
            rawSignal = new FsmObject(){UseVariable=true};

            amplitudeGain = new FsmFloat() { UseVariable = true, Value = 1f };
            frequencyGain = new FsmFloat() { UseVariable = true, Value = 1f };
            repeatMode = new FsmEnum() { UseVariable = true, Value = CinemachineImpulseDefinition.RepeatMode.Stretch };
            randomize = new FsmBool() { UseVariable = true, Value = true };

            attackShape = new FsmAnimationCurve();
            attackTime = new FsmFloat() { UseVariable = true, Value = 0f };
            sustainTime = new FsmFloat() { UseVariable = true, Value = 0.2f };
            decayShape = new FsmAnimationCurve();
            decayTime = new FsmFloat() { UseVariable = true, Value = 0.7f };
            scaleWithImpact = new FsmBool() { UseVariable = true, Value = true };
            holdForever = new FsmBool() { UseVariable = true, Value = false };

            impactRadius = new FsmFloat() { UseVariable = true, Value = 100f };
            directionMode = new FsmEnum() { UseVariable = true, Value = CinemachineImpulseManager.ImpulseEvent.DirectionMode.Fixed };
            dissipationMode = new FsmEnum() { UseVariable = true, Value = CinemachineImpulseManager.ImpulseEvent.DissipationMode.ExponentialDecay };
            dissipationDistance = new FsmFloat() { UseVariable = true, Value = 1000f };

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
                _impulseDefinition.m_RawSignal = rawSignal.Value as SignalSourceAsset;
            }

            if (!amplitudeGain.IsNone)
            {
                _impulseDefinition.m_AmplitudeGain = amplitudeGain.Value;
            }

            if (!frequencyGain.IsNone)
            {
                _impulseDefinition.m_FrequencyGain = frequencyGain.Value;
            }

            if (!repeatMode.IsNone)
            {
                _impulseDefinition.m_RepeatMode = (CinemachineImpulseDefinition.RepeatMode)repeatMode.Value;
            }

            if (!randomize.IsNone)
            {
                _impulseDefinition.m_Randomize = randomize.Value;
            }

            if (attackShape.curve.length>0)
            {
                _envelopDefinition.m_AttackShape = attackShape.curve;
            }

            if (!attackTime.IsNone)
            {
                _envelopDefinition.m_AttackTime = attackTime.Value;
            }

            if (!sustainTime.IsNone)
            {
                _envelopDefinition.m_SustainTime = sustainTime.Value;
            }

            if (decayShape.curve.length>0)
            {
                _envelopDefinition.m_DecayShape = decayShape.curve;
            }

            if (!decayTime.IsNone)
            {
                _envelopDefinition.m_DecayTime = decayTime.Value;
            }

            if (!scaleWithImpact.IsNone)
            {
                _envelopDefinition.m_ScaleWithImpact = scaleWithImpact.Value;
            }

            if (!holdForever.IsNone)
            {
                _envelopDefinition.m_HoldForever = holdForever.Value;
            }

            if (!impactRadius.IsNone)
            {
                _impulseDefinition.m_ImpactRadius = impactRadius.Value;
            }

            if (!directionMode.IsNone)
            {
                _impulseDefinition.m_DirectionMode = (CinemachineImpulseManager.ImpulseEvent.DirectionMode)directionMode.Value;
            }

            if (!dissipationMode.IsNone)
            {
                _impulseDefinition.m_DissipationMode = (CinemachineImpulseManager.ImpulseEvent.DissipationMode)dissipationMode.Value;
            }

            if (!dissipationDistance.IsNone)
            {
                _impulseDefinition.m_DissipationDistance = dissipationDistance.Value;
            }


            _impulseDefinition.m_TimeEnvelope = _envelopDefinition;
            this.cachedComponent.m_ImpulseDefinition = _impulseDefinition;

        }
    }
}
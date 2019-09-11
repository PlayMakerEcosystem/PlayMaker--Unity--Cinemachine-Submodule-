using Cinemachine.Utility;
using UnityEngine;

namespace Cinemachine
{
    /// <summary>
    /// An add-on module for Cinemachine Virtual Camera that adjusts
    /// the Camera distance
    /// </summary>
    [SaveDuringPlay]
#if UNITY_2018_3_OR_NEWER
    [ExecuteAlways]
#else
    [ExecuteInEditMode]
#endif
    public class CinemachineOrbit : CinemachineExtension
    {
        /// <summary>The camera distance to the target</summary>
        [Tooltip("The camera distance to the target")]
        public float m_CameraDistance = 8f;


        /// <summary>Increase this value to soften the aggressiveness of the controls.
        /// Small numbers are more responsive, larger numbers give a more heavy slowly responding camera. </summary>
        [Range(0f, 20f)]
        [Tooltip("Increase this value to soften the aggressiveness of the controls.  Small numbers are more responsive, larger numbers give a more heavy slowly responding camera.")]
        public float m_Damping = 1f;

        CinemachineFramingTransposer _framingTransposer;

        protected override void PostPipelineStageCallback(
            CinemachineVirtualCameraBase vcam,
            CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {

          
            if (stage == CinemachineCore.Stage.Body)
            {
                _framingTransposer = ((CinemachineVirtualCamera)vcam).GetCinemachineComponent<CinemachineFramingTransposer>();

                if (_framingTransposer == null)
                {
                    return;
                    
                }
             
                float d = Vector3.Distance(state.CorrectedPosition, state.ReferenceLookAt);

                float _distance = m_CameraDistance;

                // Apply damping
                if (deltaTime >= 0 && m_Damping > 0)
                {
                    float delta = m_CameraDistance - d;
                    delta = Damper.Damp(delta, m_Damping, deltaTime);
                    _distance = d + delta;
                }


                _framingTransposer.m_CameraDistance = _distance;

            }
        }
    }
}

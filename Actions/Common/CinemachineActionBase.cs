// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

#if UNITY_EDITOR

using UnityEditor;
#endif

using UnityEngine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    // Base class for cinemachine actions.
    public abstract class CinemachineActionBase<T> : ComponentAction<T> where T : Component
    {

#if UNITY_EDITOR && PLAYMAKER_1_9_OR_NEWER

        [DisplayOrder(0)]
        [HideIf("HideActionHeader")]
        public CinemachineActionHeader header;

        const string HideActionHeaderPrefsKey = "PlayMaker.ecosystem.cinemachine.HideActionHeader";
        
		public override void InitEditor (Fsm fsmOwner)
		{
            CinemachineActionHeader.HideActionHeader = EditorPrefs.GetBool(HideActionHeaderPrefsKey, false);

        }

        public bool HideActionHeader()
        {
            return CinemachineActionHeader.HideActionHeader;
        }

        [SettingsMenuItem("Hide Header")]
        public static void ToggleActionHeader()
        {
            CinemachineActionHeader.HideActionHeader = !CinemachineActionHeader.HideActionHeader;
            EditorPrefs.SetBool(HideActionHeaderPrefsKey, CinemachineActionHeader.HideActionHeader);
        }

        [SettingsMenuItemState("Hide Header")]
        public static bool ToggleActionHeaderState()
        {
            return CinemachineActionHeader.HideActionHeader;
        }
        
        
#endif
        
    }
}
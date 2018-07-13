using UnityEditor;

using HutongGames.PlayMakerEditor;
using UnityEngine;
using Cinemachine;

[InitializeOnLoad]
public class PlayMakerCinemachineEditorUtils
{


    static PlayMakerCinemachineEditorUtils()
    {
        Actions.AddCategoryIcon("Cinemachine",CinemachineCategoryIcon);
    }

    private static Texture sCinemachineCategoryIcon = null;
    internal static Texture CinemachineCategoryIcon
    {
        get
        {
            if (sCinemachineCategoryIcon == null)
                sCinemachineCategoryIcon = Resources.Load<Texture>("Cinemachine_playmaker_category_icon");
            ;
            if (sCinemachineCategoryIcon != null)
                sCinemachineCategoryIcon.hideFlags = HideFlags.DontSaveInEditor;
            return sCinemachineCategoryIcon;
        }
    }


}

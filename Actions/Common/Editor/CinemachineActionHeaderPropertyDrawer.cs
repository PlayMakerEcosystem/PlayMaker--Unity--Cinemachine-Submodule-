// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using UnityEngine;

using HutongGames.PlayMakerEditor;

[PropertyDrawer(typeof(CinemachineActionHeader))]
public class CinemachineActionHeaderPropertyDrawer : PropertyDrawer {

    Rect _rect;

    public override object OnGUI(GUIContent label, object obj, bool isSceneObject, params object[] attributes)
    {
        // always keep thsi enabled to avoid transparency artifact ( unless someone tells me how to style up GUIStyle for disable state)
        bool _enabled = GUI.enabled;
        GUI.enabled = true;

        _rect = GUILayoutUtility.GetLastRect();
        GUIDrawRect(_rect, Color.black);
       
        _rect.Set(_rect.x,_rect.y+1,_rect.width,_rect.height-2);
        GUI.DrawTexture(_rect, CinemachineHeader, ScaleMode.ScaleToFit);


        GUI.enabled = _enabled;

        return null;
    }


    private static Texture2D sCinemachineHeader = null;
    internal static Texture2D CinemachineHeader
    {
        get
        {
            if (sCinemachineHeader == null)
                sCinemachineHeader = Resources.Load<Texture2D>("Cinemachine_playmaker_action_header");
            ;
            if (sCinemachineHeader != null)
                sCinemachineHeader.hideFlags = HideFlags.DontSaveInEditor;
            return sCinemachineHeader;
        }
    }

    private static Texture2D _staticRectTexture;
    private static GUIStyle _staticRectStyle;

    // Note that this function is only meant to be called from OnGUI() functions.
    public static void GUIDrawRect(Rect position, Color color)
    {
        if (_staticRectTexture == null)
        {
            _staticRectTexture = new Texture2D(1, 1);
        }

        if (_staticRectStyle == null)
        {
            _staticRectStyle = new GUIStyle();
        }

        _staticRectTexture.SetPixel(0, 0, color);
        _staticRectTexture.Apply();

        _staticRectStyle.normal.background = _staticRectTexture;
    
        GUI.Box(position, GUIContent.none, _staticRectStyle);


    }


}

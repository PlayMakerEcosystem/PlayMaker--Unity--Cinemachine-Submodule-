// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CinemachineBrainProxy))]
public class CinemachineBrainProxyInspector  : Editor
{

    public override void OnInspectorGUI()
    {
        // TODO: better help formating
        GUILayout.Space(2f);
        GUILayout.Label("This proxy will broadcast two Playmaker events:");
        GUILayout.Space(16f);
        GUILayout.Label("CINEMACHINE / ON CAMERA ACTIVATED");
        GUILayout.Label("Event Data will reference the camera activated");
        GUILayout.Space(16f);
        GUILayout.Label("CINEMACHINE / ON CAMERA CUT");
        GUILayout.Label("Event Data will reference the camera being cut");

    }
}

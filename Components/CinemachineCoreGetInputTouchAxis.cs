// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using Cinemachine;
using UnityEngine;

/// <summary>
/// This Component takes control of the CinemachineCore input source, and provides support for Input.Touch
///
/// This is needed if you use for example "CineMachine Free Look" component and want Touch to control the Free Look behaviour.
///
/// "Mouse X" and "Mouse Y" are implemented, if Touches are detected, they are used, else the regular Unity InputManager is used
///
/// For Touch based input, you can control sensitivity, it refers to the number of pixels of a touch deltaPosition that would equate to 1 if it was a regular Input
/// So for a TouchSensitivity of 10, this means an Input value of 1 if the deltaPosition was 10 for that given frame
///
/// For regular Mouse, there is an option to Require a click to active Input, so you click and drag to have Input values.
/// </summary>
public class CinemachineCoreGetInputTouchAxis : MonoBehaviour {

    [Tooltip("Flag to enabled or disable input for all cinemachine logics requiring User Input")]
    public bool InputEnabled = true;
    
    [Tooltip("If true, you need to click the left mouse button for Input to be working. This is not affecting Touch based Input")]
    public bool InputRequiresClick;
    
    [Tooltip("Touch based Input Sensitivity for the X axis. Of 10, this means an Input value of 1 if the deltaPosition was 10 pixels for that given frame")]
    public float TouchSensitivity_x = 10f;
    
    [Tooltip("Touch based Input Sensitivity for the Y axis. Of 10, this means an Input value of 1 if the deltaPosition was 10 pixels for that given frame")]
    public float TouchSensitivity_y = 10f;
    



    
	// Use this for initialization
	void Start () {
        CinemachineCore.GetInputAxis = HandleAxisInputDelegate;
	}

    float HandleAxisInputDelegate(string axisName)
    {
        if (!InputEnabled) return 0f;
        
        switch(axisName)
        {
            case "Mouse X":
                if (Input.touchCount > 0)
                {
                    return Input.touches[0].deltaPosition.x / TouchSensitivity_x;
                }
                else
                {
                    if (!InputRequiresClick || Input.GetMouseButton(0))
                    {
                        return Input.GetAxis(axisName);
                    }else{
                        return 0f;
                    }
                }

            case "Mouse Y":
                if (Input.touchCount > 0)
                {
                    return Input.touches[0].deltaPosition.y / TouchSensitivity_y;
                }
                else
                {
                    if (!InputRequiresClick || Input.GetMouseButton(0))
                    {
                        return Input.GetAxis(axisName);
                    }else
                    {
                        return 0f;
                    }
                }

            default:
                Debug.LogError("CinemachineCoreGetInputTouchAxis : Input <"+axisName+"> not recognyzed.",this);
                break;
        }

        return 0f;
    }
}
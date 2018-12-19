#PlayMaker Cinemachine Change Log

###1.2.5
**Release**  

- 19/12/2018 

**New**

- Support for Impulse Extension, with new actions `GenerateImpulse`, `ImpulseListenerSetProperties`, `ImpulseListenerGetProperties`, `ImpulseSourceSetProperties`, `ImpulseSourceGetProperties`


###1.2.4
**Release**  

- 01/10/2018 

**Update**

- Compatibility with Cinemachie 2.2.7

###1.2.3
**Release**  

- 16/07/2018 

**Update**

- PlayMaker Utils
- Using PlayMaker utils to create global event if needed ( leveraging instead of duplicating feature)


###1.2.2
**Release**  

- 16/07/2018 

**New**

- Submodule handling of Cinemachine: https://github.com/PlayMakerEcosystem/PlayMaker--Unity--Cinemachine-Submodule-

**Update**

- CinemachineColliderExtensionProxy compatible with newer version of Cinemachine ( freelook giving problems with LiveChildOrSelf deprecated)
- CinemachineActionSetAxisSettingsBase and CinemachineActionGetAxisSettingsBase updated for Cinemachine 2.x changes and keep backward compatibilit with 1.x 

**Fix**

- global event automatic generation, getting non global event potentially existing as local before adding new global event.
- Fixed CinemachineColliderExtensionProxy when collider extension is missing on target


###1.2.1
**Release**  

- 28/06/2018 

**Update**

- updated PlayMaker Utils

**New**

- actions `FreeLookCameraSetRigSettings` `FreeLookCameraGetRigSettings` 


###1.2
**Release** 
 
- 25/05/2018 

**New**

- Category Icon for Cinemachine
- actions `ConfinerSetProperties` `ConfinerGetProperties`
- actions `VirtualCameraSetLensSettings` `VirtualCameraGetLensSettings`
- actions `FreeLookCameraSetLensSettings` `FreeLookCameraGetLensSettings`
- actions `FreeLookCameraSetXaxisSettings` `FreeLookCameraGetXaxisSettings`
- actions `FreeLookCameraSetYaxisSettings` `FreeLookCameraGetYaxisSettings`


###1.1
**Release**  

- 17/05/2018 

**Update**

- Updated Cinemachine 2.1.10
- Update PlayMaker 1.9.0 support

**New**  

- actions `MixingCameraSetWeights`.  

###1.0
**Release**  
- 11/04/2018 

**New**  

- actions `FollowZoomGetProperties` `FollowZoomSetProperties`.  
- actions `VirtualCameraGetFollowTarget` `VirtualCameraSetFollowTarget`.  
- actions `VirtualCameraGetFollowTarget` `VirtualCameraSetFollowTarget`.  
- actions `VirtualCameraGetLookAtTarget` `VirtualCameraSetPriority`.  
- Component `CinemachineBrainProxy`.  
- Component `CinemachineCoreGetInputTouchAxis` firing `CINEMACHINE / ON CAMERA ACTIVATED` and `CINEMACHINE / ON CAMERA CUT`.  


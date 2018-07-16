#PlayMaker Cinemachine Change Log

###1.2.2
**Release**  

- n/a 

**New**

- Submodule handling of Cinemachine: https://github.com/PlayMakerEcosystem/PlayMaker--Unity--Cinemachine-Submodule-

**Update**

- CinemachineColliderExtensionProxy compatible with newer version of Cinemachine ( freelook giving problems with LiveChildOrSelf deprecated)
- 

**Fix**

- global event automatic generation, getting non global event potentially existing as local before adding new global event.

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


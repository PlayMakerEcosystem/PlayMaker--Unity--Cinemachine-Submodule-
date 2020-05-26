#PlayMaker Cinemachine Change Log

###1.6
**Release**  

- 26/05/2020 

**New**

- Added axis settings getter and setter for virtual camera Aim POV system

**Update**

- using PlayMaker utils  1.6.2 

###1.5
**Release**  

- 09/04/2020 

**New**

- Added Recentering fields to actions featuring AxisSettings

###1.4
**Release**  

- 30/03/2020 

**New**

- Added Value and InputValue fields to actions featuring AxisSettings

###1.3
**Release**  

- 17/01/2020 

**New**

- New action `TargetGroupSetTargets`

###1.2.9
**Release**  

- 15/10/2019 

**New**

- New action `VirtualCameraGetCurrentActive`

**fixed**

- Fixed `CinemachineBrainProxy` event handling when previous camera is null


###1.2.8
**Release**  

- 20/09/2019 

**New**

- New action `SetEnableCoreInput`
- New Option InputEnabled in `CinemachineCoreGetInputTouchAxis`
- New actions `CameraOffsetGetProperties` `CameraOffsetSetProperties`


###1.2.7
**Release**  

- 11/09/2019 

**Update**

- using Cinemachine 2.2.9
- using PlayMaker utils  1.6.0  

**New**

- New actions `CinemachineActionGetFramingTransposerSettingsBase`, `CinemachineActionSetFramingTransposerSettingsBase`

###1.2.6
**Release**  

- 07/01/2019 

**New**

- New action `ConfinerInvalidatePathCache`

**fixed**

- Fixed `ConfinerSetProperties` to call InvalidatePathCache if 2d confiner collider changed.  


###1.2.5
**Release**  

- 19/12/2018 

**New**

- Support for Impulse Extension, with new actions `GenerateImpulse`, `ImpulseListenerSetProperties`, `ImpulseListenerGetProperties`, `ImpulseSourceSetProperties`, `ImpulseSourceGetProperties`


###1.2.4
**Release**  

- 01/10/2018 

**Update**

- Compatibility with Cinemachine 2.2.7

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


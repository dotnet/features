# Write code for a family of Windows 10 devices

Windows 10 introduces the Universal Windows Platform (UWP), which further
evolves the Windows Runtime model and brings it into the Windows 10 unified
core. As part of the core, the UWP now provides a common app platform available
on every device that runs Windows 10. With this evolution, apps that target the
UWP can call not only the WinRT APIs that are common to all devices, but also
APIs (including Win32 and .NET APIs) that are specific to the device family the
app is running on. The UWP provides a guaranteed core API layer across devices.
This means you can create a single app package that can be installed onto a wide
range of devices. And, with that single app package, the Windows Store provides
a unified distribution channel to reach all the device types your app can run
on.

Device families are as follows:

* Embedded devices and IoT
* Mobile devices such as phones and tablets
* Desktop
* XBox
* Surface Hub
* HoloLens

Because your UWP app runs on a wide variety of devices with different form
factors and input modalities, you want it to be tailored to each device and be
able to unlock the unique capabilities of each device. Devices add their own
unique APIs to the guaranteed API layer. You can write code to access those
unique APIs conditionally so that your app lights up features specific to one
type of device while presenting a different experience on other devices.
Adaptive UI controls and new layout panels help you to tailor your UI across a
broad range of screen resolutions.

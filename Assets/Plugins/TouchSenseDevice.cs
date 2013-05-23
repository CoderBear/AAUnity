/*
** =========================================================================
** Copyright (c) 2012 Immersion Corporation.  All rights reserved.
**                    Immersion Corporation Confidential and Proprietary
**
** File:
**  TouchSenseDevice.cs
**
** Description:
**  Unity3d C# code for defining a device
** =========================================================================
*/

using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;

/// <summary>
/// Class representing a vibration device
///
/// This device can be a discrete actuator like a eccentric rotating mass motor, a linear resonant actuator,
/// a piezo strip or something similar, or a composite device which is a logical combination of some or all
/// of the available discrete actuators available.
/// </summary>
public abstract class TouchSenseDevice {

    protected int m_deviceHandle = -1;
    private static int m_count = -1;

    /// <summary>
    /// The device actuator type
    /// </summary>
    public enum ActuatorType
    {
        Unknown,
        Composite,
        ERM,
        LRA,
        BLDC,
        Piezo
    }

    /// <summary>
    /// The number of available devices that are supported.
    /// </summary>
    public static int count
    {
        get
        {
            if (m_count < 0)
            {
#if UNITY_ANDROID
                m_count = ImmVibeGetDeviceCount();
#endif
            }
            return m_count;
        }
    }


    /// <summary>
    /// The actuator type, see <see cref="ActuatorType"/>
    /// </summary>
    public abstract ActuatorType type
    {
        get;
    }

    ~TouchSenseDevice()
    {
        if (m_deviceHandle >= 0)
        {
#if UNITY_ANDROID
            ImmVibeCloseDevice(m_deviceHandle);
#endif
        }
    }

    internal int deviceHandle
    {
        get
        {
            if (m_deviceHandle < 0) openDevice();
            return m_deviceHandle;
        }
    }

    /// <summary>
    /// Stops all playing and paused effects on this device.
    /// </summary>
    public void stopAllEffects()
    {
#if UNITY_ANDROID
        int rv = ImmVibeStopAllPlayingEffects(m_deviceHandle);
        if (rv != 0) Debug.LogError("TouchSenseDevice: StopAllPlayingEffects failed with error code " + rv);
#endif
    }

    protected abstract bool openDevice();

#if UNITY_ANDROID
    [DllImport("libImmEmulatorJ.so")]
    private static extern int ImmVibeOpenDevice(int nDeviceIndex, ref int phDeviceHandle);
    [DllImport("libImmEmulatorJ.so")]
    private static extern int ImmVibeCloseDevice(int hDeviceHandle);
    [DllImport("libImmEmulatorJ.so")]
    private static extern int ImmVibeStopAllPlayingEffects(int hDeviceHandle);
    [DllImport("libImmEmulatorJ.so")]
    private static extern int ImmVibeGetDeviceCount();
#endif

}

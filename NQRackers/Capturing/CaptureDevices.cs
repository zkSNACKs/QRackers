////////////////////////////////////////////////////////////////////////////
//
// FlashCap - Independent camera capture library.
// Copyright (c) Kouji Matsui (@kozy_kekyo, @kekyo@mastodon.cloud)
//
// Licensed under Apache-v2: https://opensource.org/licenses/Apache-2.0
//
////////////////////////////////////////////////////////////////////////////

using NQRackers.Capturing.Devices;
using NQRackers.Capturing.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace NQRackers.Capturing;

public class CaptureDevices
{
    protected virtual IEnumerable<CaptureDeviceDescriptor> OnEnumerateDescriptors() =>
        NativeMethods.CurrentPlatform switch
        {
            NativeMethods.Platforms.Windows =>
                new DirectShowDevices().OnEnumerateDescriptors().
                Concat(new VideoForWindowsDevices().OnEnumerateDescriptors()),
            NativeMethods.Platforms.Linux =>
                new V4L2Devices().OnEnumerateDescriptors(),
            _ =>
                ArrayEx.Empty<CaptureDeviceDescriptor>(),
        };

    internal IEnumerable<CaptureDeviceDescriptor> InternalEnumerateDescriptors() =>
        this.OnEnumerateDescriptors();
}

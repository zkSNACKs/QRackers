////////////////////////////////////////////////////////////////////////////
//
// FlashCap - Independent camera capture library.
// Copyright (c) Kouji Matsui (@kozy_kekyo, @kekyo@mastodon.cloud)
//
// Licensed under Apache-v2: https://opensource.org/licenses/Apache-2.0
//
////////////////////////////////////////////////////////////////////////////

using System;
using System.IO;

namespace NQRackers.Capturing.Utilities;

public static class Extension
{
    public static Stream AsStream(this ArraySegment<byte> segment) =>
        segment.Array is { } ?
            new MemoryStream(segment.Array, segment.Offset, segment.Count) :
            new MemoryStream(ArrayEx.Empty<byte>());

    public static Stream AsStream(this byte[]? data) =>
        data is { } ?
            new MemoryStream(data) :
            new MemoryStream(ArrayEx.Empty<byte>());
}

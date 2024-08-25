using System.Runtime.InteropServices;
using Raylib_cs.BleedingEdge.Enums;
using Raylib_cs.BleedingEdge.Enums.Raylib;

namespace Raylib_cs.BleedingEdge.Types.Raylib;

/// <summary>
/// NPatchInfo, n-patch layout info
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NPatchInfo
{
    /// <summary>
    /// Texture source rectangle
    /// </summary>
    public Rectangle Source;

    /// <summary>
    /// Left border offset
    /// </summary>
    public int Left;

    /// <summary>
    /// Top border offset
    /// </summary>
    public int Top;

    /// <summary>
    /// Right border offset
    /// </summary>
    public int Right;

    /// <summary>
    /// Bottom border offset
    /// </summary>
    public int Bottom;

    /// <summary>
    /// Layout of the n-patch: 3x3, 1x3 or 3x1
    /// </summary>
    public NPatchLayout Layout;
}
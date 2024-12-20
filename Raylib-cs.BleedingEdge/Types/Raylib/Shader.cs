using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Shader
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Shader
{
    /// <summary>
    /// Shader program id
    /// </summary>
    public uint Id;

    /// <summary>
    /// Shader locations array (RL_MAX_SHADER_LOCATIONS)
    /// </summary>
    public unsafe int* Locs;

    public override string ToString()
    {
        return $"<Id:{Id}>";
    }
}
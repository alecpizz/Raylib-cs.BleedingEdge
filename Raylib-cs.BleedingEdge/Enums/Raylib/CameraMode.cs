namespace Raylib_cs.BleedingEdge.Enums.Raylib;

/// <summary>
/// Camera system modes
/// </summary>
public enum CameraMode
{
    /// <summary>
    /// Camera custom, controlled by user (UpdateCamera() does nothing)
    /// </summary>
    Custom = 0,

    /// <summary>
    /// Camera free mode
    /// </summary>
    Free,

    /// <summary>
    /// Camera orbital, around target, zoom supported
    /// </summary>
    Orbital,

    /// <summary>
    /// Camera first person
    /// </summary>
    FirstPerson,

    /// <summary>
    /// Camera third person
    /// </summary>
    ThirdPerson
}
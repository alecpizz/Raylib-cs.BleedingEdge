using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

public static unsafe partial class Raylib
{
    private static AudioMixedCallback? _audioMixedCallback;
    
    /// <summary>
    /// Get the human-readable, UTF-8 encoded name of the specified monitor
    /// </summary>
    /// <remarks>
    /// Same as <see cref="GetMonitorNameString"/>
    /// </remarks>
    public static string GetMonitorName_(int monitor)
    {
        return Marshal.PtrToStringUTF8((IntPtr)GetMonitorName(monitor)) ?? string.Empty;
    }

    /// <summary>
    /// Get clipboard text content
    /// </summary>
    /// <remarks>
    /// Same as <see cref="GetClipboardTextString"/>
    /// </remarks>
    public static string GetClipboardText_()
    {
        return Marshal.PtrToStringUTF8((nint)GetClipboardText()) ?? string.Empty;
    }
    
    /// <summary>
    /// Get current working directory (uses static string)
    /// </summary>
    /// <remarks>
    /// Same as <see cref="GetWorkingDirectoryString"/>
    /// </remarks>
    public static string GetWorkingDirectory_()
    {
        return Marshal.PtrToStringUTF8((nint)GetWorkingDirectory()) ?? string.Empty;
    }

    /// <summary>
    /// Get the directory of the running application (uses static string)
    /// </summary>
    /// <remarks>
    /// Same as <see cref="GetApplicationDirectory_"/>
    /// </remarks>
    public static string GetApplicationDirectory_()
    {
        return Marshal.PtrToStringUTF8((nint)GetApplicationDirectory()) ?? string.Empty;
    }

    /// <summary>
    /// Load dropped filepaths
    /// </summary>
    /// <remarks>
    /// Same as <see cref="LoadDroppedFiles"/> + <see cref="UnloadDroppedFiles"/>
    /// </remarks>
    public static string[] GetDroppedFiles()
    {
        var files = LoadDroppedFiles();
        var result = new string[files.Count];

        for (var i = 0; i < files.Count; i++)
        {
            result[i] = files.PathsArray[i];
        }

        UnloadDroppedFiles(files);
        return result;
    }
    
    /// <summary>
    /// Attach audio stream processor to the entire audio pipeline
    /// </summary>
    public static void AttachAudioMixedProcessor(AudioMixedCallback processor)
    {
        if (_audioMixedCallback != null) return;
        _audioMixedCallback = processor;
        AttachAudioMixedProcessor(&AudioMixedProcessorCallback);
    }

    /// <summary>
    /// Detach audio stream processor from the entire audio pipeline
    /// </summary>
    public static void DetachAudioMixedProcessor(AudioMixedCallback processor)
    {
        if (_audioMixedCallback == null || _audioMixedCallback != processor) return;
        DetachAudioMixedProcessor(&AudioMixedProcessorCallback);
        _audioMixedCallback = null;
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void AudioMixedProcessorCallback(void* bufferData, uint frames)
    {
        _audioMixedCallback?.Invoke(new Span<float>(bufferData, (int)uint.Min(frames * 2, int.MaxValue)));
    }
    
    /// <summary>
    /// Gets reference to material from model
    /// </summary>
    /// <remarks>
    /// Same as <code>model.Materials[materialIndex]</code>
    /// </remarks>
    public static ref Material GetMaterial(ref Model model, int materialIndex)
    {
        return ref model.Materials[materialIndex];
    }

    /// <summary>
    /// Gets reference to texture from model
    /// </summary>
    /// <remarks>
    /// Same as <code>model.Materials[materialIndex].Maps[(int)mapIndex].Texture</code>
    /// </remarks>
    public static ref Texture2D GetMaterialTexture(ref Model model, int materialIndex, MaterialMapIndex mapIndex)
    {
        return ref model.Materials[materialIndex].Maps[(int)mapIndex].Texture;
    }

    /// <summary>
    /// Set shader for a material map type in model
    /// </summary>
    public static void SetMaterialShader(ref Model model, int materialIndex, ref Shader shader)
    {
        model.Materials[materialIndex].Shader = shader;
    }
}
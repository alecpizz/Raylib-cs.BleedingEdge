<img align="left" width="160" height="160" src="https://raw.githubusercontent.com/danilwhale/Raylib-cs.BleedingEdge/main/Assets/Logo-256.png" alt="Logo">

### Raylib-cs.BleedingEdge

Bleeding-edge C# bindings for raylib, a simple and easy-to-use library to learn videogames programming (www.raylib.com)

[![Discord](https://img.shields.io/discord/426912293134270465?style=flat-square&logo=discord&logoColor=white)](https://discord.gg/raylib)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Raylib-cs.BleedingEdge?style=flat-square&logo=nuget)](https://www.nuget.org/packages/Raylib-cs.BleedingEdge)
[![GitHub License](https://img.shields.io/github/license/danilwhale/Raylib-cs.BleedingEdge?style=flat-square)](https://github.com/danilwhale/Raylib-cs.BleedingEdge/blob/main/LICENSE)
[![GitHub Repo stars](https://img.shields.io/github/stars/danilwhale/Raylib-cs.BleedingEdge?style=flat-square)](https://github.com/danilwhale/Raylib-cs.BleedingEdge/stargazers)
[![GitHub commit activity](https://img.shields.io/github/commit-activity/w/danilwhale/Raylib-cs.BleedingEdge?style=flat-square)](https://github.com/danilwhale/Raylib-cs.BleedingEdge/commits/main/)
[![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/danilwhale/Raylib-cs.BleedingEdge/build.yml?style=flat-square&logo=githubactions&logoColor=white)](https://github.com/danilwhale/Raylib-cs.BleedingEdge/actions)

---

Raylib-cs.BleedingEdge targets .NET 8+ and
uses [the master branch of raylib](https://github.com/raysan5/raylib/tree/master)

> You can reference [raylib-cs](https://github.com/chrisdill/raylib-cs/tree/master/Examples)
> and [raylib](https://github.com/raysan5/raylib/tree/master/examples) examples
> as this binding has mostly same function signatures (see [API differences](#api-differences))

installation
---

```
$ dotnet add package Raylib-cs.BleedingEdge --prerelease
$ dotnet add package Raylib-cs.BleedingEdge.Runtimes --prerelease
```

if you need...
---

- ... just runtimes: install `Raylib-cs.BleedingEdge.Runtimes`.

- ... custom native build: uninstall `Raylib-cs.BleedingEdge.Runtimes` and
add [CompileNatives.props](https://raw.githubusercontent.com/danilwhale/Raylib-cs.BleedingEdge/refs/heads/main/Raylib-cs.BleedingEdge.Native/CompileNatives.props)
to your project and import it (add `<Import Project="CompileNatives.props"/>`). You also need to clone [raylib](https://github.com/raysan5/raylib) repo and specify path to it in the `CustomNatives.props` (by default it's `../raylib`)

- ... to compile a static library: add `<CompileShared>false</CompileShared>` to your project's `PropertyGroup`. Note that you need custom native build setup for this (read above).

- ... prebuilt static library: you can get it from [GitHub Actions](https://github.com/danilwhale/Raylib-cs.BleedingEdge/actions/workflows/build-static-natives.yaml). You need GitHub account to do this.

basic example
---

```csharp
using Raylib_cs.BleedingEdge;
using static Raylib_cs.BleedingEdge.Raylib;

const int screenWidth = 800;
const int screenHeight = 450;

InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window");

while (!WindowShouldClose())
{
    BeginDrawing();
    ClearBackground(Color.RayWhite);
    
    DrawText("Congrats! You created your first window!", 190, 200, 20, Color.LightGray);
    
    EndDrawing();
}

CloseWindow();
```

differences from [raylib-cs](https://github.com/ChrisDill/Raylib-cs)
---

### main differences

| [raylib-cs](https://github.com/chrisdill/raylib-cs) | Raylib-cs.BleedingEdge  |
|-----------------------------------------------------|-------------------------|
| .NET 6.0+                                           | .NET 8.0+               |
| Released 07-2018                                    | Released 08-2024        |
| raylib 5.0                                          | raylib 5.6-dev          |

### API differences

> [!NOTE]
> There are minor name differences, such as `WindowHighDpi` instead of `HighDpiWindow`,
> `KbMenu` instead of `KeyboardMenu`, etc.

| [raylib-cs](https://github.com/chrisdill/raylib-cs) | Raylib-cs.BleedingEdge                      |
|-----------------------------------------------------|---------------------------------------------|
| `using Raylib_cs`                                   | `using Raylib_cs.BleedingEdge`              |
| `T[]` for functions with array pointers             | `Span<T>` for functions with array pointers |
| `int` argument for the length of array              | -, use `Span<T>.Slice` if necessary         |
| `Utf8Buffer`                                        | `Utf8Handle`                                |

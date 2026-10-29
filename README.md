# Lawnmower

Client-side SPT mod by hazelify, version 1.0.0. Licensed under the MIT license.

Lawnmower disables the terrain-detail GPU instancers found at raid start and hides the grass prototypes populated by `GrassInitialization` through prefab managers. It applies automatically once at raid start and skips the hideout. The game can fall back to ordinary terrain-detail rendering for the terrain-detail path.

For prefab grass, the mod sets the grass prototype's instance count to zero. Other prototypes and unrelated prefab managers are unaffected.

There are no settings or hotkeys. Previous configuration entries are no longer used.

## Building

Requires the .NET SDK with support for `.slnx` solutions and an SPT 4.1 installation. References are read from the installation rather than bundled in this repository.

```powershell
./build.ps1
./build.ps1 -SPTPath 'E:\Games\SPT\4.1' -Configuration Debug
./build.ps1 -PackageRelease
```

The default build uses `E:\Games\SPT\4.1` and Release configuration. The DLL is written to `bin/Release/netstandard2.1/hazelify-Lawnmower.dll`. Building does not install the mod.

`-PackageRelease` creates `releases/hazelify-Lawnmower-1.0.0.zip` with the `BepInEx/plugins` directory layout.

The build script also supports explicit `-InstallMod` and `-InstallMod -HotReload`, following the other mods' build convention. These options write to the selected SPT installation. Hot reload installs the DLL and symbols into `BepInEx/scripts`; normal installation uses `BepInEx/plugins`.

When replacing an older installation, remove its `Lawnmower.dll` before installing `hazelify-Lawnmower.dll`. The plugin GUID is unchanged.

## Source layout

- `Plugin.cs`: plugin initialization.
- `Patches/RaidStartedPatch.cs`: raid validation and one-time terrain-detail and prefab-grass suppression.
- `Directory.Build.props`: mod metadata and output naming.
- `Directory.Build.targets`: generated metadata, optional installation, and release staging.
- `Directory.Solution.props` / `Directory.Solution.targets`: solution metadata and release ZIP packaging.

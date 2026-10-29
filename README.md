# Lawnmower

Client-side SPT mod by hazelify, version 1.0.0. Licensed under the MIT license.

Lawnmower disables the terrain-detail GPU instancers found at raid start. Press **F10** to toggle it during a raid, or use the BepInEx configuration manager. It skips the hideout. The game can fall back to ordinary terrain-detail rendering; grass rendered through separate prefab managers is unaffected.

## Configuration

Settings are stored in `BepInEx/config/hazelify.Lawnmower.cfg`:

| Setting | Default | Purpose |
| --- | --- | --- |
| Enable the mod | `true` | Toggle the terrain-detail managers during a raid. |
| Master switch hotkey | `F10` | Keyboard shortcut for the toggle. |

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

When replacing an older installation, remove its `Lawnmower.dll` before installing `hazelify-Lawnmower.dll`. The plugin GUID and configuration keys are unchanged.

## Source layout

- `Plugin.cs`: plugin initialization, configuration, and hotkey.
- `Patches/RaidStartedPatch.cs`: raid-start hook.
- `Grass/Loader.cs`: raid validation and component setup.
- `Grass/Lawnmower.cs`: terrain-detail discovery and toggling.
- `Directory.Build.props`: mod metadata and output naming.
- `Directory.Build.targets`: generated metadata, optional installation, and release staging.
- `Directory.Solution.props` / `Directory.Solution.targets`: solution metadata and release ZIP packaging.

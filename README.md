# Lawnmower

> 

**Author:** hazelify  
**Version:** 1.0.0  
**SPT Version:** 4.1.6  
**License:** MIT

---

## What This Mod Does

Describe what your mod does here.

This template includes BepInEx Configuration examples. All settings are editable in-game via the **F12** config manager or by editing the config file at `BepInEx/config/hazelify.Lawnmower.cfg`.

### Included Config Entries

| Setting | Type | Default | Description |
|---|---|---|---|
| Enable Mod | `bool` | `true` | Enables or disables the mod |
| Example Integer | `int` | `5` | Integer with slider (0–100) |
| Example Float | `float` | `1.0` | Float with slider (0–10) |
| Example String | `string` | `Hello SPT` | Simple string setting |
| Enum Selection | `enum` | `OptionA` | Dropdown selection |
| Action Key | `KeyboardShortcut` | `F10` | Remappable keybind |
| Overlay Color | `Color` | `red` | Color picker |

---

## Requirements

- [SPT](https://sp-mod.com/) 4.1.2 or later 4.1.x installed (BepInEx is included)
- .NET SDK (`netstandard2.1`-compatible) for building from source

---

## Building

```sh
cd Lawnmower
dotnet build -c Release
```

The PostBuild target automatically copies the compiled DLL to your SPT installation's `BepInEx\plugins\` folder.
The project also packages the mod into a distributable `Lawnmower.zip` ready to be uploaded.

---

## Installation

1. Build the project (see above) **or** download the latest release DLL.
2. Copy `Lawnmower.dll` to `<SPT install>\BepInEx\plugins\`.
3. Launch SPT as usual.
4. Press **F12** in-game to open the config manager and adjust settings.

---

## Project Structure

```
Lawnmower/
├── Lawnmower.csproj   ← project file with DLL references
├── Plugin.cs              ← BepInEx plugin with config entries
├── README.md
└── .gitignore
```

---

## Learning Resources

| Resource | URL |
|---|---|
| BepInEx Configuration Docs | https://github.com/BepInEx/BepInEx.ConfigurationManager/blob/master/README.md|
| SPT Client Mod Migration (4.1) | https://wiki.sp-tushonka.com/en/modding/SPT_41_Modding/Client_40_to_41 |
| SPT Wiki Modding Resources | https://wiki.sp-tushonka.com/en/modding/Modding_Resources |

---

using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using hazelify.Lawnmower.Patches;
using UnityEngine;

namespace hazelify.Lawnmower;

[BepInPlugin(MyModInfo.MOD_GUID, MyModInfo.MOD_NAME, MyModInfo.MOD_VERSION)]
public class Plugin : BaseUnityPlugin
{
    public static ManualLogSource LogSource;
    public static ConfigEntry<bool> MasterSwitch;
    public static ConfigEntry<KeyboardShortcut> MasterSwitchHotkey;

    private void Awake()
    {
        LogSource = Logger;
        InitConfiguration();
        new RaidStartedPatch().Enable();
        LogSource.LogInfo($"[{MyModInfo.MOD_NAME}] Loaded!");
    }

    private void Update()
    {
        if (MasterSwitchHotkey.Value.IsDown())
            MasterSwitch.Value = !MasterSwitch.Value;
    }

    private void InitConfiguration()
    {
        MasterSwitch = Config.Bind(
            "Master switch",
            "Enable the mod",
            true,
            "Enables or disables the mod, and can be toggled in realtime"
        );

        MasterSwitchHotkey = Config.Bind(
            "Master switch",
            "Master switch hotkey",
            new KeyboardShortcut(KeyCode.F10),
            "What hotkey to use for the realtime Master Switch."
        );
    }
}

using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using hazelify.Lawnmower.Patches;
using hazelify.Lawnmower.Scripts;
using UnityEngine;

namespace hazelify.Lawnmower
{
    [BepInPlugin("hazelify.Lawnmower", "Lawnmower", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static ManualLogSource LogSource;
        public static ConfigEntry<bool> masterSwitch;
        // public static ConfigEntry<float> maxDistance;
        // public static ConfigEntry<float> timeToCheck;
        public static ConfigEntry<KeyboardShortcut> hotkeyMasterSwitch;

        private void Awake()
        {
            LogSource = Logger;
            InitConfiguration();
            new Patcher().Enable();
            LogSource.LogInfo($"[Lawnmower] Loaded!");
        }

        private void Update()
        {
            if (Plugin.hotkeyMasterSwitch.Value.IsDown())
            {
                Plugin.masterSwitch.Value = !Plugin.masterSwitch.Value;
            }
        }

        private void InitConfiguration()
        {
            masterSwitch = Config.Bind(
                "Master switch",
                "Enable the mod",
                true,
                "Enables or disables the mod, and can be toggled in realtime"
            );

            hotkeyMasterSwitch = Config.Bind(
                "Master switch",
                "Master switch hotkey",
                new KeyboardShortcut(KeyCode.F10),
                "What hotkey to use for the realtime Master Switch."
            );

            /*
            maxDistance = Config.Bind(
                "General",
                "Maximum distance before Lawnmowing (meters)",
                10f,
                new ConfigDescription(
                    "How far away in meters grass should render from the player before it all starts being Lawnmowed",
                    new AcceptableValueRange<float>(0f, 100f)
                )
            );
            */

            /*
            timeToCheck = Config.Bind(
                "General",
                "Grass scan interval (seconds",
                10f,
                new ConfigDescription(
                    "If `Minimum distance` is not 0, how often should the mod scan for grass?\n\nValue is in seconds",
                    new AcceptableValueRange<float>(1f, 100f)
                )
            );
            */
        }
    }
}

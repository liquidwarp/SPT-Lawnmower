using System;
using System.Collections.Generic;
using System.Reflection;
using EFT;
using GPUInstancer;
using HarmonyLib;
using SPT.Reflection.Patching;

namespace hazelify.Lawnmower.Patches;

public class RaidStartedPatch : ModulePatch
{
    protected override MethodBase GetTargetMethod() =>
        AccessTools.Method(typeof(GameWorld), nameof(GameWorld.OnGameStarted));

    [PatchPostfix]
    public static void Postfix(GameWorld __instance)
    {
        if (__instance == null)
            return;

        var player = __instance.MainPlayer;
        if (player == null || string.Equals(player.Location, "hideout", StringComparison.OrdinalIgnoreCase))
            return;

        foreach (var manager in UnityEngine.Object.FindObjectsOfType<GPUInstancerDetailManager>())
        {
            if (manager.enabled)
                manager.enabled = false;
        }

        var managers = new List<GPUInstancerPrefabManager>();
        foreach (var initialization in UnityEngine.Object.FindObjectsOfType<GrassInitialization>())
        {
            if (initialization.prefab == null || initialization.prefab.prefabPrototype == null)
                continue;

            managers.Clear();
            initialization.GetComponents(managers);
            foreach (var manager in managers)
            {
                if (!manager.enabled)
                    continue;

                var data = manager.GetRuntimeData(initialization.prefab.prefabPrototype);
                if (data != null)
                    data.instanceCount = 0;
            }
        }
    }
}

using System.Reflection;
using Comfort.Common;
using EFT;
using HarmonyLib;
using hazelify.Lawnmower.Grass;
using SPT.Reflection.Patching;

namespace hazelify.Lawnmower.Patches;

public class RaidStartedPatch : ModulePatch
{
    protected override MethodBase GetTargetMethod() =>
        AccessTools.Method(typeof(GameWorld), nameof(GameWorld.OnGameStarted));

    [PatchPostfix]
    public static void Postfix()
    {
        var gameWorld = Singleton<GameWorld>.Instance;
        if (gameWorld == null)
            return;

        gameWorld.gameObject.AddComponent<Loader>();
    }
}

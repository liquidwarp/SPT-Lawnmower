using Comfort.Common;
using EFT;
using HarmonyLib;
using SPT.Reflection.Patching;
using System.Reflection;
using hazelify.Lawnmower.Scripts;
using EFT.UI;

namespace hazelify.Lawnmower.Patches
{
    public class Patcher : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(GameWorld), nameof(GameWorld.OnGameStarted));
        }

        [PatchPostfix]
        public static void PatchPostfix()
        {
            var gameWorld = Singleton<GameWorld>.Instance;

            if (gameWorld == null) return;
            gameWorld.gameObject.AddComponent<Loader>();
        }
    }
}

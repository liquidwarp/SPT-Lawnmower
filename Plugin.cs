using BepInEx;
using hazelify.Lawnmower.Patches;

namespace hazelify.Lawnmower;

[BepInPlugin(MyModInfo.MOD_GUID, MyModInfo.MOD_NAME, MyModInfo.MOD_VERSION)]
public class Plugin : BaseUnityPlugin
{
    private void Awake()
    {
        new RaidStartedPatch().Enable();
        Logger.LogInfo($"[{MyModInfo.MOD_NAME}] Loaded!");
    }
}

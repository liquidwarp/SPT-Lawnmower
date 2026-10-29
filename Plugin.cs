using BepInEx;
using hazelify.Lawnmower.Patches;

namespace hazelify.Lawnmower;

[BepInPlugin(MyModInfo.MOD_GUID, MyModInfo.MOD_NAME, MyModInfo.MOD_VERSION)]
public class Plugin : BaseUnityPlugin
{
    private readonly RaidStartedPatch _raidStartedPatch = new();

    private void Awake()
    {
        _raidStartedPatch.Enable();
        Logger.LogInfo($"[{MyModInfo.MOD_NAME}] Loaded!");
    }

    private void OnDestroy()
    {
        _raidStartedPatch.Disable();
    }
}

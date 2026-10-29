using Comfort.Common;
using EFT;
using EFT.UI;
using UnityEngine;

namespace hazelify.Lawnmower.Grass;

public class Loader : MonoBehaviour
{
    private void Awake()
    {
        var gameWorld = Singleton<GameWorld>.Instance;
        if (gameWorld == null)
        {
            ConsoleScreen.LogError("[Lawnmower] GameWorld not found");
            Destroy(this);
            return;
        }

        var player = gameWorld.MainPlayer;
        if (player == null)
        {
            ConsoleScreen.LogError("[Lawnmower] Player not found");
            Destroy(this);
            return;
        }

        if (player.Location.ToLower() == "hideout")
        {
            ConsoleScreen.LogError("[Lawnmower] Cannot run in Hideout");
            Destroy(this);
            return;
        }

        gameWorld.gameObject.AddComponent<Lawnmower>();
    }
}

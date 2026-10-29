using System;
using System.Collections.Generic;
using System.Linq;
using GPUInstancer;
using UnityEngine;

namespace hazelify.Lawnmower.Grass;

public class Lawnmower : MonoBehaviour
{
    private List<GPUInstancerDetailManager> _grassObjects;

    private void Awake()
    {
        FetchObjects();
        if (Plugin.MasterSwitch.Value)
            DisableObjects();

        Plugin.MasterSwitch.SettingChanged += HandleSettingChanged;
    }

    private void OnDestroy()
    {
        Plugin.MasterSwitch.SettingChanged -= HandleSettingChanged;
    }

    private void HandleSettingChanged(object sender, EventArgs args)
    {
        if (Plugin.MasterSwitch.Value)
            DisableObjects();
        else
            RestoreObjects();
    }

    private void RestoreObjects()
    {
        if (_grassObjects == null)
            return;

        foreach (var item in _grassObjects)
        {
            if (item == null)
                continue;

            item.SetEnabledUniversal(true);
        }
    }

    private void FetchObjects()
    {
        _grassObjects = FindObjectsOfType<GPUInstancerDetailManager>().Where(i => i.IsEnabledUniversal()).ToList();
    }

    private void DisableObjects()
    {
        if (_grassObjects == null)
            return;

        foreach (var item in _grassObjects)
        {
            if (item == null && !item.IsEnabledUniversal())
                continue;

            item.SetEnabledUniversal(false);
        }
    }
}

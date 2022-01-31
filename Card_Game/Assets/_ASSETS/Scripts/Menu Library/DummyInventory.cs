using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using LocalPlayerData;
using System;

public class DummyInventory : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var request = new GetUserInventoryRequest { AuthenticationContext = AccountData.Instance.data.AuthenticationContext };
            PlayFabClientAPI.GetUserInventory(request, GetInventorySuccess, GetInventoryFailed);
        }
    }

    private void GetInventorySuccess(GetUserInventoryResult obj)
    {
        foreach (var item in obj.Inventory)
        {
            print($"Inventory item class: {item.ItemClass}");
        }
    }

    private void GetInventoryFailed(PlayFabError obj)
    {
        throw new NotImplementedException();
    }
}

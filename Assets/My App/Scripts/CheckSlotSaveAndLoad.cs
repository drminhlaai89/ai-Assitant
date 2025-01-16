using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSlotSaveAndLoad : MonoBehaviour
{
    public bool saveSlot1;
    public bool saveSlot2;
    public bool saveSlot3;

    public void SelectSlot1()
    {
        saveSlot1 = true;
        saveSlot2 = false;
        saveSlot3 = false;
    }
    public void SelectSlot2()
    {
        saveSlot1 = false;
        saveSlot2 = true;
        saveSlot3 = false;
    }
    public void SelectSlot3()
    {
        saveSlot1 = false;
        saveSlot2 = false;
        saveSlot3 = true;
    }
}

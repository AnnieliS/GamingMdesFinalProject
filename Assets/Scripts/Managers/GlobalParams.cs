using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GlobalParams
{
    public Dictionary<string, int> roomRobiDialogueIndex = new Dictionary<string, int>();
    public Dictionary<string, string> portals = new Dictionary<string, string>();

    public Dictionary<string, bool> bedRoomParams = new Dictionary<string, bool>();
    
    public GlobalParams()
    {
        roomRobiDialogueIndex.Add("01_Bedroom", 0);
        roomRobiDialogueIndex.Add("02_OverWorld", 0);
        roomRobiDialogueIndex.Add("03_Gegloo", 0);
        // Add scene names when relevant
        // roomRobiDialogueIndex.Add("yoha",0);
        // roomRobiDialogueIndex.Add("utub", 0);

        portals.Add("playerInit", "playerInit");
        portals.Add("BedroomToOverworld", "playerInit");
        portals.Add("OverworldToGegloo", "OverworldGegloo");
        portals.Add("GeglooToOverworld", "OverworldGegloo");
        portals.Add("OverworldToUtub", "utubPortal");
        portals.Add("blackpillPortal", "blackpillPortal");
        portals.Add("diyPortal", "diyPortal");


        bedRoomParams.Add("DIYFire", false);

    }

}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OverworldBlackboard : MonoBehaviour {

    public static OverworldBlackboard instance;
        
    public PartyManager party;

    public Place[] places;

    public string sPlaceNameHolder;
    public bool bBurn;

    #region private funcs
    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if( bBurn )
        {
            foreach (Place p in places)
            {
                if (p.sName == sPlaceNameHolder)
                {
                    p.TakeHostileAction();
                    bBurn = false;
                    break;
                }
            }
        }
    }

    void ChangeToTownScene(Place place)
    {
        GameManager.SetPlaceInfo(place);
        GameManager.placeInfoHolder.GatherInfo(places);
        GameManager.ChangeScene(GameManager.SceneDirectory.TownUIDevelop);
    }

    void SentVillageBurnMessage( string sPlaceName )
    {
        foreach( Place p in places)
        {
            if (p.name == sPlaceName)
            {
                p.TakeHostileAction();
            }
        }
    }

    #endregion

    public static void EnterTown( Place place )
    {
        instance.ChangeToTownScene(place);
    }

    public static void BurnVillage(string sPlaceName)
    {
        instance.bBurn = true;
        instance.sPlaceNameHolder = sPlaceName;
    }

}

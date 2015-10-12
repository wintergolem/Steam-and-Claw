using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct RaidedCounter
{
    public float fTimeRaided;
}

public struct InfoHolder
{
    public string sPlaceName;
    public bool bRaided;
    public float fTimeRaided;
}

public class PlaceInfoHolder
{

    #region variables

    List<InfoHolder> placeInfos;

    
    #endregion

    #region functions

    public PlaceInfoHolder()
    {
        placeInfos = new List<InfoHolder>();
    }

    public bool RequestInfo (ref InfoHolder i)
    {//used by places to receive their data
        foreach( InfoHolder p in placeInfos)
        {
            if( p.sPlaceName == i.sPlaceName)
            {
                i = p;
                return true;
            }
        }
        return false;
    }

    public void GatherInfo( Place[] p)
    {
        placeInfos.Clear();
        foreach( Place i in p)
        {
            placeInfos.Add(i.SendInfoHolder());
        }
    }

    #endregion

}

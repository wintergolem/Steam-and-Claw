using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct InfoHolder  //for PlaceInfoHolder
{
    public string sPlaceName;
    public bool bRaided;
    public bool bRecruiting;
    public float fTimeRaided;
    public float fTimeRecruiting;
    public int iRecruitAvailable;
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

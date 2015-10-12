using UnityEngine;
using System.Collections;


//used to hold info for scene changing
public class GameManager {


    //holds info for place being entered
    public struct placeInfo
    {
        public static string sName = "DEFAULT VILLAGE";
        public static int iRecruit = 3;
        public static int iRecruitCost = 3000;
        public static bool bRaided = false;
    }
	
    public struct ToOverworldInfo
    {
        public static bool bHasTroopsToAdd = false;
        public static int iPartyMembersToAdd = 0;

        public static bool bBurnedVillage = false;
    }

    #region Variables

    //scene variables
    public enum SceneDirectory { StartScene , OverworldDevelop , TownUIDevelop};
    public static SceneDirectory sceneDirectory;
    public static bool bSet = false;  //true: info has been set, false: info needs to set
    static PartyManager m_PartyManager;
    public static PartyManager partyManager
    {
        get
        {
            if( m_PartyManager == null)
                m_PartyManager = new PartyManager();
            return m_PartyManager;
        }
        set
        {
            Debug.LogError("Can't set this variable");
        }
    }
    static FactionManager m_factionManager;
    public static FactionManager factionManager
    {
        get
        {
            if (m_factionManager == null)
                m_factionManager = new FactionManager();
            return m_factionManager;
        }
        set
        {
            Debug.LogError("Can't set this variable");
        }
    }

    //Info holding variables
    static PlaceInfoHolder m_placeInfoHolder;
    public static PlaceInfoHolder placeInfoHolder
    {
        get
        {
            if (m_placeInfoHolder == null)
                m_placeInfoHolder = new PlaceInfoHolder();
            return m_placeInfoHolder;
        }
        set
        {
            Debug.LogError("Can't set this variable");
        }
    }
    #endregion


    #region Functions

    public static void SetTestingData()
    {
        Debug.Log("USING TEST DATA");
        bSet = true;
        //placeInfo struct
        placeInfo.sName = "DEFAULT VILLAGE";
        placeInfo.iRecruit = 3;
        placeInfo.iRecruitCost = 3000;
        placeInfo.bRaided = false;

        //add partymanager stuff once rewritten

        //FactionManager
        factionManager.Start();
        factionManager.AddFaction("Player");
        factionManager.AddFaction("Enemy");
    }

    public static void PrepareToTransferRecruits()
    {
        ToOverworldInfo.bHasTroopsToAdd = true;
        ToOverworldInfo.iPartyMembersToAdd = placeInfo.iRecruit;
        placeInfo.iRecruit = 0;
    }

    public static void TransferRecruits()
    {
        if( ToOverworldInfo.bHasTroopsToAdd)
        {
            partyManager.AddToParty(ToOverworldInfo.iPartyMembersToAdd);
            ToOverworldInfo.bHasTroopsToAdd = false;
        }
    }

    public static void BurnVillage()
    {
        OverworldBlackboard.BurnVillage(placeInfo.sName);
        GameManager.ToOverworldInfo.bBurnedVillage = false;
    }

    public static void SetPlaceInfo( Place place)
    {
        placeInfo.sName = place.sName;
        placeInfo.iRecruit = place.iRecruitAmount;
        placeInfo.iRecruitCost = place.iRecruitCost;
        placeInfo.bRaided = place.bRaided;
    }

    public static void ChangeScene( SceneDirectory s)
    {
        Application.LoadLevel(s.ToString());
    }

    #endregion
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Faction
{

    #region static variables
    static float DEFAULT_RELATION_VALUE = 0.5f;
    #endregion

    #region public variables

    public string sName 
    {
        get
        {
            return m_sName;
        }
        set
        {
            Debug.LogError("Can't change name of faction this way");
        }
    }

    #endregion

    #region private variables

    string m_sName;

    Dictionary<string, float> dFactionRelations;  //faction name , 0 (hostile) to 1 (ally)

    FactionManager manager;

    #endregion

    #region private funcs
    
    void Init(string a_sName, FactionManager a_manager)
    {
        manager = a_manager;
        dFactionRelations = new Dictionary<string, float>();
        m_sName = a_sName;
        FillFactionRelationsDefaultData();
    }

    //should only called upon creation
    void FillFactionRelationsDefaultData()
    {
        List<Faction> lFactions = manager.GetFactionList();

        for (int i = 0; i < lFactions.Count; i++ )
        {
            AddRelation(lFactions[i].sName, DEFAULT_RELATION_VALUE);   //add faction to my list
            lFactions[i].AddRelation(sName, DEFAULT_RELATION_VALUE);   //add me to faction's list
        }
    }

    #endregion

    #region public functions

    public Faction()
    {
        Debug.Log("Basic Constructor Called *******");
        Init("Default", null);
    }

    public Faction(string sName, FactionManager manager)
    {
        Init(sName, manager);
    }

    //Called whenever a new faction has emerged, and at the beginning of game
    public void AddRelation( string a_sFactionName, float a_fValue)
    {
        if (CheckRelationDoesntExist(a_sFactionName))
            dFactionRelations.Add(a_sFactionName, a_fValue); //relation doesn't already exist, so add it
    }

    //Called whenever a faction has been destoryed (remove from game)
    public void RemoveRelation( string sFactionName)
    {
       if(  CheckRelationExist(sFactionName) )
            dFactionRelations.Remove(sFactionName); //remove faction relations
    }

    //Used to change Relation value to new value
    public void SetRelation( string sFactionName, float fNewValue, bool SetOpposite = false)
    {
        if( CheckRelationExist(sFactionName) && ( fNewValue <= 1 && fNewValue >= 0) )
        {
            dFactionRelations[sFactionName] = fNewValue;
        }

        if( SetOpposite)
        {
            manager.AffectRelationBetweenFactions(sFactionName, sName, fNewValue);
        }
    }

    //Returns value equal to relationship with faction: returns -1 as error code
    public float GetRelation( string sFactionName )
    {
        if (CheckRelationExist(sFactionName))
            return dFactionRelations[sFactionName];
        else
            return -1; //any function calling this one should should this case
    }
    #endregion

    #region private functions

    //check to ensure faction does exist
    bool CheckRelationExist(string sFactionName, bool bReverse = false) //bReserve should be used by CheckRelationDoesntExist func
    {
        if (dFactionRelations.Count > 0 && dFactionRelations.ContainsKey(sFactionName))
        {
            if( bReverse ) Debug.LogError("Relation already created"); //display error message
            return true;  //leave function
        }
        if (!bReverse) Debug.LogError("Relation not yet created"); //display error message
        return false;
    }

    //check to ensure relation(i.e faction) doesn't already exist 
    bool CheckRelationDoesntExist( string sFactionName )
    {
        return !CheckRelationExist(sFactionName, true);
    }
    #endregion
}

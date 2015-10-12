using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FactionManager {

    List<Faction> lFactions;

	public void Start () 
    {
        lFactions = new List<Faction>();
	}
	
	void Update () 
    {

    }


    #region public functions

    public void AddFaction(string sFactionName)
    {
        if ( CheckFactionDoesntExist(sFactionName) )
        {
            lFactions.Add(new Faction(sFactionName, this)); //create faction and add it to list
        }
    }

    public void RemoveFaction(string sFactionName)
    {
        if( CheckFactionExist(sFactionName) )
        {
            lFactions.Remove(lFactions.Find(x => x.sName == sFactionName)); //needs redone: too inefficent
        }
    }

    public List<Faction> GetFactionList()
    {
        return lFactions;
    }

    public void GetFactionNameList(List<string> a_lNames)
    {
        //convert lfactions into a list of strings (of Faction Names)
        foreach( Faction f in lFactions)
        {
            a_lNames.Add(f.sName);
        }
    }

    //returns 1st faction's opinion of second faction
    public float GetRelationBetweenFactions( string a_sFirstFaction, string a_sSecondFaction)
    {
        return lFactions.Find(x => x.sName == a_sFirstFaction).GetRelation(a_sSecondFaction);
    }

    public void AffectRelationBetweenFactions( string a_sFirstFaction, string a_sSecondFaction, float a_fValue , bool a_bFlip = false)
    {
        lFactions.Find(x => x.sName == a_sFirstFaction).SetRelation(a_sSecondFaction, a_fValue, a_bFlip);
    }

    #endregion

    #region private functions

    bool CheckFactionExist(string sFactionName)
    {
        if( lFactions.Count > 0 && lFactions.Exists(x => x.sName == sFactionName) )
        {
            return true;
        }
        return false;
    }

    bool CheckFactionDoesntExist(string sFactionName)
    {
        return !CheckFactionExist(sFactionName);
    }

    #endregion
}

using UnityEngine;
using System.Collections;

public class ClickAndMove : MonoBehaviour {

    NavMeshAgent nav;

    public GameObject town;

	// Use this for initialization
	void Start () {
        nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetMouseButtonUp(0) && !Blackboard.instance.bEnteredTown)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                //if next destination is close to a town, warn blackboard
                if( Mathf.Abs(Vector3.Distance(hit.point , town.transform.position) ) < 1 )
                    Blackboard.instance.bEnteringTown = true;
                //set destination
                nav.SetDestination(hit.point);
            }
        }
        else
        {

            if( Blackboard.instance.bEnteringTown && nav.remainingDistance < 2)
            {
                Blackboard.instance.EnterTown();
            }
        }
	}
}

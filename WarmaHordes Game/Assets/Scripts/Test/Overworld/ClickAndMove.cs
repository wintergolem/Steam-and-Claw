using UnityEngine;
using System.Collections;

public class ClickAndMove : MonoBehaviour {

    NavMeshAgent nav;

	// Use this for initialization
	void Start () {
        nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetMouseButtonUp(0) )
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                //set destination
                nav.SetDestination(hit.point);
            }
        }
	}

    void OnCollisionEnter(Collision c)
    {
        if( c.gameObject.tag == "Place")
        {
            OverworldBlackboard.EnterTown(c.gameObject.GetComponent<Place>());
        }
    }
}

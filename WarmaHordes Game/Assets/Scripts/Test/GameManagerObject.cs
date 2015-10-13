using UnityEngine;
using System.Collections;

public class GameManagerObject : MonoBehaviour {

    GameManager gameManager;
    static bool bload = false;

    void Awake()
    {
        //Debug.Log("Awake called");
        if (gameManager == null && !GameManager.bSet)
        {
            gameManager = new GameManager();
            GameManager.SetTestingData();
            DontDestroyOnLoad(this);
        }
        else if (gameManager == null && GameManager.bSet)
        {
            Debug.Log("Destorying extra GameManagerObject, should happen once per level");
            bload = false;
            Destroy(this.gameObject);
        }
        else if (gameManager != null)
        {
        }
        else
            Debug.Log("Else called");
        //Debug.Log("Awake Called");
    }

    void Update()
    {
        if( !bload )
        {
            bload = true;
            SceneLoad();
            Debug.Log("Scene Load");
        }
    }

    void SceneLoad()
    {
        GameManager.TransferRecruits();
        if( GameManager.ToOverworldInfo.bBurnedVillage) GameManager.BurnVillage();
    }
}

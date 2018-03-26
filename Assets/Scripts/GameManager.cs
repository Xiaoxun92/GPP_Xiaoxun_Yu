using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoExtended {

    public int gameState;
    
    void Start () {
        gameState = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        if (Input.GetKeyDown(KeyCode.P)) {
            if (gameState == 1)
                gameState = 0;
            else if (gameState == 0)
                gameState = 1;
        }
    }

    protected override void GameUpdate() {
    }
}

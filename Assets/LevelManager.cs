using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    CameraScript cs;
    
    float verticalDistance, horizontalDistance;
    float spawnTimer = 0;
    public float spawnInterval = 5;
    public GameObject asteroidPrefab;
    public GameObject gameOverScreen;

    
    void Start()
    {
        cs = Camera.main.GetComponent<CameraScript>();
        Time.timeScale = 1.0f;
    }

    
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer > spawnInterval)
        {
            //spawnujemy kamieñ
            Vector3 spawnPosition = getRandomSpawnPosition();
            //Debug.Log("Spawnuje kamulec na wspó³rzêdnych: " + spawnPosition.ToString());
            GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

            //resetujemy timer
            spawnTimer = 0;
        }
    }
    Vector3 getRandomSpawnPosition()
    {
        //policz odleg³oœæ spawnowania
        verticalDistance = 0.55f * cs.gameHeight;
        horizontalDistance = 0.55f * cs.gameWidth;
        //losowanie liczby cakowitej <1;4>
        int randomSpawnLine = Random.Range(1, 5);
        Vector3 randomSpawnLocation = Vector3.zero;
        switch (randomSpawnLine)
        {
            case 1:
                //górna linia
                randomSpawnLocation = new Vector3(Random.Range(-horizontalDistance, horizontalDistance),
                                                                0,
                                                                verticalDistance);
                break;
            case 2:
                //prawa linia
                randomSpawnLocation = new Vector3(horizontalDistance,
                                                  0,
                                                  Random.Range(-verticalDistance, verticalDistance));
                break;
            case 3:
                //dolna linia
                randomSpawnLocation = new Vector3(Random.Range(-horizontalDistance, horizontalDistance),
                                                                0,
                                                                -verticalDistance);
                break;
            case 4:
                //lewa linia
                randomSpawnLocation = new Vector3(-horizontalDistance,
                                                  0,
                                                  Random.Range(-verticalDistance, verticalDistance));
                break;
        }
        return randomSpawnLocation;
    }
    public void GameOver()
    {
        //zatrzymaj czas
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }
}

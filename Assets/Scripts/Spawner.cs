using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public GameObject tubo;
    public Transform puntoObjetivo;
    public float intervaloSpawn;
    public ChangeScoreTXT scoreScript;
    float posicionY = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        VerifyMode();
        
        //posicionY = Random.Range(-1.20f, 1.9f);
    }

    private void VerifyMode()
    {
        if (GameMode.infiniteMode == false) 
        {
            StartCoroutine(ConstantSpawnClassic());
        } else if (GameMode.infiniteMode == true)
        {
            StartCoroutine(ConstantSpawnInfinity());
        }
    }

    //funcion para que aparezcan los tubos y asignarles el punto objetivo
    private void SpawnTubesClassic()
    {
        if (scoreScript.score >= 10000f) { Debug.Log("Has ganado"); }
        posicionY = Random.Range(-1.20f, 1.83f);
        GameObject spawneado = Instantiate(tubo, new Vector2(transform.position.x, posicionY), Quaternion.identity);
        spawneado.GetComponent<ObstacleMovement>().puntoObjetivo = puntoObjetivo;
        int velocidadExtra = scoreScript.score / 2000;
        if (scoreScript.score >= 1000) {
        spawneado.GetComponent<ObstacleMovement>().velocidad += velocidadExtra;
        }
        float intervaloAdd = scoreScript.score / 25000f;
        if (intervaloSpawn > 0.9f && scoreScript.score >= 1000) 
        { 
               intervaloSpawn -= intervaloAdd;     
        }
    }

    private void SpawnTubesInfinity()
    {
        Debug.Log("Modo infinito activado");
        posicionY = Random.Range(-1.20f, 1.83f);
        GameObject spawneado = Instantiate(tubo, new Vector2(transform.position.x, posicionY), Quaternion.identity);
        spawneado.GetComponent<ObstacleMovement>().puntoObjetivo = puntoObjetivo;
        int velocidadExtra = Mathf.Min(scoreScript.score / 3000, 3);
        if (scoreScript.score >= 1000)
        {
            spawneado.GetComponent<ObstacleMovement>().velocidad += velocidadExtra;
        }
        float intervaloAdd = scoreScript.score / 10000f;
        if (intervaloSpawn > 1f && scoreScript.score >= 2000)
        {
            intervaloSpawn -= intervaloAdd;
        }
    }

    //bucle que hace la funcion de arriba
    private IEnumerator ConstantSpawnClassic()
    {
        while (true) 
        {
            SpawnTubesClassic();
        yield return new WaitForSeconds(intervaloSpawn);

        }
    }

    private IEnumerator ConstantSpawnInfinity()
    {
        while (true)
        {
            SpawnTubesInfinity();
            yield return new WaitForSeconds(intervaloSpawn);

        }
    }
}

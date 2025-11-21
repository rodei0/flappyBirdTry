using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public Transform puntoObjetivo;
    public float velocidad;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Movement();
    }

    void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(puntoObjetivo.position.x, transform.position.y), velocidad * Time.deltaTime);
        if (transform.position.x == puntoObjetivo.position.x) { 
        Destroy(this.gameObject);
        }
    }
}

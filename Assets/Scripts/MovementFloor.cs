using Unity.VisualScripting;
using UnityEngine;

public class MovementFloor : MonoBehaviour
{
    public float velocidad;
    public GameObject objetivoFinal;
    public GameObject suelo1;
    public GameObject suelo2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement(); 
    }

    private void Movement()
    {
        transform.position += Vector3.left * velocidad * Time.deltaTime;
        if (suelo1.transform.position.x <= objetivoFinal.transform.position.x)
        {
            suelo1.transform.position = new Vector2(suelo2.transform.position.x + 15f, suelo1.transform.position.y);
        }
        else if (suelo2.transform.position.x <= objetivoFinal.transform.position.x)
        {
            suelo2.transform.position = new Vector2(suelo1.transform.position.x + 15f, suelo2.transform.position.y);
        }
    }
}

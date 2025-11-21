using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SpiderMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float velocidad;
    public float distancia = 1.5f;

    public float cd;

    private Vector3 posicionInicial;
    private Vector3 posicionAbajo;
    private Vector3 posicionArriba;

    void Start()
    {
        posicionInicial = transform.position;
        posicionAbajo = posicionInicial + Vector3.down * distancia;
        posicionArriba = posicionInicial;
        StartCoroutine(SpiderMoving());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpiderMoving() 
    {
        yield return new WaitForSeconds(3f);
        while (Mathf.Abs(transform.position.y - posicionAbajo.y) >0.01f) {
            Vector3 target = new Vector3(transform.position.x, posicionAbajo.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, target, velocidad * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        while (Mathf.Abs(transform.position.y - posicionInicial.y) > 0.01f)
        {
            Vector3 target = new Vector3(transform.position.x, posicionArriba.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, target, velocidad * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(cd);
        ResetValues();
    }

    public void ResetValues() 
    {
        transform.position = posicionInicial;
        StartCoroutine(SpiderMoving());
    }
}

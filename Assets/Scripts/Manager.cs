using System.Collections;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject araña;
    public float waitTime;
    void Start()
    {
        StartCoroutine(StartAnim()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator StartAnim()
    {
        yield return new WaitForSeconds(waitTime);
        araña.SetActive(true);
        yield return null;
    }
}

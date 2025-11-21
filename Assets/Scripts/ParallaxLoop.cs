using UnityEngine;

public class ParallaxLoop : MonoBehaviour
{
    public float speed = 1f;
    public float parallaxFactor = 1;
    public float width;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * parallaxFactor * Time.deltaTime;

        if (transform.position.x < -width)
        {
            transform.position += new Vector3(width * 2f, 0, 0);
        }
    }
}

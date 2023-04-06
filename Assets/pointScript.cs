using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D point;
    void Start()
    {
        int posx = UnityEngine.Random.Range(-16, 16);
        int posy = UnityEngine.Random.Range(-8, 8);
        point.position = new Vector2(posx, posy);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        int posx = UnityEngine.Random.Range(-16, 16);
        int posy = UnityEngine.Random.Range(-8, 8);
        point.position = new Vector2(posx, posy);
    }
}

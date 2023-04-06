using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{

    public Rigidbody2D player;
    public GameObject playerBody;
    public LinkedList<GameObject> body;
    public Vector2 move;
    public Vector2 reset = new Vector2(0, 0);

    public void Start()
    {
        body = new LinkedList<GameObject>();
        player.position = reset;
        move.x = 0;
        move.y = 0;
        int posx = UnityEngine.Random.Range(-16, 16);
        int posy = UnityEngine.Random.Range(-8, 8);
    }

    private void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            move = Vector2.up;
        }

        else if (Input.GetKeyDown("down"))
        {
            move = Vector2.down;
        }

        else if (Input.GetKeyDown("left"))
        {
            move = Vector2.left;
        }
        else if (Input.GetKeyDown("right"))
        {
            move = Vector2.right;
        }
    }
    private void FixedUpdate()
    {
        int x = (int)Math.Round(player.position.x);
        int y = (int)Math.Round(player.position.y);
        Vector2 pos = player.position;
        player.position=new Vector2(x + move.x, y+move.y);
        LinkedListNode<GameObject> mark1 = body.First;
        while(mark1!=null)
        {
            Vector2 tmp = mark1.Value.transform.position;
            mark1.Value.transform.position = pos;
            mark1.Value.SetActive(true);
            mark1 = mark1.Next;
            pos = tmp;
        }
        

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name.Contains("point")){
            scoreScript.points++;
            int posx = UnityEngine.Random.Range(-16, 16);
            int posy= UnityEngine.Random.Range(-8, 8);
            collision.gameObject.transform.position=new Vector2(posx, posy);
            GameObject tmp = Instantiate(playerBody);
            tmp.SetActive(false);
            body.AddLast(tmp);
        }
        else if (collision.gameObject.name.Contains("bound")|| collision.gameObject.name.Contains("playerBody"))
        {
            move.x = 0;
            move.y = 0;
            player.position=reset;
            scoreScript.points = 0;
            LinkedListNode<GameObject> mark1 = body.First;
            while (mark1 != null)
            {
                Destroy(mark1.Value);
                mark1 = mark1.Next;
            }
            body = new LinkedList<GameObject>();

        }



    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private float speed = 10;
    public float speed_s
    {
        get { return speed; }
        set
        {
            if (value < 0)
            {
                Debug.LogError("MoveDown: Can't assign a negative value to Speed");
            }
            else
            {
                speed = value;
            }
        }
    }
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.gameOver == false)
        {
            GoDown();
        }
    }

    void GoDown()
    {
        if (transform.position.z < -10)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
}

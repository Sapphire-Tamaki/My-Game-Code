using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBonus : Bonus
{
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!player.GetComponent<PlayerController>().gameOver)
        {
            OnCollision();
        }

    }
    public override void OnCollision()
    {
        player.GetComponent<PlayerController>().u_speed = 20;
        player.GetComponent<PlayerController>().StartSpeedBonusCount();
        Destroy(gameObject);
    }
}

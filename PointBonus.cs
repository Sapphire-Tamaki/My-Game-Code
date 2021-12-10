using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBonus : Bonus
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
        gameManager.AddScore(30);
        Destroy(gameObject);
    }
}

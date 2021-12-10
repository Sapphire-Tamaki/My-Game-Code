using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    private GameObject unityChan;
    public float u_speed
    {
        get { return speed; }
        set
        {
            if (value < 0)
            {
                Debug.LogError("PlayerController: Can't assign a negative value to Speed");
            }
            else
            {
                speed = value;
            }
        }
    }
    private float horiBound = 5.0f;
    public bool gameOver = false;

    public GameObject gameOverMenu;
    // Start is called before the first frame update
    void Start()
    {
        unityChan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        SceneBarrier();
    }
    void PlayerMovement()
    {
        if (gameOver == false)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * u_speed * horizontalInput * Time.deltaTime);
        }

    }
    
    void SceneBarrier()
    {
        if (transform.position.x > horiBound)
        {
            transform.position = new Vector3(horiBound, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -horiBound)
        {
            transform.position = new Vector3(-horiBound, transform.position.y, transform.position.z);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            gameOver = true;
            unityChan.GetComponent<Animator>().SetFloat("Speed", 0f);
            gameOverMenu.SetActive(true);
        }
    }
    public void StartSpeedBonusCount()
    {
        StartCoroutine("SpeedBonusCount");
    }
    IEnumerator SpeedBonusCount()
    {
        yield return new WaitForSeconds(10f);
        u_speed = 10;
    }
}

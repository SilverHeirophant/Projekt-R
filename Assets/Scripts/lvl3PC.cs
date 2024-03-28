using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl3PC : MonoBehaviour
{
    private float hInput;
    private float vInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject Dialogue;
    [SerializeField] GameObject MainHUD;
    [SerializeField] GameObject MissionComplete;

    public AudioSource fireBullet;
    public float bSpeed;
    public AudioSource Complete;
    public float hSpeed;
    public GameObject bulletP;
    public Transform firePoint;
    public float MaxXRange = 440.0f;
    public float MinXRange = 212.0f;
    public ScoreManager scoreManager;
    public Animator playerAnim;

    void Awake(){
        Time.timeScale = 0;
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();

        GetComponent<AudioSource>().playOnAwake = false;
    }
    
    
    void Start()
    {
        Dialogue.SetActive(true);
        MainHUD.SetActive(false);
        MissionComplete.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * hInput * Time.deltaTime * hSpeed);

        if(transform.position.x > MaxXRange){
            transform.position = new Vector3(MaxXRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x < MinXRange){
            transform.position = new Vector3(MinXRange, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dialogue.SetActive(false);

            Time.timeScale = 1;
            MainHUD.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.F)){
            ShootBullet();
        }
    }

    public void OnTriggerEnter(Collider collider){
        if(collider.gameObject.CompareTag("Enemy")){
            ScoreManager.instance.AddScore(1);
            Destroy(collider.gameObject);
        }
    }

    void ShootBullet()
    {
        bulletP = Instantiate(bulletP, firePoint.position, firePoint.rotation);
        Rigidbody bulletRb = bulletP.GetComponent<Rigidbody>();
            
        bulletRb.velocity = firePoint.forward * bSpeed;

        GetComponent<AudioSource>().Play();
    }



}

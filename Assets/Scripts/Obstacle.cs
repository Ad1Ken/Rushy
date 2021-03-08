using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;
    public float speed;

    public GameObject effect;
    private Animator camAnim;

    private void Start()
    {
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }
    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            camAnim.SetTrigger("Shaky");
            Instantiate(effect, transform.position, Quaternion.identity);
            //Player take damage
            other.GetComponent<player>().health -= damage;
            Debug.Log(other.GetComponent<player>().health);
            Destroy(gameObject);
        }
    }
}

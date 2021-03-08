using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    private Vector2 targetPos;
    public float Yincrement;
    public float speed;
    public float maxHeight;
    public float minHeight;
    public int health = 3;
    public Animator camAnim;

    public Text healthDisplay;

    public GameObject effect;
    public GameObject EndPanel;

   
    void Update()
    {
        healthDisplay.text = health.ToString();
        if (health <= 0)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            EndPanel.SetActive(true);
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y<maxHeight)
        {
            camAnim.SetTrigger("Shaky");
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            Instantiate(effect, transform.position, Quaternion.identity);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y>minHeight)
        {
            camAnim.SetTrigger("Shaky");
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
            Instantiate(effect, transform.position, Quaternion.identity);
        }
    }

    
}

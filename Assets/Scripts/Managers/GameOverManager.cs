using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Text warningText;
    public PlayerHealth playerHealth;
    public float restartDelay = 5f;

    Animator anim;
    float restartTimer;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");

            restartTimer += Time.deltaTime;
            Debug.Log("Scene manager = " + SceneManager.GetActiveScene().name);
            Debug.Log("Restart timer = " + restartTimer);
            if (restartTimer >= restartDelay)
            {
                
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void ShowWarning(float enemyDistance)
    {
        if (playerHealth.currentHealth > 0)
        {
            warningText.text = string.Format("! {0} m", Mathf.RoundToInt(enemyDistance));
            anim.SetTrigger("Warning");

        }
    }
}
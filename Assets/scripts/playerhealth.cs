using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerhealth : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("123");
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -6) { Die(); }

    }
    void Die()
    {
        SceneManager.LoadScene("123");
    }
}

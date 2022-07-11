using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrasition : MonoBehaviour
{
    public string sceneToload;
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    public GameObject fadeInPanel;
    public GameObject fadeToWhite;
    public float fadeWait;
    private void Awake()
    {
        if (fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel,
                Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1f);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&&!other.isTrigger)
        {
            playerStorage.initiavalue = playerPosition;
            StartCoroutine(FadeCo());
            //SceneManager.LoadScene(sceneToload);
        }
    }
    public IEnumerator FadeCo() 
    {
        if(fadeInPanel != null)
        {
            Instantiate(fadeToWhite, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToload);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
        
    }
}

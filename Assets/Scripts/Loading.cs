using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(loading());
    }
    IEnumerator loading()
    {
        yield return new WaitForSeconds(2.5f);

        SceneManager.LoadSceneAsync(1);
    }
}

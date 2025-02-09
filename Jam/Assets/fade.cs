using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    public CanvasGroup fadeCanvas;
    public Image fadeImage;
    public float fadeDuration = 1f;

    private void Start()
    {
        fadeImage.raycastTarget = false;
        StartCoroutine(FadeIn());
    }

    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    private IEnumerator FadeIn()
    {
        fadeCanvas.alpha = 1;
        fadeImage.raycastTarget = false;

        while (fadeCanvas.alpha > 0)
        {
            fadeCanvas.alpha -= Time.deltaTime / fadeDuration;
            yield return null;
        }

        fadeImage.raycastTarget = false;
    }

    private IEnumerator FadeOut(string sceneName)
    {
        fadeImage.raycastTarget = true; 

        while (fadeCanvas.alpha < 1)
        {
            fadeCanvas.alpha += Time.deltaTime / fadeDuration;
            yield return null;
        }

        SceneManager.LoadScene(sceneName);

        yield return new WaitForSeconds(0.5f);

        StartCoroutine(FadeIn());
    }
}

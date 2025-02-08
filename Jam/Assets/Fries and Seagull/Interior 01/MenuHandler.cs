using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button backButton;

    private void Start()
    {
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);

        settingsButton.onClick.AddListener(OpenSettings);
        backButton.onClick.AddListener(CloseSettings);
    }

    private void OpenSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    private void CloseSettings()
    {
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }
}
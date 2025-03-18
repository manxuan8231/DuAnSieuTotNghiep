using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingOpen : MonoBehaviour
{
    public GameObject settingsPanel; // Kéo Panel vào trong Inspector

    public void ToggleSettings()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }
}

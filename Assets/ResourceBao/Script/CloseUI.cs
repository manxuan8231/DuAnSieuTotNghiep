using UnityEngine;
using System.Collections;

public class CloseUI : MonoBehaviour
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

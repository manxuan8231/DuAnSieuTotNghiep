using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerLives : MonoBehaviour
{
    public int maxLives = 100; // Tổng số mạng ban đầu
    public TextMeshProUGUI livesText; // TextMeshPro để hiển thị số mạng

    private int currentLives;

    public GameObject panelRespawn;
    public int scene;
    public CharacterController characterController;

    void Start()
    {
        // Lấy dữ liệu số mạng đã lưu, nếu chưa có thì đặt = maxLives
        currentLives = PlayerPrefs.GetInt("PlayerLives", maxLives);
        UpdateLivesText();
        panelRespawn.SetActive(false);
    }

    public void LoseLife()
    {
        // Giảm một mạng khi bị mất
        currentLives--;
        UpdateLivesText();

        // Lưu lại số mạng
        PlayerPrefs.SetInt("PlayerLives", currentLives);
        PlayerPrefs.Save();

        if (currentLives > 0)
        {
            StartCoroutine(cooldown());
        }
        else
        {
            // Game over hoặc reset toàn bộ
            GameOver();
        }
    }

    void GameOver()
    {
        // Hiển thị thông báo hoặc thực hiện hành động khi hết mạng
        Debug.Log("Game Over");
        livesText.text = "Game Over";
        // Xóa dữ liệu số mạng để chơi lại từ đầu
        PlayerPrefs.DeleteKey("PlayerLives");
    }

    public IEnumerator cooldown()
    {
        characterController.enabled = false;
        yield return new WaitForSeconds(4f);
        panelRespawn.SetActive(true);
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(scene);
    }

    void UpdateLivesText()
    {
        // Cập nhật hiển thị số mạng
        livesText.text = "Lives: " + currentLives.ToString();
    }
}

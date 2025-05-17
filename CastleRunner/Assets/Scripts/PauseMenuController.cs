using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public string menuSceneName = "PauseMenu"; // �������� ����� � ����

    void Update()
    {
        // ��������� ������� ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // ��������� ����� � ����
            SceneManager.LoadScene(menuSceneName);

            // ���� ������ ������� ����� ������ �������� �����, ����������������:
            // Time.timeScale = 0f; // ������������� ����
            // �������� UI ���� (����� ������� UI ��������)
        }
    }

    // ����� ��� �������� � ���� (���� ������� ����� ������ �������� �����)
    public void ResumeGame()
    {
        Time.timeScale = 1f; // ������������ ����
        // ������ UI ����
    }
}
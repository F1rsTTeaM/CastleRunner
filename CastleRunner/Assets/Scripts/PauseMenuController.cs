using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public string menuSceneName = "PauseMenu"; // Название сцены с меню

    void Update()
    {
        // Проверяем нажатие ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Загружаем сцену с меню
            SceneManager.LoadScene(menuSceneName);

            // Если хотите сделать паузу вместо загрузки сцены, раскомментируйте:
            // Time.timeScale = 0f; // Останавливаем игру
            // показать UI меню (нужно создать UI элементы)
        }
    }

    // Метод для возврата в игру (если делаете паузу вместо загрузки сцены)
    public void ResumeGame()
    {
        Time.timeScale = 1f; // Возобновляем игру
        // скрыть UI меню
    }
}
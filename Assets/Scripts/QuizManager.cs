using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class QuizPuzzleManager : MonoBehaviour
{
    [Header("List Buttons")]
    public Button trueButton1;
    public Button trueButton2;
    public Button trueButton3;
    public Button trueButton4;
    public Button falseButton1;
    public Button falseButton2;
    public Button falseButton3;
    public Button falseButton4;
    public Button falseButton5;
    public Button falseButton6;
    public Button falseButton7;
    public Button falseButton8;
    public Button falseButton9;
    public Button falseButton10;
    public Button falseButton11;
    public Button falseButton12;

    public List<Button> returnButtons;

    [Header("Quiz Elements")]
    public GameObject[] questionObjects; // Mảng chứa các object câu hỏi
    private int correctAnswerCount = 0; // Số lượng câu hỏi đã được trả lời đúng
    private bool sceneLoading = false; // Biến để kiểm tra xem đã load cảnh mới hay chưa
    public GameObject levelUpCube; // Tham chiếu đến Khối Level Up
    public Transform vrCameraTransform; // Tham chiếu đến transform của camera VR
    private Vector3 initialCameraPosition; // Vị trí ban đầu của camera VR
    private Quaternion initialCameraRotation; // Hướng quay ban đầu của camera VR
    public GameObject gameOverMenu; // Tham chiếu đến menu Game Over
    public int restartSceneIndex = 2;
    public int nextScene = 3;
    public bool timeIsUp = false; // Biến trạng thái để kiểm tra xem thời gian đã hết hay chưa

    void Start()
    {
        // Lưu trữ vị trí và hướng quay ban đầu của camera
        initialCameraPosition = vrCameraTransform.position;
        initialCameraRotation = vrCameraTransform.rotation;

        // Gán sự kiện cho các nút
        trueButton1.onClick.AddListener(TrueAnswer);
        trueButton2.onClick.AddListener(TrueAnswer);
        trueButton3.onClick.AddListener(TrueAnswer);
        trueButton4.onClick.AddListener(TrueAnswer);
        falseButton1.onClick.AddListener(FalseAnswer);
        falseButton2.onClick.AddListener(FalseAnswer);
        falseButton3.onClick.AddListener(FalseAnswer);
        falseButton4.onClick.AddListener(FalseAnswer);
        falseButton5.onClick.AddListener(FalseAnswer);
        falseButton6.onClick.AddListener(FalseAnswer);
        falseButton7.onClick.AddListener(FalseAnswer);
        falseButton8.onClick.AddListener(FalseAnswer);
        falseButton9.onClick.AddListener(FalseAnswer);
        falseButton10.onClick.AddListener(FalseAnswer); 
        falseButton11.onClick.AddListener(FalseAnswer);
        falseButton12.onClick.AddListener(FalseAnswer);
    }

    void Update()
    {
        if (!timeIsUp && correctAnswerCount == questionObjects.Length && !sceneLoading)
        {
            sceneLoading = true;
            StartCoroutine(ReturnCameraAndShowLevelUp());
        }
    }

    public void OnCountdownEnd()
    {
        timeIsUp = true; // Đặt cờ báo hết thời gian

        if (correctAnswerCount == questionObjects.Length)
        {
            StartCoroutine(ReturnCameraAndShowLevelUp());
        }
        else
        {
            ShowGameOverMenu();
        }
    }

    private IEnumerator ReturnCameraAndShowLevelUp()
    {
        // Di chuyển camera về vị trí ban đầu
        vrCameraTransform.position = initialCameraPosition;
        vrCameraTransform.rotation = initialCameraRotation;

        // Chờ một lát để đảm bảo camera đã di chuyển (tùy chọn, điều chỉnh thời gian cần thiết)
        yield return new WaitForSeconds(0.5f);

        // Hiển thị khối Level Up
        ShowLevelUpCube();

        // Chờ 2 giây để hiển thị khối Level Up
        yield return new WaitForSeconds(2f);

        // Sau khi hiển thị khối Level Up, bắt đầu chuyển cảnh
        SceneManager.LoadScene(nextScene); // Thay thế bằng tên hoặc chỉ mục của cảnh của bạn
    }

    private void ShowLevelUpCube()
    {
        levelUpCube.SetActive(true); // Hiển thị khối Level Up
    }

    public void TrueAnswer()
    {
        for (int i = 0; i < questionObjects.Length; i++)
        {
            // Nếu đối tượng câu hỏi này đang hoạt động và là câu hỏi đã được trả lời đúng
            if (questionObjects[i].activeSelf && i == correctAnswerCount)
            {
                // Ẩn đối tượng câu hỏi
                questionObjects[i].SetActive(false);

                // Tăng biến đếm khi có câu trả lời đúng
                correctAnswerCount++;
                break; // Dừng vòng lặp khi tìm thấy câu hỏi cần ẩn
            }
        }
    }

    public void FalseAnswer()
    {
        ShowGameOverMenu();
    }

    public void ShowGameOverMenu()
    {
        gameOverMenu.SetActive(true); // Hiển thị menu Game Over
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0); // Load scene 0
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(restartSceneIndex);
    }
}

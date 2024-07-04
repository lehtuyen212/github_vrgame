using UnityEngine;

public class Block : MonoBehaviour
{
    public bool isInPlace = false; // Trạng thái của khối hộp, xác định xem khối đã đặt vào vị trí hay chưa
    private PuzzleManager puzzleManager;

    private void Start()
    {
        puzzleManager = FindObjectOfType<PuzzleManager>();
    }

    private void OnMouseDown()
    {
        if (puzzleManager.timeIsUp)
        {
            return; // Không cho phép tương tác nếu thời gian đã hết
        }

        // Logic để di chuyển khối
        // ...
    }

    private void OnTriggerEnter(Collider other)
    {
        if (puzzleManager.timeIsUp)
        {
            return; // Không cho phép khối được đặt vào chỗ nếu thời gian đã hết
        }

        // Bạn có thể thực hiện một số logic ở đây nếu cần thiết
    }
}

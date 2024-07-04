using UnityEngine;

public class Slot : MonoBehaviour
{
    public GameObject questionObject; // Object chứa câu hỏi cho slot

    private void OnTriggerEnter(Collider other)
    {
        Block block = other.GetComponent<Block>();
        if (block != null)
        {
            // Hiển thị object chứa câu hỏi của slot khi block được gắn vào
            if (questionObject != null)
            {
                questionObject.SetActive(true);
            }
        }
    }
}

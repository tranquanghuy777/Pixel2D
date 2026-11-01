using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem; // Thêm thư viện Input System vào đây

public class NPCInteraction : MonoBehaviour
{
    public GameObject KhungThoai;
    public TMP_Text LThoai;
    public string[] Vban;
    private int cnt = 0;
    private bool nearPlayer = false;
    private bool isTaking = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Thay Input.GetMouseButtonDown(1) thành Mouse.current != null && Mouse.current.rightButton.wasPressedThisFrame
        if (nearPlayer && Mouse.current != null && Mouse.current.rightButton.wasPressedThisFrame)
        {
            if (!isTaking)
            {
                hienThi();
            }
            else
            {
                HThoaiTiep();
            }
        }

    }
    void hienThi()
    {

        isTaking = true;
        KhungThoai.SetActive(true);
        LThoai.text = Vban[cnt];
    }
    void HThoaiTiep()
    {
        cnt++;
        if (cnt < Vban.Length)
        {
            LThoai.text = Vban[cnt];
        }
        else
        {
            KThuc();
        }
    }
    void KThuc()
    {
        isTaking = false;
        KhungThoai.SetActive(false);
        cnt = 0; // Thêm dòng này để reset lại hội thoại về câu đầu tiên khi kết thúc nếu muốn
    }
    private void OnTriggerEnter2D(Collider2D Nv)
    {
        if (Nv.CompareTag("Player"))
        {
            nearPlayer = true;
        }

    }
    private void OnTriggerExit2D(Collider2D Nv)
    {
        if (Nv.CompareTag("Player"))
        {
            nearPlayer = false;
        }

    }
}
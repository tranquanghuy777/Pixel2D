# 🎮 Pixel 2D Game Project

---

## 1. Giới thiệu dự án

Đây là dự án game platformer 2D theo phong cách **Pixel Art**, được phát triển bằng **Unity** và ngôn ngữ lập trình **C#**. Người chơi điều khiển nhân vật di chuyển qua các màn chơi, vượt qua chướng ngại vật, tránh bẫy và quái vật, đồng thời thu thập vật phẩm để hoàn thành màn chơi.

Dự án được thực hiện nhằm vận dụng kiến thức lập trình C#, làm quen với Unity Engine và tìm hiểu quy trình xây dựng một trò chơi 2D hoàn chỉnh từ thiết kế đồ họa đến lập trình các cơ chế gameplay.

---

## 2. Công nghệ sử dụng

* **Game Engine:** Unity
* **Ngôn ngữ lập trình:** C#
* **Thiết kế Pixel Art:** Aseprite
* **Vật lý & Va chạm:** `Rigidbody2D`, `Collider2D`
* **Thiết kế bản đồ:** Tilemap
* **Hoạt ảnh:** Animator
* **Giao diện (UI):** TextMeshPro, Unity UI
* **Quản lý mã nguồn:** Git & GitHub

---

## 3. Các chức năng chính

### 3.1. Điều khiển nhân vật
* Di chuyển linh hoạt sang trái và phải.
* Nhảy và tương tác với địa hình.
* Leo thang để di chuyển giữa các khu vực.
* Tích hợp animation mượt mà theo từng trạng thái nhân vật (Idle, Run, Jump, Climb,...).

### 3.2. Hệ thống bản đồ & Chướng ngại vật
* Xây dựng bản đồ 2D bằng **Tilemap**.
* Sử dụng `Collider2D` để xử lý chính xác va chạm với địa hình.
* Bố trí hệ thống bẫy và các chướng ngại vật đa dạng trong màn chơi.

### 3.3. Hệ thống quái vật (AI Enemy)
* Quái vật di chuyển tuần tra (Patrol) trong một phạm vi nhất định.
* Tự động phát hiện và đuổi theo người chơi khi vào tầm nhìn/khoảng cách gần.
* Quái vật bay có trạng thái tấn công riêng dựa trên khoảng cách được thiết lập.

### 3.4. Bệ di chuyển (Moving Platforms)
* Bệ di chuyển qua lại liên tục giữa các vị trí được xác định trước.
* Nhân vật có thể đứng trên bệ và di chuyển đồng bộ cùng bệ.

### 3.5. Hệ thống vật phẩm & Điểm số
* Thu thập vật phẩm (xu) để gia tăng điểm số.
* Cập nhật và hiển thị điểm số trực quan trên giao diện trò chơi (UI).

### 3.6. Camera & Trạng thái trò chơi
* **Camera Follow:** Camera tự động đi theo nhân vật trong suốt quá trình chơi.
* **Camera Bounds:** Giới hạn phạm vi cuộn của camera theo kích thước bản đồ.
* Display màn hình **Game Over** khi người chơi hết máu/rơi vào bẫy.
* Display màn hình **Victory (Chiến thắng)** khi người chơi hoàn thành mục tiêu.

### 3.7. Âm thanh (Audio)
* Hiệu ứng âm thanh (SFX) khi nhân vật thực hiện hành động nhảy.
* Hiệu ứng âm thanh khi ăn xu/thu thập vật phẩm.
* Tích hợp nhạc nền (Background Music) tạo không khí cho trò chơi.

---

## 4. Hướng dẫn tải và trải nghiệm game

1. Tải về tệp nén **`GamePixel2D.zip`**.
2. Giải nén tệp vừa tải về bằng **WinRAR** hoặc **7-Zip**.
3. Mở thư mục đã giải nén và khởi chạy tệp **`Modau.exe`** để bắt đầu chơi.

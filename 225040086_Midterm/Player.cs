class Player
{
    public int X { get; set; }
    public int Y { get; set; }
    public string Name { get; set; }  // Oyuncunun ismini tutan özellik

    // Yapıcı fonksiyon ile oyuncunun başlangıç konumunu ve ismini ayarlıyoruz
    public Player(string name, int x, int y)
    {
        Name = name;
        X = x;
        Y = y;
    }
}
// Bu kodlarda gptden yardım aldım
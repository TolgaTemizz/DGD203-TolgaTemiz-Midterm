class Program
{
    static void Main()
    {
        // Oyuncudan ismini alıyoruz
        Console.Write("Lütfen isminizi girin: ");
        string playerName = Console.ReadLine();

        // Oyuncuyu (0, 0) konumunda başlatıyoruz (Başlangıç Noktası)
        Player player = new Player(playerName, 0, 0);
        Map map = new Map();

        // Oyuncu hareket etmeye başlıyor
        map.DisplayLocation(player); // Başlangıç konumunu göster
        map.AskQuestions(player);    // Başlangıç sorularını sor

        while (true)
        {
            map.Move(player); // Oyuncu yön seçer
        }
    }
}
// Bu kodlarda gptden yardım aldım
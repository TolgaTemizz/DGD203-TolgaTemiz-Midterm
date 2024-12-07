using System;

class Map
{
    private readonly string[] locations = { "Başlangıç Noktası", "Orman", "Köy", "Göl", "Mağara" };

    private bool heardSwordStory = false; // Köyde kılıç hikayesini duyup duymadığı
    private bool foundSword = false; // Mağarada kılıcı bulup bulmadığı
    private bool savedForestAnimal = false; // Ormanda hayvanı kurtarıp kurtarmadığı
    private bool discoveredLakeTreasure = false; // Gölde bir define keşfedip etmediği


    public void DisplayLocation(Player player)
    {
        string locationName = GetLocationName(player);
        Console.WriteLine($"Şu anda {locationName} bölgesindesiniz, {player.Name}.");
    }

    private string GetLocationName(Player player)
    {
        if (player.X == 0 && player.Y == 0) return locations[0];
        if (player.X == 1 && player.Y == 0) return locations[1];
        if (player.X == 0 && player.Y == 1) return locations[2];
        if (player.X == 1 && player.Y == 1) return locations[3];
        if (player.X == 2 && player.Y == 1) return locations[4];
        return "Bilinmeyen bir konum";
    }

    public void AskQuestions(Player player)
    {
        string locationName = GetLocationName(player);

        switch (locationName)
        {
            case "Başlangıç Noktası":
                StartPointDialog(player);
                break;
            case "Orman":
                ForestDialog(player);
                break;
            case "Köy":
                VillageDialog(player);
                break;
            case "Göl":
                LakeDialog(player);
                break;
            case "Mağara":
                CaveDialog(player);
                break;
            default:
                Console.WriteLine("Bilinmeyen bir yerde maceraya hazırsınız.");
                break;
        }
    }

    private void StartPointDialog(Player player)
    {
        Console.WriteLine($"Hoş geldin, {player.Name}. Burası maceranı başlatacağın yer.");
    }

    private void ForestDialog(Player player)
    {
        Console.WriteLine($"Ormana hoş geldiniz, {player.Name}. Çevrede bir sessizlik hakim.");

        if (!savedForestAnimal)
        {
            Console.WriteLine("Ağaçların arasında yaralı bir hayvan gördünüz. Yardım etmeye çalışırken aniden bir kurt ortaya çıkıyor!");

            if (foundSword)
            {
                Console.WriteLine("Mağarada bulduğunuz kılıcı kullanarak kurdu uzaklaştırmayı başarıyorsunuz!");
                Console.WriteLine("Hayvanı kurtardınız. Size minnettarlığını gösteriyor ve çevredeki gizli bir alanı işaret ediyor.");
                savedForestAnimal = true; // Hayvan kurtarıldı
            }
            else
            {
                Console.WriteLine("Kurt çok güçlü ve elinizde savunacak bir şey yok. Hayvanı kurtaramıyorsunuz.");
                Console.WriteLine("Belki de bir kılıç olsaydı yardım edebilirdiniz...");
            }
        }
        else
        {
            Console.WriteLine("Hayvan size minnettar bir şekilde bakıyor ve size daha önce gösterdiği gizli alanda bir sandık buluyorsunuz.");
            Console.WriteLine("Sandığın içinde biraz altın buldunuz!");
        }
    }

    private void VillageDialog(Player player)
    {
        Console.WriteLine($"Köye hoş geldiniz, {player.Name}. Köylüler sizi merakla izliyor.");

        // Eğer kılıç bulunduysa köylülerin tepkisi
        if (foundSword)
        {
            Console.WriteLine("Köy meydanına geldiğinizde köylüler mağaradaki efsanevi kılıcı elinizde fark ediyor.");
            Console.WriteLine("Köylüler hayranlıkla bakıyor ve aranızdan biri size şöyle diyor:");
            Console.WriteLine("\"Bu, yıllardır kimsenin bulamadığı kılıç! Sen gerçek bir kahramansın!\"");
            Console.WriteLine("Köylüler size yiyecek ve su ikram ediyor.");
        }

        // Hazine bulunmuşsa fakir köylü sahnesi
        if (discoveredLakeTreasure)
        {
            Console.WriteLine("Köyde gezinirken zor durumda bir köylüyle karşılaştınız.");
            Console.WriteLine("Köylü size yaklaşıp der ki:");
            Console.WriteLine("\"Efendim, ailemle birlikte büyük bir borç içindeyiz. Çocuklarımı doyuracak hiçbir şeyim yok...\"");
            Console.WriteLine("Bu köylüye göldeki hazinenizi vermek ister misiniz? (evet/hayir): ");
            string answer = Console.ReadLine().ToLower();

            if (answer == "evet")
            {
                Console.WriteLine("Hazinenizi köylüye verdiniz. Gözleri yaşla dolarak size teşekkür ediyor.");
                Console.WriteLine("\"Siz gerçekten bir kahramansınız! Bu iyiliğinizi asla unutmayacağız.\"");
                discoveredLakeTreasure = false; // Hazine artık oyuncuda değil
            }
            else if (answer == "hayir")
            {
                Console.WriteLine("Köylünün hikayesini dinlediniz ama hazinenizi paylaşmamaya karar verdiniz.");
                Console.WriteLine("Köylü üzgün bir şekilde yanınızdan ayrılıyor.");
            }
            else
            {
                Console.WriteLine("Geçersiz seçim. Köylü size ümitsiz bir şekilde bakıyor.");
            }
        }
        else
        {
            Console.WriteLine("Köy meydanında bir şenlik düzenleniyor. Katılmak ister misiniz? (evet/hayir): ");
            string answer = Console.ReadLine().ToLower();
            if (answer == "evet")
            {
                Console.WriteLine("Şenliğe katıldınız ve yeni arkadaşlıklar kurdunuz.");
                Console.WriteLine("Köylüler size bir efsaneden bahsediyor. Hikayeyi dinlemek ister misiniz? (evet/hayir): ");
                string secondAnswer = Console.ReadLine().ToLower();
                if (secondAnswer == "evet")
                {
                    Console.WriteLine("Efsaneyi dinlediniz: Eski bir mağarada saklanan bir kılıç olduğu söyleniyor.");
                    heardSwordStory = true; // Hikayeyi dinledi olarak işaretle
                }
                else
                {
                    Console.WriteLine("Hikayeyi dinlemediniz ve yürümeye devam ettiniz.");
                }
            }
            else
            {
                Console.WriteLine("Şenliğe katılmadan köyde gezinmeye devam ettiniz.");
            }
        }
    }

    private void LakeDialog(Player player)
    {
        Console.WriteLine($"Göl kenarına geldiniz, {player.Name}. Suyun üzerinde bir huzur var.");

        if (!discoveredLakeTreasure)
        {
            Console.WriteLine("Soru: Gölün kıyısında suya batmış eski bir sandık fark ettiniz. Çıkarmayı dener misiniz? (evet/hayir): ");
            string answer = Console.ReadLine().ToLower();
            if (answer == "evet")
            {
                if (savedForestAnimal)
                {
                    Console.WriteLine("Ormanda kurtardığınız hayvan yanınıza geliyor ve güçlü pençeleriyle sandığı çıkarmanıza yardım ediyor!");
                    Console.WriteLine("Sandığın içinde eski bir hazine buluyorsunuz. Altın ve mücevherlerle dolu!");
                    discoveredLakeTreasure = true; // Defineyi keşfetti olarak işaretle
                }
                else if (foundSword)
                {
                    Console.WriteLine("Köyde size hayran olan köylülerden biri size yardım etmek için geliyor.");
                    Console.WriteLine("Beraber sandığı çıkarmayı başarıyorsunuz. İçinde eski bir hazine buluyorsunuz!");
                    discoveredLakeTreasure = true; // Defineyi keşfetti olarak işaretle
                }
                else
                {
                    Console.WriteLine("Sandığı çıkarmaya çalışıyorsunuz, ama çok ağır! Tek başınıza bunu yapamıyorsunuz.");
                    Console.WriteLine("Belki yardım edecek birini bulabilir ya da başka bir yol düşünebilirsiniz.");
                }
            }
            else if (answer == "hayir")
            {
                Console.WriteLine("Sandığa dokunmadan göl kenarında huzuru izlemeye devam ettiniz.");
            }
            else
            {
                Console.WriteLine("Geçersiz seçim. Göl kenarındaki maceranızı tamamlamadınız.");
            }
        }
        else
        {
            Console.WriteLine("Sandığı zaten çıkardınız. Göl kenarında başka şeyler arıyorsunuz.");
        }
    }

   private void CaveDialog(Player player)
{
    Console.WriteLine($"Karanlık ve gizemli bir mağaraya girdiniz, {player.Name}.");
    Console.WriteLine("Mağaranın derinliklerinde eski bir sunağın üzerinde efsanevi kılıcı görüyorsunuz.");
    Console.WriteLine("Ancak sunağın önünde bir yazıt belirdi. Kılıcı almanız için bir bilmeceyi çözmeniz gerekiyor.");

    if (!foundSword)
    {
        Console.WriteLine("Bilmece: \"Sahibim beni asla tutamaz. Herkes beni taşır ama kimse göremez. Bu nedir?\"");
        Console.WriteLine("1. Gökyüzü\n2. İsim\n3. Düşünce\n4. Nefes");
        Console.Write("Cevabınızı seçin (1-4): ");
        
        string answer = Console.ReadLine();
        
        if (answer == "4")
        {
            Console.WriteLine("Doğru cevap! Sunağın ışığı parlıyor ve kılıcı güvenle alıyorsunuz.");
            Console.WriteLine("Efsanevi kılıcı artık kuşandınız. Gücünüzü hissetmeye başlıyorsunuz.");
            foundSword = true;
        }
        else
        {
            Console.WriteLine("Yanlış cevap! Sunağın ışığı sönüyor. Tekrar denemek ister misiniz? (evet/hayir): ");
            string tryAgain = Console.ReadLine().ToLower();
            if (tryAgain == "evet")
            {
                CaveDialog(player); // Tekrar mağara diyaloğuna dön
            }
            else
            {
                Console.WriteLine("Mağarayı terk ediyorsunuz. Belki başka zaman tekrar deneyebilirsiniz.");
            }
        }
    }
    else
    {
        Console.WriteLine("Kılıcı zaten aldınız. Mağarada başka bir şey bulamadınız.");
    }
}

    public void Move(Player player)
    {
        Console.WriteLine("Nereye gitmek istersiniz?");
        Console.WriteLine("1 - Başlangıç Noktasına (0, 0)");
        Console.WriteLine("2 - Orman'a (1, 0)");
        Console.WriteLine("3 - Köy'e (0, 1)");
        Console.WriteLine("4 - Göl'e (1, 1)");
        Console.WriteLine("5 - Mağara'ya (2, 1)");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                player.X = 0;
                player.Y = 0;
                break;
            case 2:
                player.X = 1;
                player.Y = 0;
                break;
            case 3:
                player.X = 0;
                player.Y = 1;
                break;
            case 4:
                player.X = 1;
                player.Y = 1;
                break;
            case 5:
                player.X = 2;
                player.Y = 1;
                break;
            default:
                Console.WriteLine("Geçersiz seçim.");
                break;
        }

        DisplayLocation(player);
        AskQuestions(player);
    }
}
// Bu kodlarda gptden yardım aldım
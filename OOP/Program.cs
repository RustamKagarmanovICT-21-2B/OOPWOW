using ClassLibraryGame;




Blacksmith blacksmith = new Blacksmith ("John the Blacksmith", 21,3);
Blacksmith anotherBlacksmith = new Blacksmith("John the Blacksmith", 21, 3);



// Использование метода ToString()
Console.WriteLine(blacksmith.ToString());

// Использование метода Equals()
Console.WriteLine($"Is blacksmith equal to anotherBlacksmith? {blacksmith.Equals(anotherBlacksmith)}");

// Использование метода GetHashCode()
Console.WriteLine($"Hash code of blacksmith: {blacksmith.GetHashCode()}");






/*
Player player = new Player("Герой");
Blacksmith blacksmith = new Blacksmith("Борис", 21, 4);

// Добавление предметов в инвентарь игрока
player.Inventory.Add(new Item("Меч", 5));
player.Inventory.Add(new Item("Щит", 3));

// Игровой цикл
bool playing = true;
while (playing)
{
    Console.WriteLine("Добро пожаловать в кузницу! Вы можете улучшить свое оружие здесь.");
    player.ShowInventory();
    Console.WriteLine("Введите название предмета для улучшения или 'выход' для выхода из игры:");
    string input = Console.ReadLine();

    if (input.ToLower() == "выход")
    {
        playing = false;
        continue;
    }

    Item itemToForge = player.Inventory.Find(item => item.Name.ToLower() == input.ToLower());
    if (itemToForge != null)
    {
        blacksmith.Forge(itemToForge);
    }
    else
    {
        Console.WriteLine("Предмет не найден в инвентаре.");
    }
}

Console.WriteLine("Спасибо за игру!");
*/
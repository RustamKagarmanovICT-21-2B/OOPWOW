using ClassLibraryGame;


bool isRunning = true;
while (isRunning)
{
    Console.WriteLine("Выберите действие:");
    Console.WriteLine("1. Управление финансами кузнеца");
    Console.WriteLine("2. Работа с методами класса Object");
    Console.WriteLine("3. Взаимодействие между Кузнецом и Предметами");
    Console.WriteLine("4. Выход");
    Console.Write("Введите цифру выбранного действия: ");

    string choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            ManageBlacksmithFinances();
            break;
        case "2":
            WorkWithObjectMethods();
            break;
        case "3":
            InteractWithBlacksmithAndItems();
            break;
        case "4":
            isRunning = false;
            Console.WriteLine("Программа завершена.");
            break;
        default:
            Console.WriteLine("Неверный выбор, попробуйте еще раз.");
            break;
    }
    
}

static void ManageBlacksmithFinances()
{
    // Делегаты

    // Создаем экземпляр класса Money с начальным балансом
    Money blacksmithMoney = new Money(100);

    // Добавляем деньги, используя делегат
    blacksmithMoney.PerformMoneyOperation(Money.AddMoney, 50);

    // Вычитаем деньги, используя делегат
    blacksmithMoney.PerformMoneyOperation(Money.DelMoney, 30);

    // Выводим текущий баланс
    Console.WriteLine($"Текущий баланс: {blacksmithMoney.GetMoney()}");
}


static void WorkWithObjectMethods()
{
    
    //Перегрузка методов класса Object

    Blacksmith blacksmith = new Blacksmith ("John the Blacksmith", 21,3);
    Blacksmith anotherBlacksmith = new Blacksmith("Steave the Blacksmith", 37, 5);



    // Использование метода ToString()
    Console.WriteLine(blacksmith.ToString());

    // Использование метода Equals()
    Console.WriteLine($"Is blacksmith equal to anotherBlacksmith? {blacksmith.Equals(anotherBlacksmith)}");

    // Использование метода GetHashCode()
    Console.WriteLine($"Hash code of blacksmith: {blacksmith.GetHashCode()}");

}





static void InteractWithBlacksmithAndItems()
{
    //*Использование классов Кузнец и Предмет (взаимодействие между ними)
    // * Кузнец может с какой то вероятностью прокачать предмет
    // * Вертоятность зависит от уровня скилла самого кузнеца и велечины прокачиваемого уровня
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

        if (input.Equals("выход", StringComparison.CurrentCultureIgnoreCase))
        {
            playing = false;
            continue;
        }

        Item itemToForge = player.Inventory.Find(item =>
            item.Name.Equals(input, StringComparison.CurrentCultureIgnoreCase));

        if (itemToForge != null)
        {
            // Предлагаем выбор стратегии улучшения
            Console.WriteLine("Выберите тип улучшения: 1 - Стандартное, 2 - Мастерское");
            string strategyChoice = Console.ReadLine();
            /// вот тут надо добавить выбор стратегии
            if (strategyChoice == "2")
            {
                blacksmith.SetForgingStrategy(new MasterForgingStrategy());
                Console.WriteLine("Выбрано мастерское улучшение (высокий риск, высокая награда)");
            }
            else
            {
                blacksmith.SetForgingStrategy(new StandardForgingStrategy());
                Console.WriteLine("Выбрано стандартное улучшение");
            }

            blacksmith.Forge(itemToForge);
        }
        else
        {
            Console.WriteLine("Предмет не найден в инвентаре.");
        }
    }
}
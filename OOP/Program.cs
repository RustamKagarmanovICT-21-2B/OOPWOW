using ClassLibraryGame;

class Program
{
    private static EnhancedBlacksmith _blacksmith;
    private static Inventory _inventory;
    private static ResourceSystem _resources;

    static void Main(string[] args)
    {
        InitializeGame();

        bool isRunning = true;
        while (isRunning)
        {
            int choice = ConsoleHelper.ShowMenu("ГЛАВНОЕ МЕНЮ",
                "Управление финансами",
                "Работа с кузнецом",
                "Просмотр инвентаря",
                "Управление ресурсами",
                "Выход");

            switch (choice)
            {
                case 1: ManageFinances(); break;
                case 2: WorkWithBlacksmith(); break;
                case 3: _inventory.DisplayInventory(); break;
                case 4: ManageResources(); break;
                case 5: isRunning = false; break;
            }
        }

        ConsoleHelper.WriteSuccess("Игра завершена. До свидания!");
    }

    static void InitializeGame()
    {
        MasterForgingStrategy forgingStrategy = new MasterForgingStrategy();
        
        // Инициализация игровых систем
        _blacksmith = new EnhancedBlacksmith("Борис", 5, forgingStrategy);
        _inventory = new Inventory(15);
        _resources = new ResourceSystem();

        // Добавление стартовых предметов
        _inventory.AddItem(new Weapon("Стальной меч", 10, 2));
        _inventory.AddItem(new Armor("Кожаный доспех", 5, 1));
        _inventory.AddItem(new Weapon("Деревянный щит", 3, 1));

        ConsoleHelper.WriteHeader("ДОБРО ПОЖАЛОВАТЬ В КУЗНИЦУ");
        Console.WriteLine("Вы - владелец кузницы, который принимает заказы на улучшение предметов.");
        Console.WriteLine("Развивайте свои навыки, зарабатывайте ресурсы и улучшайте оборудование!");
    }

    static void ManageFinances()
    {
        Money money = new Money(150);

        int choice = ConsoleHelper.ShowMenu("УПРАВЛЕНИЕ ФИНАНСАМИ",
            "Показать баланс",
            "Добавить деньги",
            "Вычесть деньги",
            "Назад");

        switch (choice)
        {
            case 1:
                Console.WriteLine($"Текущий баланс: {money.GetMoney()} золотых");
                break;
            case 2:
                Console.Write("Введите сумму для добавления: ");
                if (int.TryParse(Console.ReadLine(), out int addAmount))
                {
                    money.PerformMoneyOperation(Money.AddMoney, addAmount);
                    ConsoleHelper.WriteSuccess($"Добавлено {addAmount} золотых");
                }
                break;
            case 3:
                Console.Write("Введите сумму для вычитания: ");
                if (int.TryParse(Console.ReadLine(), out int subtractAmount))
                {
                    money.PerformMoneyOperation(Money.DelMoney, subtractAmount);
                    ConsoleHelper.WriteSuccess($"Вычтено {subtractAmount} золотых");
                }
                break;
        }
    }

    static void WorkWithBlacksmith()
    {
        int choice = ConsoleHelper.ShowMenu("РАБОТА С КУЗНЕЦОМ",
            "Информация о кузнеце",
            "Улучшить предмет",
            "Назад");

        switch (choice)
        {
            case 1:
                Console.WriteLine(_blacksmith.ToString());
                Console.WriteLine($"Уровень навыка: {_blacksmith.SkillLevel}");
                Console.WriteLine($"Опыт: {_blacksmith.Experience}/{(int)(_blacksmith.SkillLevel * 20 * 0.8)}");
                Console.WriteLine($"Выполнено улучшений: {_blacksmith.ForgesCompleted}");
                break;

            case 2:
                _inventory.DisplayInventory();
                Console.Write("Введите название предмета для улучшения: ");
                string itemName = Console.ReadLine();

                ItemBase itemToForge = _inventory.FindItem(itemName);
                if (itemToForge != null)
                {
                    // Проверка стоимости улучшения
                    int cost = itemToForge.Quality * 15;
                    if (_resources.HasEnoughResources("Золото", cost))
                    {
                        _resources.SpendResources("Золото", cost);
                        ItemBase forgedItem = _blacksmith.Forge(itemToForge);

                        if (forgedItem != itemToForge) // Если предмет был изменен
                        {
                            _inventory.RemoveItem(itemToForge);
                            _inventory.AddItem(forgedItem);
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteError($"Недостаточно золота! Требуется: {cost}");
                    }
                }
                else
                {
                    ConsoleHelper.WriteError("Предмет не найден в инвентаре!");
                }
                break;
        }
    }

    static void ManageResources()
    {
        _resources.DisplayResources();

        int choice = ConsoleHelper.ShowMenu("УПРАВЛЕНИЕ РЕСУРСАМИ",
            "Добавить ресурсы",
            "Назад");

        if (choice == 1)
        {
            // Упрощенная система добавления ресурсов
            _resources.AddResources("Золото", 50);
            _resources.AddResources("Железо", 20);
            ConsoleHelper.WriteSuccess("Ресурсы добавлены!");
            _resources.DisplayResources();
        }
    }
}
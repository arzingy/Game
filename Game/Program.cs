using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Game
{
    class Program
    {
        static Wizard ArDash = new Wizard("Ардаш", Person.Race.человек, Person.Gender.женский, 100, 100000);
        static List<string> dialog = new List<string> { "Здравствуй, путник! Ты знаешь, кто я?" };
        static void Main(string[] args)
        {
            int changing = -1;
        
            ShowDialog(false);
            Console.Write("A: Без понятия!\nB: О да!\nC: Я хочу домой\nЧто угодно другое: *просто молчать*");
            var keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.A:
                    dialog.Add("Не имею ни малейшего понятия!");
                    dialog.Add("Это обидно! Вот я о тебе знаю всё... Ну да ладно, я просто больше интересуюсь окружающими!");
                    break;
                case ConsoleKey.B:
                    dialog.Add("Конечно!");
                    dialog.Add("Запахло ложью... Но ладно, думаю, ты просто пытался быть вежливым.");
                    break;
                case ConsoleKey.C:
                    dialog.Add("Я просто хочу домой...");
                    dialog.Add("Я тоже! Но, к сожалению, ты внезапно тут появился, и теперь мне надо тебе всё рассказать.");
                    break;
                default:
                    dialog.Add("*молчание*");
                    dialog.Add("Ну, ты бы поговорил со мной... Ладно, может потом разговоришься!");
                    break;
            }
            dialog[dialog.Count - 1] = dialog[dialog.Count - 1] + "\n\nМеня зовут " + ArDash.Name + ", и я - обычный безработный балыга. Но сегодня именно я расскажу тебе, как работает эта игра!\n\nСначала мне стоит вспомнить, как тебя зовут... Ну-ка, скажи мне своё имя!";
            string aname = "";
            ShowDialog(false);
            do
            {
                ShowDialog(true);
                Console.Write("Введите имя: ");
                aname = Console.ReadLine();
                if (aname == "")
                {
                    Console.WriteLine("\n\nНе оставляйте строчку пустой!");
                    Console.Write("Нажмите любую клавишу...");
                    Console.ReadKey(true);
                }
            }
            while (aname == "");
            dialog.Add("Меня зовут " + aname);
            dialog.Add(aname + "? Фу... Ну да ладно, у тебя имени всё равно больше никто не спросит.\n\nПо тебе и не понять, кстати, храбрый ли ты воин или отважная воительница!\n\nНажми M или W!");
            ShowDialog(false);
            keyInfo = Console.ReadKey(true);
            Person.Gender agender;
            switch (keyInfo.Key)
            {
                case ConsoleKey.M:
                    dialog.Add("Я парень!");
                    agender = Person.Gender.мужской;
                    dialog.Add("Отлично!");
                    break;
                case ConsoleKey.W:
                    dialog.Add("Я девушка!");
                    agender = Person.Gender.женский;
                    dialog.Add("Замечательно!");
                    break;
                default:
                    dialog.Add("Не попадаю по нужным клавишам... Но по имени вроде и так всё понятно...");
                    dialog.Add("Какой грубиян! Ну что же, в этой вселенной ты будешь парнем!");
                    agender = Person.Gender.мужской;
                    break;
            }
            dialog[dialog.Count - 1] = dialog[dialog.Count - 1] + "\n\nЧто же, теперь я знаю кто ты и могу ли я пригласить тебя на свидание после всего этого...\n\nХотя с орками я точно вместе никуда не пойду!\n\nЧто там у тебя по расе? Я очень толерантный, если что...";
            ShowDialog(false);
            Console.WriteLine("Выберите расу:\nA: Орк\nB: Гоблин\nC: Эльф\nD: Гном\nЧто угодно другое: Человек\n\n");
            keyInfo = Console.ReadKey(true);
            Person.Race arace;
            switch (keyInfo.Key)
            {
                case ConsoleKey.A:
                    dialog.Add("Кажется, никак свиданий... Я орк!");
                    arace = Person.Race.орк;
                    dialog.Add("Да... Ну ничего, и в тебя кто-нибудь влюбится, обещаю!");
                    break;
                case ConsoleKey.B:
                    dialog.Add("Живу в болотах, не питюась помётом. Я гоблин!");
                    arace = Person.Race.гоблин;
                    dialog.Add("Может, всё-таки погорячился с орками... Эх...");
                    break;
                case ConsoleKey.C:
                    dialog.Add("Я эльф! Посмотри на мои уши!");
                    arace = Person.Race.эльф;
                    dialog.Add("Да, надо было сразу догадаться... Все эльфы одинаково любят свои уши!");
                    break;
                case ConsoleKey.D:
                    dialog.Add("Я ниже тебя в два раза, а ты балыга! Логично же, что я гном!");
                    arace = Person.Race.гном;
                    dialog.Add("Очень недисциплинированный гномик!");
                    break;
                default:
                    dialog.Add("Хто я? Я - обычный человек...");
                    arace = Person.Race.человек;
                    dialog.Add("Всё, идём на свидание! Всех остальных я на дух не переношу, между нами говоря!");
                    break;
            }
            Wizard player = new Wizard(aname, arace, agender, 18, 100);
    
            AddHealth addhealth = new AddHealth(player);
            RevivingSpell reviving = new RevivingSpell(player);
            ArmorSpell armor = new ArmorSpell(player);
            StopParalysisSpell paralysis = new StopParalysisSpell(player);
            dialog[dialog.Count - 1] = dialog[dialog.Count - 1] + "\n\nНу ладно, шучу. Ты - нормальное и обычное существо.\n\nБудем учить тебя магии в общем! Начнём, пожалуй, с заклинаний.\n\nВот тебе книжечка (прости, что она вся мокрая), тут написаны шесть основных заклинаний этой игры.\n\nПопробуй выучить, например, " + addhealth.name + "!";
            ShowDialog(false);
            LearnSpell(addhealth);
            dialog.Add("Отлично! Теперь давай выучим " + reviving.name + ", оно тоже очень полезно!");
            ShowDialog(false);
            LearnSpell(reviving);
            dialog.Add("Теперь попробуй заклинание " + armor.name + "!");
            ShowDialog(false);
            LearnSpell(armor);
            dialog.Add("Ну и пожалуй, ещё одно... Заклинание " + paralysis.name + "!");
            ShowDialog(false);
            LearnSpell(paralysis);
            dialog.Add("Знаешь что, всё-таки " + paralysis.name + " тебе пока не пригодится... Ну-ка забудь его!");
            ShowDialog(false);
            ForgetSpell(paralysis);
            Stick stick = new Stick(player, 100, 100);
            DeathBootle deathbottle = new DeathBootle(player, 50, DeathBootle.Size.s);
            BasiliskEye basiliskeye = new BasiliskEye(player, 100);
            dialog.Add("Ты такая умница! Я тебе за это подарю... Сейчас... Вот... Вот тебе " + stick.name + "!");
            ShowDialog(false);
            AddArfefact(stick);
            dialog.Add("Кстати, тебе однозначно пригодится " + deathbottle.name + ", так что вот тебе и она...");
            ShowDialog(false);
            AddArfefact(deathbottle);
            dialog.Add("Ну и на всякий пожарный " + basiliskeye.name + "...");
            ShowDialog(false);
            AddArfefact(basiliskeye);
            dialog.Add("Знаешь что? Никакого тебе артефакта " + basiliskeye.name + ", ведь ты " + player.Race_ + "...\n\nВам такое лучше в руки пока не давать, ещё съешь!\n\nА ну отдай!");
            ShowDialog(false);
            TransferArfefact(basiliskeye, ArDash);
            Person somebody = new Person("Обычный орк", Person.Race.орк, Person.Gender.мужской, 100, 50);
        
            somebody.CurrHealth = 20;
            dialog.Add("Замечательно! Давай-ка теперь опробуем всё, что у тебя есть. Вот тебе " + somebody.Name + "...\n\nНачнём с " + addhealth.name + "! Добавь-ка ему чутка, может, 10-15...");
            ShowDialog(false);
            do
            {
                ShowDialog(true);
                Console.Write("Сколько здоровья добавить персонажу " + somebody.Name + ": ");
                try
                {
                    changing = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    changing = -1;
                    Console.WriteLine("\n\nВведите целое число!");
                    Console.Write("Нажмите любую клавишу...");
                    Console.ReadKey(true);
                }
            }
            while (changing == -1);
            UsingSpell(player, somebody, addhealth, changing);
            dialog.Add("Отлично! Теперь давай-ка побьём его с помощью " + stick.name + "...\n\nУ него сейчас " + somebody.CurrHealth + " здоровья, я бы хотел, чтобы ты убил его!");
            ShowDialog(false);
            do
            {
                do
                {
                    ShowDialog(true);
                    Console.Write("С какой силой ударить " + somebody.Name + " (текущая мощь артефакта " + stick.name + ": " + stick.power + "): ");
                    try
                    {
                        changing = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        changing = -1;
                        Console.WriteLine("\n\nВведите целое число!");
                        Console.Write("Нажмите любую клавишу...");
                        Console.ReadKey(true);
                    }
                }
                while (changing == -1);
                UsingArtefact(player, somebody, stick, changing);
                if (somebody.CurrHealth != 0)
                    dialog.Add("Давай ещё, ему маловато!");
            }
            while (somebody.State_ != Person.State.мертв);
            dialog.Add("Эх... Что-то жалко его... Ну-ка оживи его с помощью " + reviving.name + "!");
            ShowDialog(false);
            PressEnter();
            UsingSpell(player, somebody, reviving, 0);
            dialog.Add("Всё, он нам больше неинтересен! Давай-ка немного восстановим твои силы.\n\nИспользуй артефакт " + deathbottle.name + "!");
            ShowDialog(false);
            PressEnter();
            UsingArtefact(player, player, deathbottle, 10);
            dialog.Add("Чувствуешь себя мощнее? Осталось уже немного... Теперь перейдём к очень важному заклинанию - " + armor.name + "! Тот, на кого ты его направишь, становится неуязвимым.\n\nКаждые 30 секунд неуязвимости стоят 50 маны.\n\nНаправь его на меня! А что? Я просто балыга, мне нужна защита...");
            ShowDialog(false);
            do
            {
                do
                {
                    ArDash.CurrHealth = 100000;
                    ShowDialog(true);
                    Console.Write("Сколько секунд неуязвимости добавить персонажу " + ArDash.Name + " (не меньше 30): ");
                    try
                    {
                        changing = Convert.ToInt32(Console.ReadLine());
                        if (changing < 30)
                        {
                            Console.WriteLine("\n\nВведите целое число, большее или равное 30!");
                            Console.Write("Нажмите любую клавишу...");
                            Console.ReadKey(true);
                        }
                    }
                    catch (Exception)
                    {
                        changing = -1;
                        Console.WriteLine("\n\nВведите целое число, большее или равное 30!");
                        Console.Write("Нажмите любую клавишу...");
                        Console.ReadKey(true);
                    }
                }
                while (changing < 30);
                UsingSpell(player, ArDash, armor, changing);
                dialog.Add("А теперь попробуй ударить меня с помощью " + stick.name + "...\n\nЯ тебе автоматически поставлю силу 10. Просто нажми Enter...");
                ShowDialog(false);
                PressEnter();
                UsingArtefact(player, ArDash, stick, 10);
                if (ArDash.CurrHealth != 100000)
                {
                    dialog.Add("Ну, ты бы ещё дольше ждал... Моя неуязвимость уже закончилась!\n\nТебе повезло, я на близкой ноге с разработчиками этой игры, и моё здоровье восстановлено.\n\nА то... Ладно, попробуй-ка ещё разок.");
                }
            }
            while (ArDash.CurrHealth != 100000);
            dialog.Add("Как видишь, мне совсем не больно!\n\nЧто же, обучение подошло к концу... Надеюсь, тебе тут всё понравилось!\n\nТеперь можешь отправляться в отважное приключение и исследовать тут всё вдоль и поперёк!\n\nУдачи, " + player.Name + "!");
            ShowDialog(false);
            Console.Write("Нажмите любую клавишу...");
            Console.ReadKey(true);
        }

        private static void ShowDialog(bool nothread)
        {
            Console.Clear();
            for (int i = 0; i < dialog.Count; i++)
            {
                if (i == dialog.Count - 1 && !nothread)
                    Thread.Sleep(1000);
                if (i % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (i == 0 || i == 2)
                        Console.Write("Некто: ");
                    else Console.Write(ArDash.Name + ": ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Я: ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                Console.WriteLine(dialog[i] + "\n\n");
            }
            Console.ForegroundColor = ConsoleColor.Green;
        }

        private static void PressEnter()
        {
            ConsoleKey currkey = ConsoleKey.Enter;
            Console.Write("Нажмите Enter...");
            do
            {
                var keyInfo = Console.ReadKey(true);
                currkey = keyInfo.Key;
                if (keyInfo.Key == ConsoleKey.Enter)
                    break;
            }
            while (currkey != ConsoleKey.Enter);
        }

        private static void LearnSpell(Spell newspell)
        {
            ConsoleKey currkey = ConsoleKey.L;
            Console.Write("L: Выучить заклинание " + newspell.name);
            do
            {
                var keyInfo = Console.ReadKey(true);
                currkey = keyInfo.Key;
                if (keyInfo.Key == ConsoleKey.L)
                {
                    if (newspell.Speller.LearnNewSpell(newspell))
                        dialog.Add("Заклинание " + newspell.name + " выучено успешно!");
                    else dialog.Add("Заклинание " + newspell.name + " не может быть выучено заново.");
                }
            }
            while (currkey != ConsoleKey.L);
        }

        private static void ForgetSpell(Spell spell)
        {
            ConsoleKey currkey = ConsoleKey.F;
            Console.Write("F: Забыть заклинание " + spell.name);
            do
            {
                var keyInfo = Console.ReadKey(true);
                currkey = keyInfo.Key;
                if (keyInfo.Key == ConsoleKey.F)
                {
                    if (spell.Speller.ForgetSpell(spell))
                        dialog.Add("Заклинание " + spell.name + " вылетело из вашей головы...");
                    else dialog.Add("Заклинание " + spell.name + " не может быть забыто, поскольку оно ещё не выучено.");
                }
            }
            while (currkey != ConsoleKey.F);
        }


        private static void AddArfefact(Artefact newartefact)
        {
            ConsoleKey currkey = ConsoleKey.A;
            Console.Write("A: Добавить в инвентарь артефакт " + newartefact.name);
            do
            {
                var keyInfo = Console.ReadKey(true);
                currkey = keyInfo.Key;
                if (keyInfo.Key == ConsoleKey.A)
                {
                    newartefact.User.GetArtefact(newartefact);
                    dialog.Add("Артефакт " + newartefact.name + " добавлен в инвентарь!");
                }
            }
            while (currkey != ConsoleKey.A);
        }

        private static void TransferArfefact(Artefact newartefact, Person who)
        {
            ConsoleKey currkey = ConsoleKey.T;
            Console.Write("T: Отдать артефакт " + newartefact.name + " персонажу " + who.Name);
            do
            {
                var keyInfo = Console.ReadKey(true);
                currkey = keyInfo.Key;
                if (keyInfo.Key == ConsoleKey.T)
                {
                    newartefact.User.TransferArtefact(newartefact, who);
                    dialog.Add("Артефакт " + newartefact.name + " отдан персонажу " + who.Name + "!");
                }
            }
            while (currkey != ConsoleKey.T);
        }

        private static void UsingSpell(Wizard who, Person towho, Spell usingspell, int power)
        {
            dialog.Add("Выполняем заклинание " + usingspell.name + " на персонажа " + towho.Name);
            if (power != 0)
                dialog[dialog.Count - 1] = dialog[dialog.Count - 1] + (" на мощь " + power);
            dialog[dialog.Count - 1] = dialog[dialog.Count - 1] + ("...");
            int currhealth = towho.CurrHealth;
            bool currarmor = towho.Armor;
            if (who.DoSpell(usingspell, towho, power))
            {
                if (currarmor != towho.Armor)
                    dialog[dialog.Count - 1] = dialog[dialog.Count - 1] + "\n\nПерсонаж " + towho.Name + " стал неуязвимым!";
                ShowingTheSameInfo(currhealth, towho);
                dialog[dialog.Count - 1] = dialog[dialog.Count - 1] + "\n\nМана персонажа " + who.Name + ": " + who.CurrMana;
            }
            else dialog[dialog.Count - 1] = dialog[dialog.Count - 1] + "\n\nНе удалось применить" + usingspell.name + "!";
        }

        private static void UsingArtefact(Person who, Person towho, Artefact usingartefact, int power)
        {
            dialog.Add("Применяем артефакт " + usingartefact.name + " на персонажа " + towho.Name);
            if (power != 0)
                dialog[dialog.Count - 1] = dialog[dialog.Count - 1] + (" на мощь " + power);
            dialog[dialog.Count - 1] = dialog[dialog.Count - 1] + ("...");
            int currhealth = towho.CurrHealth;
            if (who.UseArtefact(usingartefact, towho, power))
            {
                ShowingTheSameInfo(currhealth, towho);
                if (usingartefact is DeathBootle && towho is Wizard)
                {
                    dialog[dialog.Count - 1] = dialog[dialog.Count - 1] + "\n\nМана персонажа " + towho.Name + ": " + (towho as Wizard).CurrMana;
                }
                dialog[dialog.Count - 1] = dialog[dialog.Count - 1] + "\n\nТекущая сила артефакта " + usingartefact.name + ": " + usingartefact.power;
            }
            else dialog[dialog.Count - 1] = dialog[dialog.Count - 1] + "\n\nНе удалось применить" + usingartefact.name + "!";
        }

        private static void ShowingTheSameInfo(int currhealth, Person towho)
        {
            dialog[dialog.Count - 1] = dialog[dialog.Count - 1] + "\n\nЗдоровье персонажа " + towho.Name;
            if (currhealth == towho.CurrHealth)
                dialog[dialog.Count - 1] = dialog[dialog.Count - 1] + " не изменилось";
            else
            {
                if (currhealth < towho.CurrHealth)
                    dialog[dialog.Count - 1] = dialog[dialog.Count - 1] + " увеличилось ";
                else dialog[dialog.Count - 1] = dialog[dialog.Count - 1] + " уменьшилось ";
                if (towho.CurrHealth == towho.Health || towho.CurrHealth == 0)
                    dialog[dialog.Count - 1] = dialog[dialog.Count - 1] + "до предела";
                else dialog[dialog.Count - 1] = dialog[dialog.Count - 1] + "на " + (Math.Abs(currhealth - towho.CurrHealth));
            }
            dialog[dialog.Count - 1] = dialog[dialog.Count - 1] + "\n\nЗдоровье персонажа " + towho.Name + ": " + towho.CurrHealth;
            dialog[dialog.Count - 1] = dialog[dialog.Count - 1] + "\n\nСостояние персонажа " + towho.Name + ": " + towho.State_;
        }
    }
}
    


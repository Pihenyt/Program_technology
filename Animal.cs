using System;

namespace Lecture5Homework
{
    /// <summary>
    /// Базовый класс животного.
    /// </summary>
    public abstract class Animal
    {
        public string Name { get; }

        protected Animal(string name)
        {
            Name = name;
        }

        public virtual string MakeSound() => "...";

        public override string ToString() => $"{GetType().Name}: {Name}";
    }

    /// <summary>
    /// Собака — переопределяет звук.
    /// </summary>
    public class Dog : Animal
    {
        public Dog(string name) : base(name) { }

        public override string MakeSound() => "Гав!";
    }

    /// <summary>
    /// Кошка — переопределяет звук.
    /// </summary>
    public class Cat : Animal
    {
        public Cat(string name) : base(name) { }

        public override string MakeSound() => "Мяу!";
    }

    /// <summary>
    /// Контракт для отправки уведомлений любым способом.
    /// </summary>
    public interface INotificationSender
    {
        void Send(string to, string subject, string body);
    }

    /// <summary>
    /// Реальная отправка через SMTP.
    /// </summary>
    public class SmtpEmailSender : INotificationSender
    {
        public void Send(string to, string subject, string body)
            => Console.WriteLine($"Email -> {to}: {subject} ({body})");
    }

    /// <summary>
    /// Подделка отправителя для тестов — ничего реально не отправляет,
    /// а просто запоминает факт и последнего получателя.
    /// </summary>
    public class FakeNotificationSender : INotificationSender
    {
        public bool WasSent { get; private set; }
        public string? LastRecipient { get; private set; }

        public void Send(string to, string subject, string body)
        {
            WasSent = true;
            LastRecipient = to;
        }
    }

    /// <summary>
    /// Сервис уведомлений. Не создаёт зависимость сам,
    /// а принимает её через конструктор — это и есть внедрение зависимостей.
    /// </summary>
    public class NotificationService
    {
        private readonly INotificationSender _sender;

        public NotificationService(INotificationSender sender)
        {
            _sender = sender;
        }

        public void Notify(string to, string message)
        {
            _sender.Send(to, "Уведомление", message);
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Задание 2: NotificationService с реальной отправкой");
            INotificationSender realSender = new SmtpEmailSender();
            NotificationService realService = new NotificationService(realSender);
            realService.Notify("user@mail.com", "Тест");

            Console.WriteLine();
            Console.WriteLine("Задание 2: тест с подделкой");
            FakeNotificationSender fakeSender = new FakeNotificationSender();
            NotificationService testService = new NotificationService(fakeSender);
            testService.Notify("test@mail.com", "Тестовое сообщение");

            Console.WriteLine($"WasSent: {fakeSender.WasSent}");
            Console.WriteLine($"LastRecipient: {fakeSender.LastRecipient}");

            Console.WriteLine();
            Console.WriteLine("Задание 3: проверка типов через is");
            DescribeObject("привет");
            DescribeObject(5);
            DescribeObject(3.14);
            DescribeObject(new Dog("Рекс"));
            DescribeObject(new Cat("Барсик"));
        }

        /// <summary>
        /// Определяет тип переданного объекта и выводит соответствующее сообщение:
        /// для строки — её длину, для числа — квадрат, для животного — его звук,
        /// для прочих типов — "Неизвестный тип".
        /// </summary>
        public static void DescribeObject(object obj)
        {
            if (obj is string s)
            {
                Console.WriteLine($"Строка длиной {s.Length}");
            }
            else if (obj is int i)
            {
                Console.WriteLine($"Квадрат числа: {i * i}");
            }
            else if (obj is Animal animal)
            {
                Console.WriteLine($"{animal.Name} говорит: {animal.MakeSound()}");
            }
            else
            {
                Console.WriteLine("Неизвестный тип");
            }
        }
    }
}
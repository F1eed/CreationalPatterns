NotificationService emailService = new EmailNotificationService();
NotificationService smsService = new SmsNotificationService();

emailService.NotifyUser("Добро пожаловать!");
smsService.NotifyUser("Ваш код подтверждения: 1234");

// Интерфейс продукта

public interface INotifier
{
    void Send(string message);
}

// продукты

public class EmailNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine($"📧 Отправка email: {message}");
    }
}

public class SmsNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine($"📱 Отправка SMS: {message}");
    }
}

// Абстрактный класс creator'а, имеет абстрактный метод создания, которые другие классы, наследовавшиеся от него, реализуют

public abstract class NotificationService
{
    public void NotifyUser(string message)
    {
        INotifier notifier = CreateNotifier();
        notifier.Send(message);
    }

    public abstract INotifier CreateNotifier();
}

// Классы creator'ов, наследуются от абстрактного creator'a, отвечают за создание того или иного объекта

public class EmailNotificationService : NotificationService
{
    public override INotifier CreateNotifier()
    {
        return new EmailNotifier();
    }
}

public class SmsNotificationService : NotificationService
{
    public override INotifier CreateNotifier()
    {
        return new SmsNotifier();
    }
}
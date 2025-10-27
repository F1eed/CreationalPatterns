ISmartHomeFactory modernFactory = new ModernSmartHomeFactory();
var modernHome = new SmartHome(modernFactory);
modernHome.Run();

Console.WriteLine(); 

ISmartHomeFactory vintageFactory = new VintageSmartHomeFactory();
var vintageHome = new SmartHome(vintageFactory);
vintageHome.Run();

// Интерфейсы продуктов
public interface ILight
{
    void TurnOn();
}

public interface IThermostat
{
    void SetTemperature(int t);
}

// Интерфейс фабрики

public interface ISmartHomeFactory
{
    ILight CreateLight();
    IThermostat CreateThermostat();
}

// Конкретная реализация продуктов

public class ModernLight : ILight
{
    public void TurnOn()
    {
        Console.WriteLine("💡 Современная лампа включена");
    }
}

public class ModernThermostat : IThermostat
{
    public void SetTemperature(int t)
    {
        Console.WriteLine($"🌡 Современный термостат установлен на {t}°C");
    }
}

public class VintageLight : ILight
{
    public void TurnOn()
    {
        Console.WriteLine("🕯 Винтажная лампа зажжена");
    }
}

public class VintageThermostat : IThermostat
{
    public void SetTemperature(int t)
    {
        Console.WriteLine($"🔥 Винтажный термостат установлен на {t}°C");
    }
}

// Реализация интерфейса фабрики

public class ModernSmartHomeFactory : ISmartHomeFactory
{
    public ILight CreateLight()
    {
        return new ModernLight();
    }

    public IThermostat CreateThermostat()
    {
        return new ModernThermostat();
    }
}

public class VintageSmartHomeFactory : ISmartHomeFactory
{
    public ILight CreateLight()
    {
        return new VintageLight();
    }

    public IThermostat CreateThermostat()
    {
        return new VintageThermostat();
    }
}

public class SmartHome
{
    private readonly ILight _light;
    private readonly IThermostat _thermostat;
    
    public SmartHome(ISmartHomeFactory factory)
    {
        _light = factory.CreateLight();
        _thermostat = factory.CreateThermostat();
    }

    public void Run()
    {
        _light.TurnOn();
        _thermostat.SetTemperature(22);
    }
}
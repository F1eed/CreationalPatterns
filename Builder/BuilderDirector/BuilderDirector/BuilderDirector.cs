var pizzaBuilder = new PizzaBuilder();
var pepperoniDirector = new PepperoniPizzaDirector();

var myPizza = pepperoniDirector
    .Direct(pizzaBuilder)
    .AddTopping(PizzaTopping.Mushrooms)
    .SetSize(PizzaSize.Large)
    .AddOption(PizzaOption.DoubleCheese)
    .Build();

public enum PizzaSize
{
    Small,
    Medium,
    Large,
}

public enum PizzaSauce
{
    Tomato,
    White,
}

public enum PizzaTopping
{
    Cheese,
    Pepperoni,
    Mushrooms,
}

public enum PizzaOption
{
    DoubleCheese,
    Spices,
}

public record Pizza(PizzaSize Size, PizzaSauce Sauce, IReadOnlyCollection<PizzaTopping> Topping, IReadOnlyCollection<PizzaOption> Options);

public class PizzaBuilder
{
    private PizzaSize _size;
    private PizzaSauce _sauce;
    private readonly List<PizzaTopping> _toppings = [];
    private readonly List<PizzaOption> _options = [];

    public PizzaBuilder SetSize(PizzaSize size)
    {
        _size = size;
        return this;
    }
    
    public PizzaBuilder SetSauce(PizzaSauce sauce)
    {
        _sauce = sauce;
        return this;
    }
        
    public PizzaBuilder AddTopping(PizzaTopping topping)
    {
        _toppings.Add(topping);
        return this;
    }
        
    public PizzaBuilder AddOption(PizzaOption option)
    {
        _options.Add(option);
        return this;
    }

    public Pizza Build()
    {
        return new Pizza(_size, _sauce, _toppings.AsReadOnly(), _options.AsReadOnly());
    }
}

public interface IPizzaDirector
{
    PizzaBuilder Direct(PizzaBuilder builder);
}

public class PepperoniPizzaDirector : IPizzaDirector
{
    public PizzaBuilder Direct(PizzaBuilder builder)
    {
        return builder
            .SetSize(PizzaSize.Medium)
            .SetSauce(PizzaSauce.Tomato)
            .AddTopping(PizzaTopping.Pepperoni);
    }
}
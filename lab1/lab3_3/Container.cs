using System.ComponentModel;

namespace lab1.lab3_3;

internal class Container
{
    private readonly List<IAbstractCar> _cars = new();

    public void Add(IAbstractCar car)
    {
        _cars.Add(car);
        Console.WriteLine($"[Add] {car.GetType().Name} was added to container");

        if (car is INotifyPropertyChanged observable)
        {
            observable.PropertyChanged += OnCarChanged;
        }
    }

    private void OnCarChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (sender is IAbstractCar car && e is PropertyChangedExtendedEventArgs args)
        {
            Console.WriteLine($"[Change] {car.GetType().Name} → '{args.PropertyName}' changed from '{args.OldValue}' to '{args.NewValue}'");
        }
    }
}
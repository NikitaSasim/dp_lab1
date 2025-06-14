using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace lab1.lab3_3;

public abstract class ObservableCar : IAbstractCar, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void Set<T>(ref T field, T value, [CallerMemberName] string? property = null)
    {
        if (!Equals(field, value))
        {
            var oldValue = field;
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedExtendedEventArgs(property, oldValue, value));
        }
    }

    private double _weight;
    private double _length;
    private double _maxSpeed;

    public double Weight
    {
        get => _weight;
        set => Set(ref _weight, value);
    }

    public double Length
    {
        get => _length;
        set => Set(ref _length, value);
    }

    public double MaxSpeed
    {
        get => _maxSpeed;
        set => Set(ref _maxSpeed, value);
    }
}
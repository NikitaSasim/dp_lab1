using System.ComponentModel;

namespace lab1.lab3_3;

public class PropertyChangedExtendedEventArgs : PropertyChangedEventArgs
{
    public object? OldValue { get; }
    public object? NewValue { get; }

    public PropertyChangedExtendedEventArgs(string? name, object? oldVal, object? newVal)
        : base(name)
    {
        OldValue = oldVal;
        NewValue = newVal;
    }
}
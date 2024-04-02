using EShop.Domain.CategoryAggregate.ValueObjects;
using EShop.Domain.Extensions;

namespace EShop.Domain.CategoryAggregate.Entities;

public class Attribute
{
    private const int MaxNameLength = 50;
    
    private readonly string _name = null!; 
    private readonly List<AttributeValue> _values = [];

    public required string Name
    {
        get => _name;
        init => _name = value.ValidateLength(MaxNameLength);
    }
    
    public IReadOnlyCollection<AttributeValue> Values => _values.AsReadOnly();
    
    public void AddOrUpdateValue(string name)
    {
        var existingValue = _values.FirstOrDefault(v => v.Value == name);
        if (existingValue != null)
        {
            Replace(existingValue, existingValue.Increment());
        }
        else
        {
            _values.Add(new AttributeValue { Value = name, Count = 1 });
        }
    }

    internal void RemoveOrUpdateValue(string name)
    {
        var existingValue = _values.First(v => v.Value == name);
        if (existingValue.Count > 1)
        {
            Replace(existingValue, existingValue.Decrement());
        }
        else
        {
            _values.Remove(existingValue);
        }
    }

    private void Replace(AttributeValue oldValue, AttributeValue newValue)
    {
        var index = _values.IndexOf(oldValue);
        _values[index] = newValue;
    }
}
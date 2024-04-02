namespace EShop.Domain.ProductAggregate.Exceptions;

public class IncorrectProductNameException(int minLength , int maxLength):Exception($"The minimum number of characters should be {minLength} and maximum {maxLength};");

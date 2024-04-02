namespace EShop.Domain.ProductAggregate.Exceptions;

public class IncorrectProductCountException() : Exception("The Count of the product cannot be less than zero or equal to zero");

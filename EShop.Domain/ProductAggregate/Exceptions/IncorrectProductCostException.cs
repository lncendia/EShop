namespace EShop.Domain.ProductAggregate.Exceptions;

public class IncorrectProductPriceException() : Exception("The Price of the product cannot be less than zero");

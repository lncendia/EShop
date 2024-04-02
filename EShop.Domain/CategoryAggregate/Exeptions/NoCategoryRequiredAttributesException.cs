namespace EShop.Domain.CategoryAggregate.Exeptions;

public class NoCategoryRequiredAttributesException() : Exception("Category required attributes cannot be empty");

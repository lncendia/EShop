namespace EShop.Application.Abstractions.Exceptions;

public class PhotoSaveException(Exception ex) : Exception("Failed to save photo", ex);
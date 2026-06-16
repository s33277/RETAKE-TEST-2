namespace Test2Retake.Services.Results;

public enum ReturnRentalResult
{
    Success,
    RentalNotFound,
    RentalAlreadyReturned,
    InvalidRentalDate,
    TransactionFailed
}
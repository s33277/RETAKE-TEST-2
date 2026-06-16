using Test2Retake.DTOs.Requests;
using Test2Retake.Services.Results;

namespace Test2Retake.Services;

public interface IRentalService
{
    Task<ReturnRentalResult> ReturnRentalAsync(int id, ReturnRentalRequestDto request);
}
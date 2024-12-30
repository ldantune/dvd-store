using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DvdStore.Communication.Responses.Rental;
using DvdStore.Domain.Repositories.Rental;

namespace DvdStore.Application.UseCases.Rental.Get;

public class GetRentalsByCustomerIdUseCase : IGetRentalsByCustomerIdUseCase
{
    private readonly IMapper _mapper;
    private readonly IRentalReadOnlyRepository _rentalReadOnlyRepository;

    public GetRentalsByCustomerIdUseCase(IMapper mapper, IRentalReadOnlyRepository rentalReadOnlyRepository)
    {
        _mapper = mapper;
        _rentalReadOnlyRepository = rentalReadOnlyRepository;
    }

    public async Task<ResponseRentalsJson> ExecuteAsync(int customerId, int pageNumber, int pageSize, bool isPaged = true)
    {
        var (rentals, totalItems) = await _rentalReadOnlyRepository.GetRentalsByCustomerIdAsync(customerId, pageNumber, pageSize, isPaged);

        var response = new ResponseRentalsJson
        {
            Rentals = _mapper.Map<IList<ResponseRentalJson>>(rentals),
            TotalItems = totalItems,
            PageNumber = pageNumber,
            PageSize = pageSize
        };

        return response;
    }
}

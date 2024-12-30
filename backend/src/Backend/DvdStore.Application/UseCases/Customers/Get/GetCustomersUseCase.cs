using AutoMapper;
using DvdStore.Communication.Responses.Customer;
using DvdStore.Domain.Repositories.Customer;

namespace DvdStore.Application.UseCases.Customers.Get;

public class GetCustomersUseCase : IGetCustomersUseCase
{
    private readonly IMapper _mapper;
    private readonly ICustomerReadOnlyRepository _customerReadOnlyRepository;

    public GetCustomersUseCase(IMapper mapper, ICustomerReadOnlyRepository customerReadOnlyRepository)
    {
        _mapper = mapper;
        _customerReadOnlyRepository = customerReadOnlyRepository;
    }

    public async Task<ResponseCustomersJson> ExecuteAsync(int pageNumber, int pageSize)
    {
        var (customers, totalItems) = await _customerReadOnlyRepository.GetCustomersAsync(pageNumber, pageSize);

        var response = new ResponseCustomersJson
        {
            Customers = _mapper.Map<IList<ResponseCustomerJson>>(customers),
            TotalItems = totalItems,
            PageNumber = pageNumber,
            PageSize = pageSize            
        };

        return response;
    }
}

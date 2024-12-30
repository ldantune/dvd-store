using AutoMapper;
using DvdStore.Communication.Responses.Customer;
using DvdStore.Domain.Repositories.Address;
using DvdStore.Domain.Repositories.City;
using DvdStore.Domain.Repositories.Country;
using DvdStore.Domain.Repositories.Customer;
using DvdStore.Exceptions.ExceptionBase;

namespace DvdStore.Application.UseCases.Customers.GetByCustomerId;

public class GetByCustomerIdUseCase : IGetByCustomerIdUseCase
{
    private readonly IMapper _mapper;
    private readonly ICustomerReadOnlyRepository _customerReadOnlyRepository;
    private readonly IAddressReadOnlyRepository _addressReadOnlyRepository;
    private readonly ICityReadOnlyRepository _cityReadOnlyRepository;
    private readonly ICountryReadOnlyRepository _countryReadOnlyRepository;

    public GetByCustomerIdUseCase(
        IMapper mapper,
        ICustomerReadOnlyRepository customerReadOnlyRepository,
        IAddressReadOnlyRepository addressReadOnlyRepository,
        ICityReadOnlyRepository cityReadOnlyRepository,
        ICountryReadOnlyRepository countryReadOnlyRepository
        )
    {
        _mapper = mapper;
        _customerReadOnlyRepository = customerReadOnlyRepository;
        _addressReadOnlyRepository = addressReadOnlyRepository;
        _cityReadOnlyRepository = cityReadOnlyRepository;
        _countryReadOnlyRepository = countryReadOnlyRepository;
    }
    public async Task<ResponseCustomerJson> ExecuteAsync(int customerId)
    {
        var customer = await _customerReadOnlyRepository.GetCustomerByIdAsync(customerId);

        if (customer is null)
            throw new NotFoundException($"Customer with id {customerId} not found");

        var address = await _addressReadOnlyRepository.GetAddressByIdAsync(customer.AddressId);

        if (address is not null)
            customer.Address = address;

        var city = await _cityReadOnlyRepository.GetCityByIdAsync(customer.Address.CityId);

        if (city is not null)
            customer.Address.City = city;

        var country = await _countryReadOnlyRepository.GetCountryByIdAsync(customer.Address.City.CountryId);

        if (country is not null)
            customer.Address.City.Country = country;

        var response = _mapper.Map<ResponseCustomerJson>(customer);

        return response;
    }
}

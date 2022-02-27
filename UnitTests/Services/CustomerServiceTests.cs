using AutoMapper;
using FluentAssertions;
using Moq;
using SimpleCrm.Application.Dto;
using SimpleCrm.Application.Services;
using SimpleCrm.Domain.Entities;
using SimpleCrm.Domain.Interfaces;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests.Services
{
    public class customerServiceTests
    {
        [Fact]
        public void when_invoking_get_customer_async_it_should_invoke_get_async_on_customer_repositotory()
        {
            //Arrange
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var mapperMock = new Mock<IMapper>();

            var customerService = new CustomerService(customerRepositoryMock.Object,
                                              mapperMock.Object);

            var id = Guid.Parse("D8FF34B8-77F6-443E-A972-CCF98B13E9B1");
            var name = "COMARCH SPÓŁKA AKCYJNA";
            var taxNumber = "6770065406";
            var email = "info@comarch.pl";
            var phoneNumber = "(12)6461000";
            var statusVat = "Czynny";
            var accountNumbers = new List<string>()
            {
                "62105000861000009030124169",
                "67114010100000229060012012"
            };

            var customer = new Customer(id, name, taxNumber, email,
                phoneNumber, statusVat, accountNumbers);

            var customerDto = new CustomerDto()
            {
                Id = customer.Id,
                Name = customer.Name,
                TaxNumber = customer.TaxNumber,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                StatusVat = customer.StatusVat,
                AccountNumbers = customer.AccountNumbers
            };

            mapperMock
                .Setup(x => x.Map<Customer>(customerDto))
                .Returns(customer);

            customerRepositoryMock
                .Setup(x => x.GetById(customer.Id))
                .Returns(customer);

            //Act
            var existingcustomerDto = customerService.GetCustomerById(customer.Id);

            //Assert
            customerRepositoryMock.Verify(x => x.GetById(customer.Id), Times.Once);
            customerDto.Should().NotBeNull();
            customerDto.Name.Should().NotBeNull();
            customerDto.Name.Should().BeEquivalentTo(customer.Name);
            customerDto.TaxNumber.Should().NotBeNull();
            customerDto.TaxNumber.Should().BeEquivalentTo(customer.TaxNumber);
        }
    }
}

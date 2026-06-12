using FluentAssertions;
using RentACar.Domain.Entities.Vehicles.Cars;
using RentACar.Domain.Entities.Vehicles.Cars.Enum;
using RentACar.Domain.Entities.Vehicles.Cars.ValueObjects;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace RentACar.DomainTest;

public class CarTests
{

    // Yeni araba yaratıldığında kurallar doğru işliyor mu
    [Fact]
    public void CreateCar_WithValidParameters_ShouldInitializeCorrectly()
    {
        //arrange
        var brandId = Guid.CreateVersion7();
        var modelWithSpaces = "   M3 Sedan   ";
        var images = new CarImages("https://link.com/cover.jpg", "https://link.com/big.jpg");
        var specs = new CarSpecifications(1000, "Otomatik", 5, 2, "Benzin");
        //act
        var car = new Car(brandId, modelWithSpaces, images, specs);
        //assert
        car.BrandId.Should().Be(brandId);
        car.Model.Should().Be("M3 Sedan");
        car.Status.Should().Be(CarStatus.Available);
        car.Features.Should().BeEmpty();
    }

    //Müsait bir araç başarıyla kiralanabiliyormu
    [Fact]
    public void RentCar_WhenCarIsAvailable_ShouldChangeStatusToRented()
    {
        //arrange
        var car = new Car(Guid.CreateVersion7(), "M3",
            new CarImages("https://link.com/cover.jpg", "https://link.com/big.jpg"),
            new CarSpecifications(1000, "Otomatik", 5, 2, "Benzin")
            );

        //act
        car.RentCar();
        //assert
        car.Status.Should().Be(CarStatus.Rented);
    }

    //bakımdaki araç kiralanabiliyormu testi
    [Fact]
    public void RentCar_WhenCarIsNotAvailable_ShouldThrowInvalidOperationException()
    {
        //arrange
        var car = new Car(Guid.CreateVersion7(), "M3",
           new CarImages("https://link.com/cover.jpg", "https://link.com/big.jpg"),
           new CarSpecifications(1000, "Otomatik", 5, 2, "Benzin"));

        car.SendToMaintenance();

        //act
        Action act = () => car.RentCar();

        //assert
        act.Should().Throw<InvalidOperationException>().WithMessage("Müsait olmayan araç kiralanamaz");
    }

    //null patlıyormu

    [Fact]
    public void AddFeature_WithNullFeature_ShouldThrowArgumentNullException()
    {
        //arrange
        var car = new Car(Guid.CreateVersion7(), "M3",
           new CarImages("https://link.com/cover.jpg", "https://link.com/big.jpg"),
           new CarSpecifications(1000, "Otomatik", 5, 2, "Benzin"));

        //act
        Action act = () => car.AddFeature(null!);
        //assert
        act.Should().Throw<ArgumentNullException>();
    }

    //valueobject test ve negatif kilometre
    [Fact]
    public void NewCarSpecifications_WithNegativeKilometer_ShouldThrowArgumentOutOfRangeException()
    {

        //act
        Action act = () => new CarSpecifications(-50, "Otomatik", 5, 2, "Benzin");
        //assert
        act.Should().Throw<ArgumentOutOfRangeException>().WithParameterName("kilometer");
    }

    //geçersiz url testi
    [Fact]
    public void NewCarImages_WithInvalidUrl_ShouldThrowArgumentException()
    {
        //act
        Action act = () => new CarImages("gecersiz-link.jpg", "https://link.com/big.jpg");


        //assert
        act.Should().Throw<ArgumentException>().WithMessage("*Geçersiz URL formatı.*");
    }



}

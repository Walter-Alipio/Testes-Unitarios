using Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes;

public class PatioTestes : IDisposable
{
  public ITestOutputHelper ConsoleOutPrintTest;
  private Operador testOperator;
  private Patio parking;
  private Veiculo vehicle;

  public PatioTestes(ITestOutputHelper _ConsoleOutPrintTest)
  {
    testOperator = new Operador { Nome = "Michel" };
    parking = new Patio(testOperator);
    vehicle = new Veiculo();
    ConsoleOutPrintTest = _ConsoleOutPrintTest;
  }

  [Fact]
  public void TestInvoicing()
  {
    // Arrange

    vehicle.Proprietario = "Walter Alípio";
    vehicle.Tipo = TipoVeiculo.Automovel;
    vehicle.Cor = "Azul";
    vehicle.Modelo = "Astra";
    vehicle.Placa = "ads-9992";

    parking.RegistrarEntradaVeiculo(vehicle);
    parking.RegistrarSaidaVeiculo(vehicle.Placa);

    // Act
    double invoicing = parking.TotalFaturado();

    // Assert
    Assert.Equal(2, invoicing);
  }

  //testando um volume maior de dados
  [Theory]
  [InlineData("André Silva", "ASD-1498", "Preto", "Gol")]
  [InlineData("Jose Silva", "POL-9242", "Cinza", "Fusca")]
  [InlineData("Maria Silva", "GER-6524", "Azul", "Opala")]
  public void TestInvoicingWithManyVehicles
  (
    string owner,
    string licensePlate,
    string color,
    string model
  )
  {
    //Arrange

    vehicle.Proprietario = owner;
    vehicle.Placa = licensePlate;
    vehicle.Cor = color;
    vehicle.Modelo = model;

    parking.RegistrarEntradaVeiculo(vehicle);
    parking.RegistrarSaidaVeiculo(vehicle.Placa);
    //Act
    double invoicing = parking.TotalFaturado();
    //Assert
    Assert.Equal(2, invoicing);
  }

  [Theory]
  [InlineData("André Silva", "ASD-1498", "Preto", "Gol")]
  public void TestFindVehicleInParkingByLicensePlate
  (
    string owner,
    string licensePlate,
    string color,
    string model
  )
  {
    //Arrange
    var testOperator = new Operador { Nome = "Michel" };
    var parking = new Patio(testOperator);
    var vehicle = new Veiculo();

    vehicle.Proprietario = owner;
    vehicle.Placa = licensePlate;
    vehicle.Cor = color;
    vehicle.Modelo = model;

    parking.RegistrarEntradaVeiculo(vehicle);

    //Act
    var searched = parking.PesquisaVeiculoPorPlaca(licensePlate);
    //Assert
    Assert.Equal(licensePlate, searched.Placa);
  }

  [Fact]
  public void TestChangeVehicleData()
  {
    // Given
    var testOperator = new Operador { Nome = "Michel" };
    var parking = new Patio(testOperator);

    var vehicle = new Veiculo();
    vehicle.Proprietario = "Walter Alípio";
    vehicle.Tipo = TipoVeiculo.Automovel;
    vehicle.Cor = "Azul";
    vehicle.Modelo = "Astra";
    vehicle.Placa = "ads-9992";

    parking.RegistrarEntradaVeiculo(vehicle);

    var changedVehicle = new Veiculo();
    changedVehicle.Proprietario = "Walter Alípio";
    changedVehicle.Tipo = TipoVeiculo.Automovel;
    changedVehicle.Cor = "preto";
    changedVehicle.Modelo = "Opala";
    changedVehicle.Placa = "ads-9992";


    // When
    var changed = parking.AlteraDadosVeiculo(changedVehicle);
    // Then
    Assert.Equal(changed.Cor, changedVehicle.Cor);
  }

  [Theory]
  [InlineData("André Silva", "ASD-1498", "Preto", "Gol")]
  public void TestFindVehicleInParkingById
 (
   string owner,
   string licensePlate,
   string color,
   string model
 )
  {
    //Arrange
    var testOperator = new Operador { Nome = "Michel" };
    var parking = new Patio(testOperator);
    var vehicle = new Veiculo();

    vehicle.Proprietario = owner;
    vehicle.Placa = licensePlate;
    vehicle.Cor = color;
    vehicle.Modelo = model;

    parking.RegistrarEntradaVeiculo(vehicle);

    //Act
    var searched = parking.PesquisaVeiculoPorTicket(vehicle.IdTicket);
    //Assert
    Assert.Contains("### Ticket Estacionameno Alura ###", searched.Ticket);
  }
  public void Dispose()
  {
    ConsoleOutPrintTest.WriteLine("Dispose invocado.");
  }
}
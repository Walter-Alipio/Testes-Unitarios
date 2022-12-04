using Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes;

public class PatioTestes
{
  [Fact]
  public void TestInvoicing()
  {
    // Arrange
    var testOperator = new Operador { Nome = "Michel" };
    var estacionamento = new Patio(testOperator);
    var veiculo = new Veiculo();

    veiculo.Proprietario = "Walter Alípio";
    veiculo.Tipo = TipoVeiculo.Automovel;
    veiculo.Cor = "Azul";
    veiculo.Modelo = "Astra";
    veiculo.Placa = "ads-9992";

    estacionamento.RegistrarEntradaVeiculo(veiculo);
    estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

    // Act
    double invoicing = estacionamento.TotalFaturado();

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
    var testOperator = new Operador { Nome = "Michel" };
    var estacionamento = new Patio(testOperator);
    var veiculo = new Veiculo();

    veiculo.Proprietario = owner;
    veiculo.Placa = licensePlate;
    veiculo.Cor = color;
    veiculo.Modelo = model;

    estacionamento.RegistrarEntradaVeiculo(veiculo);
    estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);
    //Act
    double invoicing = estacionamento.TotalFaturado();
    //Assert
    Assert.Equal(2, invoicing);
  }

  [Theory]
  [InlineData("André Silva", "ASD-1498", "Preto", "Gol")]
  public void TestFindVehicleInParking
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
}
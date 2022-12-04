using Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes;

public class VeiculoTestes
{
  [Fact(DisplayName = "Teste 1")]
  [Trait("Function", "Speed Up")]
  public void TestVehicleSpeedUp()
  {
    //Arrange
    var vehicle = new Veiculo();
    //Act
    vehicle.Acelerar(10);
    //Assert
    Assert.Equal(100, vehicle.VelocidadeAtual);
  }

  [Fact(DisplayName = "Teste 2")]
  [Trait("Function", "Break")]
  public void TestVehicleBreak()
  {
    //Arrange
    var vehicle = new Veiculo();
    //Act
    vehicle.Frear(10);
    //Assert
    Assert.Equal(-150, vehicle.VelocidadeAtual);
  }

  [Fact]
  public void TestTypeVehicle()
  {
    // Arrange
    var vehicle = new Veiculo();
    // Act

    // Assert
    Assert.Equal(TipoVeiculo.Automovel, vehicle.Tipo);
  }

  [Fact(Skip = "Não implementado")]
  public void TestOwnerName()
  {
    // Arrange

    // Act

    // Assert
  }

  [Theory]
  [ClassData(typeof(Veiculo))]
  public void TestVehicleClass(Veiculo model)
  {
    //Arrange
    var vehicle = new Veiculo();
    //Act
    vehicle.Acelerar(10);
    model.Acelerar(10);
    //Assert
    Assert.Equal(model.VelocidadeAtual, vehicle.VelocidadeAtual);
  }

  [Fact]
  public void TestVehicleData()
  {
    // Arrange

    var vehicle = new Veiculo();
    vehicle.Proprietario = "Walter Alípio";
    vehicle.Tipo = TipoVeiculo.Automovel;
    vehicle.Cor = "Azul";
    vehicle.Modelo = "Astra";
    vehicle.Placa = "ads-9992";
    // Act
    string data = vehicle.ToString();
    // Assert
    Assert.Contains("Tipo do Veículo: Automovel", data);
  }
}
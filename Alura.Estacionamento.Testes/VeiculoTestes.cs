using Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes;

public class VeiculoTestes
{
  [Fact]
  public void TestVehicleAcelerate()
  {
    //Arrange
    var vehicle = new Veiculo();
    //Act
    vehicle.Acelerar(10);
    //Assert
    Assert.Equal(100, vehicle.VelocidadeAtual);
  }

  [Fact]
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

}
using Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes;

public class VeiculoTestes
{
  private Veiculo vehicle;
  public ITestOutputHelper ConsoleOutPrintTest;
  public VeiculoTestes(ITestOutputHelper _consoleOutPrintTest)
  {
    ConsoleOutPrintTest = _consoleOutPrintTest;
    vehicle = new Veiculo();
  }

  [Fact]
  public void TestVehicleSpeedUpWithParam10()
  {
    //Arrange

    //Act
    vehicle.Acelerar(10);
    //Assert
    Assert.Equal(100, vehicle.VelocidadeAtual);
  }

  [Fact(DisplayName = "Teste 2")]
  [Trait("Function", "Break")]
  public void TestVehicleBreakWithParam10()
  {
    //Arrange

    //Act
    vehicle.Frear(10);
    //Assert
    Assert.Equal(-150, vehicle.VelocidadeAtual);
  }

  [Fact]
  public void TestTypeVehicle()
  {
    // Arrange

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
  public void TestVehicleClassParam10(Veiculo model)
  {
    //Arrange

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

  [Fact]
  public void TestVehicleOwnerNameWithLessThenThreeCharacters()
  {
    // Arrange
    string ownerName = "Ab";

    // Assert
    Assert.Throws<System.FormatException>(
      // Act
      () => new Veiculo(ownerName)
    );
  }

  [Fact]
  public void TestExceptionMessageOfFourthCharacterOfLicensePlate()
  {
    // Arrange
    string licensePlate = "ASDF8888";

    // Act
    var message = Assert.Throws<System.FormatException>(
      () => new Veiculo().Placa = licensePlate
    );

    // Assert
    Assert.Equal("O 4° caractere deve ser um hífen", message.Message);
  }

  [Fact]
  public void TestExceptionMessageForLastCharactersOfLicensePlate()
  {
    // Arrange
    string licensePlate = "ASD-F88e";

    // Assert
    Assert.Throws<System.FormatException>(
      // Act
      () => new Veiculo().Placa = licensePlate
    );
  }

  public void Dispose()
  {
    ConsoleOutPrintTest.WriteLine("Dispose invocado.");
  }
}
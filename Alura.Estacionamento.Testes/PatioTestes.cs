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
}
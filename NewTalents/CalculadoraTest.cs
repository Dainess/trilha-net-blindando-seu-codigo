using src;

namespace NewTalents;

public class CalculadoraTest
{
    private void TestCurrentValue()
    {
        //Arrange
        int value = 0;
        Calculadora calculadora = new(value);

        //Act
        int testValue = calculadora.CurrentValue;

        //Assert
        Assert.Equal(testValue, value);
    }

    [Theory]
    [InlineData(3, 2, 5)]
    [InlineData(5, -9, -4)]
    [InlineData(16, 64, 80)]
    public void TestSomarDoisNumeros(int val1, int val2, int resultadoEsperado)
    {
        //Arrange
        Calculadora calculadora = new();

        //Act
        int resultado = calculadora.Somar(val1, val2);

        //Asset
        Assert.Equal(resultadoEsperado, resultado);
    }

    [Theory]
    [InlineData(3, 2, 1)]
    [InlineData(5, -9, -4)]
    [InlineData(151, 15, 136)]
    public void TestSubtrairDoisNumeros(int val1, int val2, int resultadoEsperado)
    {
        //Arrange
        Calculadora calculadora = new();

        //Act
        int resultado = calculadora.Subtrair(val1, val2);

        //Asset
        Assert.Equal(resultadoEsperado, resultado);
    }

    [Theory]
    [InlineData(3, 2, 6)]
    [InlineData(5, -9, -45)]
    [InlineData(6, 6, 36)]
    public void TestMultiplicarDoisNumeros(int val1, int val2, int resultadoEsperado)
    {
        //Arrange
        Calculadora calculadora = new();

        //Act
        int resultado = calculadora.Multiplicar(val1, val2);

        //Asset
        Assert.Equal(resultadoEsperado, resultado);
    }

    [Theory]
    [InlineData(3, 2, 1)]
    [InlineData(5, 3, 1)]
    [InlineData(7, 3, 2)]
    public void TestDividirDoisNumeros(int val1, int val2, int resultadoEsperado)
    {
        //Arrange
        Calculadora calculadora = new();

        //Act
        int resultado = calculadora.Dividir(val1, val2);

        //Asset
        Assert.Equal(resultadoEsperado, resultado);
    }

    [Fact]
    public void TestDivisaoPorZero()
    {
        //Arrange
        Calculadora calculadora = new();
        int val1 = 15, val2 = 0;

        //Act
        

        //Asset
        Assert.Throws<DivideByZeroException>(() => calculadora.Dividir(val1, val2));

    }

    [Fact]
    public void TestHistorico()
    {
        //Arrange
        Calculadora calculadora = new();

        //Act
        calculadora.Somar(1, 2);
        calculadora.Somar(5, 8);
        calculadora.Multiplicar(3, 16);
        calculadora.Subtrair(15, 21);
        var lista = calculadora.Historico();
        var tamanhoEsperadoLista = 3;

        //Asset
        Assert.Empty(lista);
        Assert.Equal(tamanhoEsperadoLista, lista.Count);
    }
}
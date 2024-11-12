using src;

namespace NewTalents;

public class CalculadoraTest
{
    public Calculadora construirClasse()
    {
        return new Calculadora(0, DateTime.UtcNow);
    }
    private void TestCurrentValue()
    {
        //Arrange
        int value = 0;
        Calculadora calculadora = new(value, DateTime.UtcNow);

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
        Calculadora calculadora = construirClasse();

        //Act
        int resultado = calculadora.Somar(val1, val2);

        //Asset
        Assert.Equal(resultadoEsperado, resultado);
    }

    [Theory]
    [InlineData(3, 2, 1)]
    [InlineData(5, -9, 14)]
    [InlineData(151, 15, 136)]
    public void TestSubtrairDoisNumeros(int val1, int val2, int resultadoEsperado)
    {
        //Arrange
        Calculadora calculadora = construirClasse();

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
        Calculadora calculadora = construirClasse();

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
        Calculadora calculadora = construirClasse();

        //Act
        int resultado = calculadora.Dividir(val1, val2);

        //Asset
        Assert.Equal(resultadoEsperado, resultado);
    }

    [Fact]
    public void TestDivisaoPorZero()
    {
        //Arrange
        Calculadora calculadora = construirClasse();
        int val1 = 15, val2 = 0;

        //Act
        

        //Asset
        Assert.Throws<DivideByZeroException>(() => calculadora.Dividir(val1, val2));

    }

    [Fact]
    public void TestHistoricoCheio()
    {
        //Arrange
        Calculadora calculadora = construirClasse();

        //Act
        calculadora.Somar(1, 2);
        int resultado1 = calculadora.Somar(5, 8);
        int resultado2 = calculadora.Multiplicar(3, 16);
        int resultado3 = calculadora.Subtrair(15, 21);
        var fila = calculadora.RetornaHistorico();
        var tamanhoEsperadoLista = 3;

        //Asset
        Assert.NotEmpty(fila);
        Assert.Equal(tamanhoEsperadoLista, fila.Count);
        Assert.Equal(fila.ToList(), [resultado1, resultado2, resultado3]);
    }

    [Fact]
    public void TestHistoricoDois()
    {
        //Arrange
        Calculadora calculadora = construirClasse();

        //Act
        int resultado1 = calculadora.Somar(1, 2);
        int resultado2 = calculadora.Multiplicar(3, 16);
        var fila = calculadora.RetornaHistorico();
        var tamanhoEsperadoLista = 2;

        //Asset
        Assert.NotEmpty(fila);
        Assert.Equal(tamanhoEsperadoLista, fila.Count);
        Assert.Equal(fila.ToList(), [resultado1, resultado2]);
    }
}
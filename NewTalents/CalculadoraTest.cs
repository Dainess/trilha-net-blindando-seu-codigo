using src;

namespace NewTalents;

public class CalculadoraTest
{
    [Fact]
    public void TestCurrentValue()
    {
        //Arrange
        double value = 0;
        Calculadora calculadora = new Calculadora(value);

        //Act
        double testValue = calculadora.CurrentValue;

        //Assert
        Assert.Equal(testValue, value);
    }
}
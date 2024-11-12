namespace src;

public class Calculadora(int value)
{
    public Calculadora() : this(0) {}
    public int CurrentValue { get; set; } = value;

    public int Somar(int val1, int val2)
    {
        return 0;
    }

    public int Subtrair(int val1, int val2)
    {
        return -1;
    }

    public int Multiplicar(int val1, int val2)
    {
        return 0;
    }

    public int Dividir(int val1, int val2)
    {
        return 0;
    }

    public List<int> Historico()
    {
        return [];
    }
}

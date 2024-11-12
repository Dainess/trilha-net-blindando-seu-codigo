namespace src;

public class Calculadora(int value, DateTime data)
{
    private Queue<int> Historico { get; set; } = [];
    public Calculadora() : this(0, DateTime.UtcNow) {}
    public DateTime DataDeHoje { get; set; } = data;
    public int CurrentValue { get; set; } = value;

    public int Somar(int val1, int val2)
    {
        int resultado = val1 + val2;
        InserirNoHistorico(resultado);
        return resultado;
    }

    public int Subtrair(int val1, int val2)
    { 
        int resultado = val1 - val2;
        InserirNoHistorico(resultado);
        return resultado;
    }

    public int Multiplicar(int val1, int val2)
    {
        int resultado = val1 * val2;
        InserirNoHistorico(resultado);
        return resultado;
    }

    public int Dividir(int val1, int val2)
    {
        int resultado = val1 / val2;
        InserirNoHistorico(resultado);
        return resultado;
    }

    public Queue<int> RetornaHistorico()
    {
        return Historico;
    }

    private void InserirNoHistorico(int item)
    {
        Historico.Enqueue(item);
        if (Historico.Count > 3)
            Historico.Dequeue();
        CurrentValue = item;
    }
}

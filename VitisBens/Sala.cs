using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;

public class Sala 
{

    private long id;
    private string codigo;
    private string nome;
    private string piso;
    private string descricao;

    public Sala() {

    }

    public Sala(long id, string codigo, string nome, string piso, string descricao)
    {
        this.id = id;
        this.codigo = codigo;
        this.nome = nome;
        this.piso = piso;
        this.descricao = descricao;
    }

    public long Id { get => id; set => id = value; }
    public string Codigo { get => codigo; set => codigo = value; }
    public string Nome { get => nome; set => nome = value; }
    public string Piso { get => piso; set => piso = value; }
    public string Descricao { get => descricao; set => descricao = value; }

    public override bool Equals(object? obj)
    {
        return obj is Sala sala &&
               id == sala.id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(id);
    }
    public static ListaSala CarregaLista() {
        Sala sala1 = new Sala(0, "S1", "Sala 01", "2º andar", "Técnico");
        Sala sala2 = new Sala(0, "S2", "Sala 02", "2º andar", "Engenharia");
        Sala sala3 = new Sala(0, "S3", "Sala 03", "2º andar", "Servidor");
        Sala sala4 = new Sala(0, "S4", "Sala 04", "1º andar", "Oscar");
        Sala sala5 = new Sala(0, "S5", "Sala 05", "1º andar", "Administrativo");
        Sala sala6 = new Sala(0, "S6", "Sala 06", "1º andar", "Sala de Reuniões");
        Sala sala7 = new Sala(0, "S7", "Sala 07", "1º andar", "Oscar Gayer"); 
        ListaSala salas = new ListaSala();
        salas.adicionar(sala1);
        salas.adicionar(sala2);
        salas.adicionar(sala3);
        salas.adicionar(sala4);
        salas.adicionar(sala5);
        salas.adicionar(sala6);
        salas.adicionar(sala7);
        return salas;
    }
}

public class ListaSala: List<Sala> {
    public void adicionar(Sala novo) {
        novo.Id = maxId() + 1;
        this.Add(novo);
    }
    private long maxId() {
        long max = 1;
        foreach (Sala sala in this) {
            if (max < sala.Id) {
                max = sala.Id;
            }
        }
        return max;
    }

}




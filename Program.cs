using System;
using System.Collections.Generic;
using System.Linq;

// Classe base Animal
public class Animal
{
    // Atributos privados e propriedades públicas (Encapsulamento)
    public string Nome { get; set; }
    public int Idade { get; set; }

    // Construtor
    public Animal(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }

    // Método virtual para ser sobrescrito (Polimorfismo)
    public virtual void EmitirSom()
    {
        Console.WriteLine("Som genérico de animal.");
    }

    // Método para exibir informações básicas
    public void ExibirInfo()
    {
        Console.WriteLine($"Nome: {Nome}, Idade: {Idade} anos");
    }
}

// Classe derivada Cachorro (Herança)
public class Cachorro : Animal
{
    // Atributo adicional
    public string Raca { get; set; }

    // Construtor
    public Cachorro(string nome, int idade, string raca) : base(nome, idade)
    {
        Raca = raca;
    }

    // Sobrescrita do método EmitirSom (Polimorfismo)
    public override void EmitirSom()
    {
        Console.WriteLine("Au Au!");
    }

    // Sobrescrita do método ExibirInfo
    public new void ExibirInfo()
    {
        base.ExibirInfo();
        Console.WriteLine($"Raça: {Raca}");
    }
}

// Classe derivada Gato (Herança)
public class Gato : Animal
{
    // Atributo adicional
    public string Cor { get; set; }

    // Construtor
    public Gato(string nome, int idade, string cor) : base(nome, idade)
    {
        Cor = cor;
    }

    // Sobrescrita do método EmitirSom (Polimorfismo)
    public override void EmitirSom()
    {
        Console.WriteLine("Miau!");
    }

    // Sobrescrita do método ExibirInfo
    public new void ExibirInfo()
    {
        base.ExibirInfo();
        Console.WriteLine($"Cor: {Cor}");
    }
}

// Classe PetShop
public class PetShop
{
    // Atributo para armazenar a lista de animais
    private List<Animal> animais = new List<Animal>();

    // Método para adicionar um animal
    public void AdicionarAnimal(Animal a)
    {
        animais.Add(a);
        Console.WriteLine($"{a.Nome} foi adicionado(a) ao PetShop.");
    }

    // Método para listar os animais e suas informações
    public void ListarAnimais()
    {
        Console.WriteLine("\n--- Lista de Animais do PetShop ---");
        foreach (Animal animal in animais)
        {
            // O polimorfismo em tempo de execução permite que a chamada a ExibirInfo e EmitirSom
            // se comporte de forma diferente para Cachorro e Gato, mesmo a lista sendo de tipo Animal.
            if (animal is Cachorro cachorro)
            {
                cachorro.ExibirInfo();
            }
            else if (animal is Gato gato)
            {
                gato.ExibirInfo();
            }
            else
            {
                animal.ExibirInfo();
            }
            
            animal.EmitirSom();
            Console.WriteLine("------------------------------");
        }
    }
}

// Classe principal para execução
class Program
{
    static void Main(string[] args)
    {
        // Criação de uma instância do PetShop
        PetShop meuPetShop = new PetShop();

        // Criação de alguns animais (Cachorros e Gatos)
        Cachorro cachorro1 = new Cachorro("Rex", 5, "Pastor Alemão");
        Gato gato1 = new Gato("Frajola", 3, "Preto e Branco");
        Cachorro cachorro2 = new Cachorro("Bidu", 2, "Golden Retriever");

        // Adicionando os animais ao PetShop
        meuPetShop.AdicionarAnimal(cachorro1);
        meuPetShop.AdicionarAnimal(gato1);
        meuPetShop.AdicionarAnimal(cachorro2);

        // Listando todos os animais
        meuPetShop.ListarAnimais();
    }
}
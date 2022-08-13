using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AbstractClienteFactory factory = new ClienteFactory();
            ICliente cliente = factory.Create(factory.CreateName("Otávio"), factory.CreateSurname("Villas Boas"));
            Console.WriteLine($"Nome: {cliente.Name.Value}\nSobrenome: {cliente.Surname.Value}");
            Console.ReadKey();
        }

        public interface AbstractClienteFactory
        {
            ICliente Create(IModelBase name, IModelBase surname);
            IModelBase CreateName(string name);
            IModelBase CreateSurname(string surname);
        }

        public interface ICliente
        {
            public IModelBase Name { get; set; }
            public IModelBase Surname { get; set; }
        }

        public class ClienteFactory : AbstractClienteFactory
        {
            public ClienteFactory() { return; }

            public ICliente Create(IModelBase name, IModelBase surname)
            {
                return new Cliente(name, surname);
            }

            public IModelBase CreateName(string name)
            {
                return new Name(name);
            }

            public IModelBase CreateSurname(string surname)
            {
                return new Surname(surname);
            }
        }



        public class Cliente : ICliente
        {
            public IModelBase Name { get; set; }
            public IModelBase Surname { get; set; }

            public Cliente(IModelBase name, IModelBase surname)
            {
                Name = name;
                Surname = surname;
            }
        }

        public interface IModelBase
        {
            public string Value { get; set; }

            public bool Verifications(string text);
        }

        public class Name : IModelBase
        {
            public string Value { get; set; }

            public Name(string textName)
            {
                Value = textName;
            }

            public bool Verifications(string text)
            {
                return true;
            }
        }

        public class Surname : IModelBase
        {
            public string Value { get; set; }

            public Surname(string text)
            {
                Value = text;
            }

            public bool Verifications(string text)
            {
                return true;
            }
        }
    }
}
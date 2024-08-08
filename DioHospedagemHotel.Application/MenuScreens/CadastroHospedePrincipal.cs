using DioHospedagemHotel.Application.Utils;
using DioHospedagemHotel.Domain.Entities;
using DioHospedagemHotel.Domain.ValueObjects;

namespace DioHospedagemHotel.Application.MenuScreens
{
    public static class CadastroHospedePrincipal
    {
        public static (string nome, string sobrenome) CadNameLastName()
        {
            Console.Clear();
            Console.WriteLine("Bem vindo ao serviço de Reservas do nosso Hotel!");
            Console.WriteLine("Informe seu nome e sobrenome: ");
            Console.Write("Nome: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name) || name.Contains(" "))
            {
                Console.WriteLine("Nome inválido");
                Console.ReadKey();
                CadNameLastName();
            }

            Console.Write("Sobrenome: ");
            var lastName = Console.ReadLine();
            if (string.IsNullOrEmpty(lastName))
            {
                Console.WriteLine("SobreNome inválido");
                Console.ReadKey();
                CadNameLastName();
            }

            return (name, lastName);
        }

        public static Rg CadRg()
        {
            Console.Clear();
            Console.WriteLine("Informe o seu Rg: ");
            string rg = Console.ReadLine();

            Rg rgVerify = new Rg(rg);
            if (!rgVerify.IsValid().IsValid)
            {
                ResponseManipulate.SeeErrors(rgVerify.IsValid().Message);
                Console.ReadKey();
                CadRg();
            }

            return rgVerify;
        }

        public static Cpf CadCpf()
        {
            Console.Clear();
            Console.WriteLine("Informe o seu Cpf: ");
            string cpf = Console.ReadLine();

            Cpf cpfVerify = new Cpf(cpf);
            if (!cpfVerify.IsValid().IsValid)
            {
                ResponseManipulate.SeeErrors(cpfVerify.IsValid().Message);
                Console.ReadKey();
                CadCpf();
            }
            return cpfVerify;
        }

        public static Email CadEmail()
        {
            Console.Clear();
            Console.WriteLine("Informe o seu Email: ");
            string email = Console.ReadLine();

            Email emailVerify = new Email(email);
            if (!emailVerify.IsValid().IsValid)
            {
                ResponseManipulate.SeeErrors(emailVerify.IsValid().Message);
                Console.ReadKey();
                CadEmail();
            }
            return emailVerify;
        }

        public static Phone CadPhone()
        {
            Console.Clear();
            Console.WriteLine("Informe o seu Telefone: ");
            string phone = Console.ReadLine();

            Phone phoneVerify = new Phone(phone);
            if (!phoneVerify.IsValid().IsValid)
            {
                ResponseManipulate.SeeErrors(phoneVerify.IsValid().Message);
                Console.ReadKey();
                CadPhone();
            }
            return phoneVerify;
        }

        public static HospResponsavel CadHospResponsavel()
        {
            Console.Clear();
            var fullName = CadNameLastName();
            var rg = CadRg();
            var cpf = CadCpf();
            var email = CadEmail();
            var phone = CadPhone();

            return new HospResponsavel(fullName.nome, fullName.sobrenome, rg, cpf, email, phone);
        }
    }
}

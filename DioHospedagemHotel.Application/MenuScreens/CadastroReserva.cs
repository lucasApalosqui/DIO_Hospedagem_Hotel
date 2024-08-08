using DioHospedagemHotel.Application.Utils;
using DioHospedagemHotel.Domain.Entities;
using DioHospedagemHotel.Domain.Enums;
using DioHospedagemHotel.Domain.ValueObjects;

namespace DioHospedagemHotel.Application.MenuScreens
{
    public static class CadastroReserva
    {
        public static Suite CadSuite(List<Suite> suites)
        {
            Console.Clear();
            Console.WriteLine("Lista de Suites Disponiveis");
            suites.ForEach(s => Console.WriteLine($"tipo: {s.Tipo.ToString()} | Capacidade: {s.Capacidade} | Valo diária: {s.ValorDiaria}"));

            MenuWrite.OptionGen(new List<string> {"Solo", "Casal", "Familia", "Premium"});

            try
            {
                Console.WriteLine("Selecione a opção: ");
                var option = short.Parse(Console.ReadLine()!);

                switch(option)
                {
                    case 1:
                        return suites[0];
                    case 2:
                        return suites[1];
                    case 3:
                        return suites[2];
                    case 4:
                        return suites[3];
                    default:
                        Console.WriteLine("Opção inválida, tente novamente");
                        Console.ReadKey();
                        CadSuite(suites);
                        return null;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Opção inválida, tente novamente");
                Console.ReadKey();
                CadSuite(suites);
                return null;
            }
        }

        public static int CadDiasReservados(Suite suite)
        {
            Console.Clear();
            Console.WriteLine($"Quantos dias deseja reservar? (Valor da Diária = {suite.ValorDiaria.ToString("C")})");

            var dias = Console.ReadLine();
            if(!int.TryParse(dias, out var result))
            {
                Console.WriteLine("Apenas numeros são aceitos");
                Console.ReadKey();
                CadDiasReservados(suite);
            }

            return result;
        }

        public static int CadQuantidadeHospedes(Reserva reserva)
        {
            List<HospConvidado> hospedes = new List<HospConvidado>();
            var suite = reserva.Suite;
            int quantidade = 0;
            if (suite.Tipo != TipoSuite.Solo)
            {
                Console.WriteLine($"Quantos hospedes deseja adicionar? max({suite.Capacidade - 1} Pessoas)");
                var quantS = Console.ReadLine();
                try
                {
                    int.TryParse(quantS, out int quant);
                    if (quant < 1 || quant > suite.Capacidade - 1)
                    {
                        Console.WriteLine("Quantidade inválida, Tente novamente");
                        Console.ReadKey();
                        CadQuantidadeHospedes(reserva);
                    }

                    quantidade = quant;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Apenas numeros são permitidos");
                    Console.ReadKey();
                    CadQuantidadeHospedes(reserva);
                }
            }
            
            return quantidade;
        }

        public static HospConvidado CadHospCand()
        {
            Console.WriteLine("Informe o Nome: ");
            var nome = Console.ReadLine();
            if(string.IsNullOrEmpty(nome) || nome.Contains(" "))
            {
                Console.WriteLine("Nome inválido");
                Console.ReadKey();
                CadHospCand();
            }

            Console.WriteLine("Informe o Sobrenome: ");
            var sobrenome = Console.ReadLine();
            if (string.IsNullOrEmpty(sobrenome))
            {
                Console.WriteLine("sobrenome inválido");
                Console.ReadKey();
                CadHospCand();
            }

            Console.WriteLine("Informe o Rg: ");
            string rg = Console.ReadLine();
            Rg rgVerify = new Rg(rg);
            if (!rgVerify.IsValid().IsValid)
            {
                ResponseManipulate.SeeErrors(rgVerify.IsValid().Message);
                Console.ReadKey();
                CadHospCand();
            }

            HospConvidado hosp = new HospConvidado(nome, sobrenome, rgVerify);

            return hosp;
        }

        public static List<HospConvidado> CadAllHosp(Reserva reserva, int quantidade)
        {
            List<HospConvidado> hospConvidados = new List<HospConvidado>();
            if (quantidade != 0)
            {
                Console.Clear();
                Console.WriteLine($"Cadastre o(s) ({quantidade}) Hospede(s)");
                for (int i = 0; i < quantidade; i++)
                {
                    Console.Clear();
                    hospConvidados.Add(CadHospCand());
                }
            }
            
            return hospConvidados;

        }

        public static Reserva CadReserva(List<Suite> suites, HospResponsavel hospRes)
        {
            Suite suite = CadSuite(suites);
            int diasReservados = CadDiasReservados(suite);
            Reserva reserva = new Reserva(suite, hospRes, diasReservados);

            int quantHosp = CadQuantidadeHospedes(reserva);
            List<HospConvidado> listHosp = CadAllHosp(reserva, quantHosp);
            reserva.CadastrarHospedes(listHosp);
            Console.WriteLine("Reserva Realizada com sucesso!");
            Console.ReadKey();

            return reserva;
        }
    }
}

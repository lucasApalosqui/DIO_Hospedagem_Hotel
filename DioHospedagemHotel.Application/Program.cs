using DioHospedagemHotel.Application.MenuScreens;
using DioHospedagemHotel.Domain.Entities;
using DioHospedagemHotel.Domain.Enums;

List<Suite> suites = new List<Suite>()
{
    new Suite(TipoSuite.Solo, 1, 30),
    new Suite(TipoSuite.Casal, 2, 55),
    new Suite(TipoSuite.Familia, 5, 85),
    new Suite(TipoSuite.Premium, 8, 125)
};

var hospedeResponsavel = CadastroHospedePrincipal.CadHospResponsavel();
var reserva = CadastroReserva.CadReserva(suites, hospedeResponsavel);

reserva.GerarArquivoComDadosDaReserva("D:/DEV/DadosHotel.txt");

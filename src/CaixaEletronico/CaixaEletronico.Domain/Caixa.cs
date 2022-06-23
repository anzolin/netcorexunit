namespace CaixaEletronico.Domain
{
    public class Caixa : ICaixa
    {
        public ICollection<int> Saque(int valor)
        {
            var cedulasSacadas = new List<int>();
            var valorRestanteASerSacado = valor;

            while (valorRestanteASerSacado >= Cedula.Duzentos)
            {
                cedulasSacadas.Add(Cedula.Duzentos);

                valorRestanteASerSacado -= Cedula.Duzentos;
            }

            while (valorRestanteASerSacado >= Cedula.Cem)
            {
                cedulasSacadas.Add(Cedula.Cem);

                valorRestanteASerSacado -= Cedula.Cem;
            }

            while (valorRestanteASerSacado >= Cedula.Cinquenta)
            {
                cedulasSacadas.Add(Cedula.Cinquenta);

                valorRestanteASerSacado -= Cedula.Cinquenta;
            }

            while (valorRestanteASerSacado >= Cedula.Vinte)
            {
                cedulasSacadas.Add(Cedula.Vinte);

                valorRestanteASerSacado -= Cedula.Vinte;
            }

            while (valorRestanteASerSacado >= Cedula.Dez)
            {
                cedulasSacadas.Add(Cedula.Dez);

                valorRestanteASerSacado -= Cedula.Dez;
            }

            while (valorRestanteASerSacado >= Cedula.Cinco)
            {
                cedulasSacadas.Add(Cedula.Cinco);

                valorRestanteASerSacado -= Cedula.Cinco;
            }

            while (valorRestanteASerSacado >= Cedula.Dois)
            {
                cedulasSacadas.Add(Cedula.Dois);

                valorRestanteASerSacado -= Cedula.Dois;
            }

            if (cedulasSacadas.Count == 0)
                throw new System.Exception("Não há cedulas disponíveis para o valor solicitado.");

            return cedulasSacadas;
        }

        public bool ValidaCedulasDisponiveis(int valor)
        {
            return valor % 10 == 0;
        }
    }
}

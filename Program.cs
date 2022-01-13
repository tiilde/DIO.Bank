using System;
using System.Collections.Generic;


namespace DIO.Bank {
    class Program {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args) {

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X"){
                switch (opcaoUsuario){
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        CadastrarConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;

                }
                opcaoUsuario = ObterOpcaoUsuario(); 
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void CadastrarConta(){
            Console.WriteLine("Inserir nova conta\n");
            Console.WriteLine("Informe o tipo da conta\n Digite 1 para Conta Física e 2 para Conta Jurídica: ");
            int tipoConta = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o nome do titular da conta: ");
            string nomeTitular = Console.ReadLine();
            Console.WriteLine("Informe o saldo inicial da conta: ");
            double entradaSaldo = double.Parse(Console.ReadLine());
            Console.WriteLine("Informe o crédito da conta: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)tipoConta,
                                        saldoConta: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: nomeTitular);
            listaContas.Add(novaConta);
            Console.WriteLine("Conta cadastrada com sucesso!");
        }

        private static void Transferir() {
			Console.Write("Digite o número da conta de origem: ");
			int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
			int indiceContaDestino = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser transferido: ");
			double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);
		}

        private static void Sacar() {
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser sacado: ");
			double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
		}

        private static void Depositar() {
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser depositado: ");
			double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
		}
        
        private static void ListarContas() {
            Console.WriteLine("Lista de Contas\n");
            if (listaContas.Count == 0){
                Console.WriteLine("Não há contas cadastradas\n");
                return;
            }
            
			for (int i = 0; i < listaContas.Count; i++)
			{
				Conta conta = listaContas[i];
				Console.Write("#{0} - ", i);
				Console.WriteLine(conta);
			}
            
        }

        private static string ObterOpcaoUsuario() {
            Console.WriteLine("Digite a opção desejada: ");
            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Cadastrar Nova Conta");
            Console.WriteLine("3 - Realizar Trânsferência");
            Console.WriteLine("4 - Sacar Dinheiro");
            Console.WriteLine("5 - Depositar Dinheiro");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}

using System;

namespace DIO.Bank {
    public class Conta {
        // propriedades
        private TipoConta TipoConta { get; set; }
        private double SaldoConta { get; set; }
        private double Credito {get; set; }
        private string Nome { get; set; }

        // construtor
        public Conta(TipoConta tipoConta, double saldoConta, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.SaldoConta = saldoConta;
            this.Credito = credito;
            this.Nome = nome;
        }
        // métodos
        public bool Sacar(double valorSaque) { 
            if (this.SaldoConta - valorSaque < (this.Credito *- 1)) { 

                Console.WriteLine("Saldo insuficiente");
                return false;
            }
            this.SaldoConta -= valorSaque;
            Console.WriteLine("Saldo atual da conta é de {0} é de {1}", this.Nome, this.SaldoConta);
            return true;
        } 
        public bool Depositar(double valorDeposito) {
            this.SaldoConta += valorDeposito;
            Console.WriteLine("Saldo atual da conta é de {0} é de {1}", this.Nome, this.SaldoConta);
            return true;
        }
        public void Transferir(double valorTransferencia, Conta contaDestino){
            if(this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }

        }
        // método ToString para representar no console a instância da classe
        public override string ToString(){
            string retorno = "";
            retorno += "Tipo de Conta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.SaldoConta + " | ";
            retorno += "Crédito: " + this.Credito;
            return retorno;

        }
    }
}       

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        //Construir coleções para a "Lista dos Produtos" e "Lista de Compras"
        class produto
        {
            public string nome;
            public double preco;
        }

        List<produto> LISTA_PRODUTOS; //Vai conter os Produtos inicialmente disponíveis
        List<produto> LISTA_COMPRAS; //Vai conter os Produtos durante a execução do software 
        //_______________________________________________________________________________________//

        public Form2()
        {
            InitializeComponent();
        }

        //_______________________________________________________________________________________//
        private void Form2_Load(object sender, EventArgs e)
        {
            //Adicionar produtos a coleção
            LISTA_PRODUTOS = new List<produto>()
            {
                new produto(){ nome = "Cesta Grand Amour", preco = 385.90 },
                new produto(){ nome = "Cesta Sweet Dreams", preco = 264.99 },
                new produto(){ nome = "Cesta Dolce Amore", preco = 205.90 }

            };

            //Colocar "Adicionar produtos a coleção" dentro da listBox (Também irá alinhar o nome e o preço do produto)
            foreach (produto p in LISTA_PRODUTOS)
            {
                lst_produtos.Items.Add(ConstruirLinhaProduto(p));
            }

            //Iniciar a Compra
            IniciarCompras();
        }

         //_______________________________________________________________________________________//
            //Formatar linha do produto na listBox
        private string ConstruirLinhaProduto(produto p)
        { 
            {
                string preco = p.preco.ToString("0.00") + " R$";
                return p.nome + new string(' ', 80 - p.nome.Length - preco.Length) + preco; 
            }            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Deseja realmente retornar a página anterior?",
                "INFORMAÇÃO",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        //_______________________________________________________________________________________//            
        private void IniciarCompras()
        {
            //Inicia um novo Cálculo
            LISTA_COMPRAS = new List<produto>();
            lst_compras.Items.Clear();
            lbl_total.Text = "0.00 R$";

        }

        //_______________________________________________________________________________________//
        private void lst_produtos_DoubleClick(object sender, EventArgs e)
        {
            if (lst_produtos.SelectedIndex == -1) return;
            produto p = LISTA_PRODUTOS[lst_produtos.SelectedIndex];
            AdicionarProdutoCompra(p);
        }

        //_______________________________________________________________________________________//
        private void AdicionarProdutoCompra(produto p)
        {
            //Adicionar um Produto à Compra
            LISTA_COMPRAS.Add(p);
            lst_compras.Items.Add(ConstruirLinhaProduto(p));

            //Calcular Total
            var total = LISTA_COMPRAS.Sum(i => i.preco);
            lbl_total.Text = ("R$ ") + total.ToString("0.00");
        }

        //_______________________________________________________________________________________//
        private void btn_limpar_Click(object sender, EventArgs e)
        {
            IniciarCompras();
        }

        //_______________________________________________________________________________________//
        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SUA COMPRA FOI FINALIZADA COM SUCESSO!" + Environment.NewLine + "QUE A FORÇA ESTEJA COM VOCÊ!" + Environment.NewLine + "VALOR TOTAL: " + lbl_total.Text);
            IniciarCompras();
        }

        private void lbl_total_Click(object sender, EventArgs e)
        {

        }

        private void lst_produtos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class Form3 : Form
    {
        class produtoo
        {
            public string nomee;
            public double precoo;
        }

        List<produtoo> LISTA_PRODUTOSS;
        List<produtoo> LISTA_COMPRASS;
        //__________________________________________________________________//

        public Form3()
        {
            InitializeComponent();
        }
        //__________________________________________________________________//

        private void btnClose3_Click(object sender, EventArgs e)
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

        private void Form3_Load(object sender, EventArgs e)
        {
            //Lista de Produtos
            LISTA_PRODUTOSS = new List<produtoo>()
            {
                new produtoo(){ nomee = "Pão Italiano", precoo = 9.90 },
                new produtoo(){ nomee = "Arranjo de Flores", precoo = 18.99 },
                new produtoo(){ nomee = "Pelúcia 30cm", precoo = 32.64 },
                new produtoo(){ nomee = "Kit Fatias de Queijo", precoo = 32.90 },
                new produtoo(){ nomee = "Tábua para Queijos", precoo = 39.99 },
                new produtoo(){ nomee = "Uva 500g", precoo = 7.99 },
                new produtoo(){ nomee = "Maçã 500g", precoo = 5.99 },
                new produtoo(){ nomee = "Espumante 750ml", precoo = 72.32 },
                new produtoo(){ nomee = "Taça de Vinho 300ml", precoo = 10.50 },
                new produtoo(){ nomee = "Bombom Ferrero Rocher 100g", precoo = 39.90 },
                new produtoo(){ nomee = "Bombom Sonho de Valsa", precoo = 1.99 },
                new produtoo(){ nomee = "Caixa de Bombons Nestle 251g", precoo = 14.50 },
                new produtoo(){ nomee = "Kit Kat 41,5g", precoo = 3.59 },
                new produtoo(){ nomee = "Kinder Bueno 43g", precoo = 7.99 },
                new produtoo(){ nomee = "Diamante Negro 90g", precoo = 6.99 },
                new produtoo(){ nomee = "M&M'S 90g", precoo = 6.99 },
                new produtoo(){ nomee = "Twix 15g", precoo = 1.10 }
            };

            //Construir a Lista de Produtos
            foreach (produtoo q in LISTA_PRODUTOSS)
            {
                lst_produtoss.Items.Add(ConstruirLinhaProdutoo(q));
            }

            //Iniciar a Compra
            IniciarComprass();

        }

        //__________________________________________________________________//
        private string ConstruirLinhaProdutoo(produtoo q)
        {
            string precoo = q.precoo.ToString("0.00") + " R$";
            return q.nomee + new string(' ', 80 - q.nomee.Length - precoo.Length) + precoo;
        }

        //__________________________________________________________________//
        private void IniciarComprass()
        {
            //Inicia um novo Cálculo
            LISTA_COMPRASS = new List<produtoo>();
            lst_comprass.Items.Clear();
            lbl_totall.Text = "0.00 R$";
        }

        //__________________________________________________________________//
        private void lst_produtoss_DoubleClick(object sender, EventArgs e)
        {
            if (lst_produtoss.SelectedIndex == -1) return;
            produtoo q = LISTA_PRODUTOSS[lst_produtoss.SelectedIndex];
            AdicionarProdutoCompraa(q);

        }

        //__________________________________________________________________//
        private void AdicionarProdutoCompraa(produtoo q)
        {
            //Adiciona um Produto à Compra
            LISTA_COMPRASS.Add(q);
            lst_comprass.Items.Add(ConstruirLinhaProdutoo(q));

            //Calcular Valor Total
            var totall = LISTA_COMPRASS.Sum(j => j.precoo);
            lbl_totall.Text = ("R$ ") + totall.ToString("0.00");
        }

        //__________________________________________________________________//
        private void btn_limparr_Click(object sender, EventArgs e)
        {
            IniciarComprass();
        }

        //__________________________________________________________________//
        private void btn_finalizarr_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SUA COMPRA FOI FINALIZADA COM SUCESSO!" + Environment.NewLine + "QUE A FORÇA ESTEJA COM VOCÊ!" + Environment.NewLine + "VALOR TOTAL: " + lbl_totall.Text);
            IniciarComprass();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

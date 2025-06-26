using MySql.Data.MySqlClient;

namespace BibliotecaApp
{
    public class CadastroLivroPage : Form
    {
        private TextBox txtTitulo, txtAutor, txtAno, txtGenero;
        private Button btnSalvar;

        public CadastroLivroPage()
        {
            Estilos.AplicarEstiloFormulario(this);

            txtTitulo = Estilos.CriarTextBox();
            txtAutor = Estilos.CriarTextBox();
            txtAno = Estilos.CriarTextBox();
            txtGenero = Estilos.CriarTextBox();

            btnSalvar = Estilos.CriarBotao("Salvar");
            btnSalvar.Click += BtnSalvar_Click;

            var layout = Estilos.CriarFormularioLayout(
                ("Título:", txtTitulo),
                ("Autor:", txtAutor),
                ("Ano:", txtAno),
                ("Gênero:", txtGenero)
            );

            Controls.Add(layout);
            Controls.Add(btnSalvar);
        }

        private void BtnSalvar_Click(object sender, System.EventArgs e)
        {
            try
            {
                using var conn = new MySqlConnection(Conexao.ConnectionString);
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO livros (titulo, autor, ano_publicacao, genero) VALUES (@titulo, @autor, @ano, @genero)", conn);
                cmd.Parameters.AddWithValue("@titulo", txtTitulo.Text);
                cmd.Parameters.AddWithValue("@autor", txtAutor.Text);
                cmd.Parameters.AddWithValue("@ano", int.Parse(txtAno.Text));
                cmd.Parameters.AddWithValue("@genero", txtGenero.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Livro cadastrado com sucesso!");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar livro: " + ex.Message);
            }
        }
    }
}